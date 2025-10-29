// ***************************************************************************************
// 
//  Copyright © 2019-2025 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Platform;
using OpenDiscoverSDK.Interfaces.Platform.Settings;
using OpenDiscoverSDK.Platform;

namespace DocumentTaskEngineExample
{
    /// <summary>
    /// Open Discover® Platform DocumentTaskEngineExample Example:
    /// ----------------------------------------------------------
    /// Simple console application that shows how to:
    /// - Set up DocumentSetTaskSettings, ArchiveTaskSettings, and MailStoreTaskSettings.
    /// - Have a DocumentTaskEngine instance process the task defined by these settings.
    /// </summary>
    /// <remarks>
    /// </remarks>
    class Program
    {
        private static DocumentTaskEngine _documentTaskEngine;
        private static int                _numOfLongRunningDocumentWaits = 0;

        static void Main(string[] args)
        {
            var ver = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
            Console.Title = string.Format("Open Discover Platform DocumentTaskEngine Example;  Framework Version = {0}", ver != null ? ver : "Unknown");
            Console.Clear();

            try
            {
                //       
                // ** EDIT ** the paths in App.config to reflect your Open Discover installation path and your desired output path
                //       
                var appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var installFolderPath     = appConfig.AppSettings.Settings["InstallFolderPath"].Value;      // Open Discover root install path
                var outputRootFolderPath  = appConfig.AppSettings.Settings["OutputRootFolderPath"].Value;   // Processed output will be written to created sub-directories in this root path 
                var inputDataFolder       = appConfig.AppSettings.Settings["InputDataFolder"].Value;        // The folder (and its sub-folders) that contains the files we want to process
                var passwordListFilePath  = appConfig.AppSettings.Settings["PasswordListFilePath"].Value;   // Passwords specific to test data set (set to empty string if no passwords for data set)
                var excludeIgnoreFilePath = appConfig.AppSettings.Settings["ExcludeIgnoreFilePath"].Value;  // File formats to exclude/ignore. See example 'ExcludeIgnoreFormatsExample.txt' for format
                var jobId                 = int.Parse(appConfig.AppSettings.Settings["JobId"].Value);       // Simulated processing job ID
                var taskGuid              = Guid.NewGuid().ToString();                                      // Simulated job task Id (a job can made up of 1 to many tasks for distribution)

                if (!Directory.Exists(installFolderPath))
                {
                    throw new Exception("'InstallFolderPath' directory parameter in App.config does not exist. Did you modify it to reflect your install path?");
                }

                if (!Directory.Exists(outputRootFolderPath))
                {
                    throw new Exception("'OutputRootFolderPath' directory parameter in App.config does not exist. Did you modify it to reflect your install path?");
                }

                if (!Directory.Exists(inputDataFolder))
                {
                    throw new Exception("'InputDataFolder' directory parameter in App.config does not exist. Did you modify it to reflect your install path?");
                }

                //
                // Path to the NIST database (under 'InstallFolderPath' directory):
                //
                var nistDatabasePath = Path.Combine(installFolderPath, @"NIST\NistRdsModernDatabase");
                var performNistCheck = true;
                if (File.Exists(Path.Combine(nistDatabasePath, "data.mdb")))
                {
                    performNistCheck = false;
                    Console.WriteLine("NIST database file path does not contain a valid OpenDiscoverPlatform created NIST database file.");
                    Console.WriteLine("** Setting 'performNistCheck' to false **");
                }


                var taskSettingsType = ProcessingType.DocumentSet;
                //var taskSettingsType = ProcessingType.SingleArchive;   // To test an archive in dataset, uncomment and then comment out the other 2
                //var taskSettingsType = ProcessingType.SingleMailStore;

                DocumentTaskSettings taskSettings = null;
                
                switch (taskSettingsType)
                {
                    case ProcessingType.DocumentSet:
                        taskSettings = TaskSettingsHelper.CreateDocumentSetTaskSettings(jobId, taskGuid, inputDataFolder, outputRootFolderPath,
                                                                   performNistCheck, nistDatabasePath, passwordListFilePath, excludeIgnoreFilePath);
                        break;
                    case ProcessingType.SingleArchive:
                        {
                            // Edit 'archiveFilePath' path if you wish to process a different archive:
                            var archiveFilePath = Path.Combine(installFolderPath, @"TestData\General\Archive\RarEncryptedFilenames_pw2.rar");

                            taskSettings = TaskSettingsHelper.CreateArchiveTaskSettings(jobId, taskGuid, archiveFilePath, outputRootFolderPath,
                                                                       performNistCheck, nistDatabasePath, passwordListFilePath, excludeIgnoreFilePath);
                        }
                        break;
                    case ProcessingType.SingleMailStore:
                        {
                            // Edit 'mailStoreFilePath' path if you wish to process a different mail store (PST/OST/MBOX):
                            var mailStoreFilePath = Path.Combine(installFolderPath, @"TestData\General\MailStore\Japanese.pst");

                            taskSettings = TaskSettingsHelper.CreateMailStoreTaskSettings(jobId, taskGuid, mailStoreFilePath, outputRootFolderPath,
                                                                       performNistCheck, nistDatabasePath, passwordListFilePath, excludeIgnoreFilePath);
                        }
                        break;
                    default:
                        Console.WriteLine("Task Settings Error: 'taskSettingsType' must be either 'ProcessingType.DocumentSet', 'ProcessingType.SingleArchive', or 'ProcessingType.SingleMailStore'.");
                        return;
                }

                _documentTaskEngine = new DocumentTaskEngine(taskSettings);
                _documentTaskEngine.LogUpdated     += LogUpdated;
                _documentTaskEngine.Completed      += Completed;
                _documentTaskEngine.FatalException += FatalException;
                _documentTaskEngine.LongProcessingDocumentWarning += LongProcessingDocumentWarning;

                //
                // Run task synchronously (blocking):
                //
                _documentTaskEngine.RunTaskBlocking();

                //
                // Launch "DocumentDataArchiveReader" example application as a process to read the processing task's document data archive (.dda) output and view task
                // output results.
                // In a real world application, after this processing task successfully completed, some form of a processing job workflow service would issue another task to
                // read the output document data archive (.dda) file (like DocumentDataArchiveReader.exe does here) and insert data into a data store (SQL, document store, etc).
                // If document store does not support indexing of extracted text then this newly issued task could also be used by dtSearch or Lucene.NET to index the extracted text.
                //
                DisplayDocumentDataArchiveOutput(taskSettings.DocumentArchiveRootPath);
            }
            catch (Exception ex)
            {
                FatalException("DocumentTaskEngine had a fatal error.", ex);
                Console.WriteLine("Open Discover SDK is x64 build. Make sure your Visual Studio solution platform is set to x64 before building.");
                Console.WriteLine();
                Console.WriteLine("Exception:");
                Console.WriteLine(ex.Message);
            }

            // Remove this line in real world application (keeps console open until user hits a keyboard key):
            Console.Read();
        }

        #region private static void DisplayDocumentDataArchiveOutput(string documentArchiveRootPath)
        /// <summary>
        /// Launch "DocumentDataArchiveReader.exe" example application as a process to read task archive output and to display task output results.
        /// </summary>
        /// <param name="documentArchiveRootPath">Root folder where task wrote the document data archive (.dda).</param>
        private static void DisplayDocumentDataArchiveOutput(string documentArchiveRootPath)
        {
            var examplesBuildOutputPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var startInfo       = new ProcessStartInfo();
            startInfo.FileName  = Path.Combine(examplesBuildOutputPath, "DocumentDataArchiveReader.exe");  
            startInfo.Arguments = Path.Combine(documentArchiveRootPath, "DocumentDataArchive.dda");        // The .dda file to parse and display
            Process.Start(startInfo);
        }
        #endregion

        //
        // DocumentTaskEngine Event Handlers:
        //
        #region private static void LogUpdated(string logEntry)
        /// <summary>
        /// Echos DocumentTaskEngine log entries to the console screen
        /// </summary>
        /// <param name="logEntry"></param>
        private static void LogUpdated(string logEntry)
        {
            Console.WriteLine(logEntry);
        }
        #endregion

        #region private static void FatalException(string message, Exception ex)
        /// <summary>
        /// DocumentTaskEngine had a fatal exception while processing, this event handler gives DocumentTaskEngine client an opportunity
        /// to perform cleanup and notifications of the failed task before DocumentTaskEngine exits. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        private static void FatalException(string message, Exception ex)
        {
            Console.WriteLine(string.Format("In FatalException handler: DocumentTaskEngine had a fatal error. Error = '{0}'", ex.Message));

            // TODO: Notify job manager that task failed and exit application
        }
        #endregion

        #region private static void Completed(bool completedButHasZombieDocumentThread, double totalElapsedSeconds, TaskRunMetrics metrics)
        /// <summary>
        /// DocumentTaskEngine task Completed event handler.
        /// </summary>
        /// <param name="completedButHasZombieDocumentThread">
        /// If true, DocumentTaskEngine has completed all documents except for one or more "long running" documents that have caused a 'zombie'
        /// processing thread(s) - the DocumentTaskEngine will need to be aborted. If there are 2 or less 'zombie' threads, the already saved (at this point)
        /// DocumntDataArchive.dda task output is valid. If there are more than 2 'zombie' threads then the task should be considered failed and re-queued
        /// by dividing original task into 2 new tasks to isolate the 'long running' documents.
        /// </param>
        /// <param name="totalElapsedSeconds">Total task processing time in seconds.</param>
        /// <param name="metrics">Task processing metrics.</param>
        private static void Completed(bool completedButHasZombieDocumentThread, double totalElapsedSeconds, TaskRunMetrics metrics)
        {
            Console.WriteLine("In Completed handler: DocumentTaskEngine task successfully completed.");

            // TODO: Notify job manager to queue a task that will de-serialize processed data and update
            //       data store (SQL/ElasticSearch/etc) with this data.


            // All notifications to database/web services/etc. must be done before aborting zombie documents:
            if (completedButHasZombieDocumentThread)
            {
                _documentTaskEngine.AbortTask();
            }
        }
        #endregion

        #region private static void LongProcessingDocumentWarning(string message, List<Document> longRunningDocuments, ref bool prepareForAbort)
        /// <summary>
        /// DocumentTaskEngine LongProcessingDocumentWarning event handler.
        /// </summary>
        /// <param name="message">Long running document warning message.</param>
        /// <param name="longRunningDocuments">
        /// List of long running documents currently being processed. This event should be rare and it should be even more rare to have more that 1 'long running' document in
        /// a processing task.
        /// </param>
        /// <param name="prepareForAbort">
        /// If user sets to true, DocumentTaskEngine will mark the long running document with an error and save the DocumentDataArchive.dda output file.
        /// </param>
        private static void LongProcessingDocumentWarning(string message, List<Document> longRunningDocuments, ref bool prepareForAbort)
        {
            Console.WriteLine("In LongProcessingDocumentWarning handler: {0}", message);

            foreach (var docs in longRunningDocuments)
            {
                //... example, inspect or log the long running documents 
                if (docs.FormatId != null && docs.FormatId.ID == Id.AdobePDF)
                {
                    ; //...
                }
            }

            if (longRunningDocuments.Count > 1 && _numOfLongRunningDocumentWaits < 5)
            {
                // We have more than 1 'long running' document - we will give the engine a little more time to process
                // (in this example, up to 5 * 30[sec](150 secs) more)
                ++_numOfLongRunningDocumentWaits; // Each wait period is another 30 seconds
                prepareForAbort = false;
                return;
            }

            // Abort the long running document task, but have document task engine save DocumentDataArchive (.dda) file and mark long running document(s)
            // with an error. 
            prepareForAbort = true;
        }
        #endregion
    }
}
