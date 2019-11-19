// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK;
using System.Reflection;
using System.Runtime.Versioning;

namespace DocumentIdentifierExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConcurrentQueue<DocumentIdResult> _resultsQueue = new ConcurrentQueue<DocumentIdResult>();
        private Thread                     _idThread;
        private string[]                   _classificationNames;
        private List<FileFormatDefinition> _allFileFormats = null;
        private int                        _totalUnknownFiles;
        private int                        _totalExceptions;
        private int                        _totalUniqueFileIds;
        private double                     _totalFileIdTimeMs;
        private double                     _avgTimeToIdFile;
        private string                     _rootPath;
        private ParallelOptions            _parallelForOptions = new ParallelOptions();

        #region Constructors...
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;

            InitializeComponent();

            _classificationNames = Enum.GetNames(typeof(IdClassification));
            Array.Sort(_classificationNames);

            _docClassComboBox.ItemsSource   = _classificationNames;
            _allFileFormats                 = DocumentIdentifier.SupportedFormats(); 
            _totalFileFormatsTextBlock.Text = _allFileFormats.Count.ToString();

            _parallelForOptions.MaxDegreeOfParallelism = 8;
            Loaded += MainWindow_Loaded;

            var assembly = Assembly.GetExecutingAssembly();
            using (var textStreamReader = new StreamReader(assembly.GetManifestResourceStream("DocumentIdentifierExample.Directions.txt")))
            {
                _identificationDirectionsTextBox.Text = textStreamReader.ReadToEnd();
            }

            var ver = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
            Title = string.Format("{0};      Framework Version = {1}", Title, ver != null ? ver : "Unknown");
        }
        #endregion

        #region public bool IdentificationResultsAvailable
        public bool IdentificationResultsAvailable
        {
            get { return (bool)GetValue(IdentificationResultsAvailableProperty); }
            set { SetValue(IdentificationResultsAvailableProperty, value); }
        }
        public static readonly DependencyProperty IdentificationResultsAvailableProperty = DependencyProperty.Register("IdentificationResultsAvailable", typeof(bool),
                                                                                               typeof(MainWindow), new FrameworkPropertyMetadata(false));
        #endregion

        #region private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Dispatcher Unhandled Exception: " + e.Exception.Message);
        }
        #endregion


        #region private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _docClassComboBox.SelectedIndex = 0;
            DataContext = this;
        }
        #endregion


        #region private void _browseFolderButton_Click(object sender, RoutedEventArgs e)
        private void _browseFolderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var folderBrowseDlg = new System.Windows.Forms.FolderBrowserDialog();

                if (folderBrowseDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _rootIdPathTextBox.Text = folderBrowseDlg.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error", ex.Message);
            }
        }
        #endregion

        #region private void _startIdProcessButton_Click(object sender, RoutedEventArgs e)
        private void _startIdProcessButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_rootIdPathTextBox.Text))
                {
                    throw new Exception("'File Source Path' is an invalid path.");
                }
                if (!Directory.Exists(_rootIdPathTextBox.Text))
                {
                    throw new Exception("'File Source Path' directory does not exist.");
                }

                _startIdProcessButton.IsEnabled = false;
                _browseFolderButton.IsEnabled   = false;
                _resultsQueue        = new ConcurrentQueue<DocumentIdResult>();
                _totalUnknownFiles  = 0;
                _totalFileIdTimeMs  = 0;
                _avgTimeToIdFile    = 0;
                _totalUniqueFileIds = 0;
                _totalExceptions    = 0;

                // Clear current results:
                _classificationChart.DataSource    = null;
                _idCountChart.DataSource           = null;
                _fileIdResultsDataGrid.ItemsSource = null;
                _classificationChart.Update();
                _idCountChart.Update();

                _rootPath = _rootIdPathTextBox.Text;

                if (_idThread != null && _idThread.IsAlive)
                {
                    _idThread.Abort();
                }

                _statusTextBox.Text = "Running...";

                _idThread = new Thread(WorkerThread);
                _idThread.Priority     = ThreadPriority.Normal; 
                _idThread.IsBackground = true;
                _idThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error", ex.Message);
                _statusTextBox.Text = "Ready.";
            }
        }
        #endregion


        #region private void _fileIdResultsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        private void _fileIdResultsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var result = _fileIdResultsDataGrid.SelectedItem as DocumentIdResult;
                if (result != null)
                {
                    Process.Start("explorer.exe", string.Format("/select,\"{0}\"", result.File));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error", ex.Message);
            }
        }
        #endregion

        #region  private void _docClassComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        private void _docClassComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_allFileFormats == null)
            {
                return;
            }

            try
            {
                var item = _docClassComboBox.SelectedItem as string;

                if (item != null)
                {
                    var selectedDocClass = (IdClassification)Enum.Parse(typeof(IdClassification), item);
                    var formats          = _allFileFormats.Where(x => x.Classification == selectedDocClass).ToArray();

                    _fileFormatsDataGrid.ItemsSource = formats;
                    _numberOfFileFormatsTextBlock.Text = formats.Length.ToString();
                }
            }
            catch
            {
            }
        }
        #endregion

        #region private void UpdateChartingControlsWithResults(List<DocumentIdResult> idResults)
        /// <summary>
        /// Populates ID Classification and ID Format pie charts with latest file format identification results.
        /// </summary>
        /// <param name="idResults"></param>
        private void UpdateChartingControlsWithResults(List<DocumentIdResult> idResults)
        {
            try
            {
                _classificationChart.DataSource = null;
                _idCountChart.DataSource        = null;

                if (idResults == null || idResults.Count == 0)
                {
                    return;
                }

                //
                // Count number of documents that have specific IdClassification and also number of documents with specific Id:
                //
                var idClassificationCount = new Dictionary<IdClassification, int>();
                var fileFormatIdCount     = new Dictionary<Id, int>();
                var count = 0;

                foreach (var formatId in idResults) 
                {
                    if (formatId != null)
                    {
                        var id = formatId.ID;

                        if (idClassificationCount.TryGetValue(formatId.Classification, out count))
                        {
                            idClassificationCount[formatId.Classification] = ++count;
                        }
                        else
                        {
                            idClassificationCount.Add(formatId.Classification, 1);
                        }

                        if (fileFormatIdCount.TryGetValue(formatId.ID, out count))
                        {
                            fileFormatIdCount[id] = ++count;
                        }
                        else
                        {
                            fileFormatIdCount.Add(id, 1);
                        }
                    }
                }


                //
                // IdClassification pie chart:
                //
                var currentPercentVal    = 0.0;
                var keyValueList         = new List<KeyValuePair<string, int>>();
                var exceededCount        = false;
                var percentLessThanValue = false;
                var idCount = 0;
                count = 1;

                foreach (var pair in idClassificationCount.OrderByDescending(x => x.Value)) 
                {
                    currentPercentVal = 100.0 * pair.Value / idResults.Count;

                    if (!percentLessThanValue && currentPercentVal < 1)
                    {
                        percentLessThanValue = true;
                    }

                    if (count > 20 || percentLessThanValue)
                    {
                        idCount += pair.Value;
                        exceededCount = true;
                    }
                    else
                    {
                        keyValueList.Add(new KeyValuePair<string, int>(string.Format("{0} ({1}, {2:F1}%)", pair.Key.ToString(), pair.Value, currentPercentVal), pair.Value));
                    }
                }

                if (exceededCount)
                {
                    keyValueList.Add(new KeyValuePair<string, int>(string.Format("Other Classifications ({0}, {1:F1}%)", idCount, 100.0 * idCount / idResults.Count), idCount));
                }

                _classificationChart.DataSource     = keyValueList;
                _classificationSeries.XValueMember  = "Key";
                _classificationSeries.YValueMembers = "Value";

                //
                // Id pie chart:
                //
                var keyValueList2    = new List<KeyValuePair<string, int>>();
                exceededCount        = false;
                percentLessThanValue = false;
                idCount = 0;
                count   = 1;

                foreach (var pair in fileFormatIdCount.OrderByDescending(x => x.Value))
                {
                    currentPercentVal = 100.0 * pair.Value / idResults.Count;

                    if (!percentLessThanValue && currentPercentVal < 0.25)
                    {
                        percentLessThanValue = true;
                    }

                    if (count > 20 || percentLessThanValue)
                    {
                        idCount += pair.Value;
                        exceededCount = true;
                    }
                    else
                    {
                        keyValueList2.Add(new KeyValuePair<string, int>(string.Format("{0} ({1}, {2:F1}%)", pair.Key.ToString(), pair.Value, currentPercentVal), pair.Value));
                    }
                    ++count;

                }

                if (exceededCount)
                {
                    keyValueList2.Add(new KeyValuePair<string, int>(string.Format("Other Formats ({0}, {1:F1}%)", idCount, 100.0 * idCount / idResults.Count), idCount));
                }

                _idCountChart.DataSource          = keyValueList2;
                _idCountChartSeries.XValueMember  = "Key";
                _idCountChartSeries.YValueMembers = "Value";

                _classificationChart.Dock = System.Windows.Forms.DockStyle.Fill;
                _idCountChart.Dock        = System.Windows.Forms.DockStyle.Fill;

                //_classificationChart.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
                //_idCountChart.Legends[0].Docking        = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
                _classificationChart.Series[0]["PieLabelStyle"] = "Disabled";
                _idCountChart.Series[0]["PieLabelStyle"]        = "Disabled";

                _classificationChart.Invalidate();
                _idCountChart.Invalidate();
            }
            catch
            {
            }
        }
        #endregion


        //
        // Threading:
        //
        #region private void WorkerThread()
        private void WorkerThread()
        {
            try
            {
                var allFiles            = Directory.GetFiles(_rootPath, "*", SearchOption.AllDirectories);
                var totalFiles          = allFiles.Length;
                var totalStopWatch      = Stopwatch.StartNew();
                var uniqueIdSet         = new ConcurrentDictionary<Id,int>(); // No ConcurrenHashSet in .NET so we make use of this

                Dispatcher.Invoke((Action)delegate
                {
                    try
                    {
                        _progressBar.Visibility = Visibility.Visible;
                        _progressBar.Value      = 0;
                    }
                    catch { }
                });

                var lastUpdateStopWatch = Stopwatch.StartNew();

                //
                // Parallelize the file format identification:
                //
                Parallel.ForEach(allFiles, _parallelForOptions, file =>
                {
                    try
                    {
                        IdResult docFormat = null;

                        // WARNING: This example does not support long path names (> 255) - .NET solutions for getting valid FileStreams for 'long file paths'
                        // can be found on the internet - also .NET 4.6.2 supports long file paths (web search for how to enable)
                        // Note: Minimum recommended buffer size of 16kb for file identification
                        using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 16384))
                        {
                            docFormat = DocumentIdentifier.Identify(stream, file);
                        }

                        uniqueIdSet[docFormat.ID] = 1;

                        var docIdResult = new DocumentIdResult(file, docFormat);

                        if (docFormat.ID == Id.Unknown)
                        {
                            Interlocked.Increment(ref _totalUnknownFiles);
                        }

                        _resultsQueue.Enqueue(docIdResult);

                        var numFilesIdentified = _resultsQueue.Count;
                        var percentComplete    = 100.0 * numFilesIdentified / totalFiles;

                        // Update progress bar and status every 250 [ms]:
                        if (lastUpdateStopWatch.ElapsedMilliseconds > 250)
                        {
                            lastUpdateStopWatch.Restart();
                            Dispatcher.BeginInvoke((Action)delegate
                            {
                                try
                                {
                                    _progressBar.Value  = percentComplete;
                                    _statusTextBox.Text = string.Format("  {0} files out of {1} identified...", numFilesIdentified, totalFiles);
                                }
                                catch { }
                            });
                        }

                    }
                    catch (Exception ex)
                    {
                        Interlocked.Increment(ref _totalExceptions);

                        var docIDResult = new DocumentIdResult(file, DocumentIdentifier.UnknownResult);
                        docIDResult.HasError     = true;
                        docIDResult.ErrorMessage = ex.Message;

                        _resultsQueue.Enqueue(docIDResult);
                    }
                });


                totalStopWatch.Stop(); //This time is going to include file I/O along with ID time
                _totalFileIdTimeMs  = totalStopWatch.Elapsed.TotalMilliseconds;
                _totalUniqueFileIds = uniqueIdSet.Count;
                _avgTimeToIdFile    = _totalFileIdTimeMs / Math.Max(1, _resultsQueue.Count);
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke((Action)delegate
                {
                    MessageBox.Show(this, ex.Message, "Exception caught on thread 'WorkerThread' method");
                });
            }
            finally
            {
                WorkerCompleted();
            }
        }
        #endregion

        #region private void WorkerCompleted()
        private void WorkerCompleted()
        {
            Dispatcher.BeginInvoke((Action)delegate
                {
                    try
                    {
                        _progressBar.Visibility = Visibility.Collapsed;

                        var idResults = _resultsQueue.ToList();
                        _resultsQueue = null;
                        
                        _startIdProcessButton.IsEnabled    = true;
                        _browseFolderButton.IsEnabled      = true;
                        _fileIdResultsDataGrid.ItemsSource = idResults;

                        _statusTextBox.Text = string.Format(
                             "Total files = {0:###,###,###}   |   Total ID Time = {1:F3} [sec]   |   (Avg. ID Time)/File = {2:F4} [ms]   |   Unknown files = {3}   |   Total Unique IDs = {4}   |   Total Exceptions = {5}",
                             idResults.Count, _totalFileIdTimeMs/1000, _avgTimeToIdFile, _totalUnknownFiles, _totalUniqueFileIds, _totalExceptions);

                        IdentificationResultsAvailable = true;
                        UpdateChartingControlsWithResults(idResults);
                    }
                    catch { }
            } );
        }
        #endregion
    }
}
