using System;
using System.Collections.Generic;
using System.IO;
using OpenDiscoverSDK;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Platform;
using OpenDiscoverSDK.Interfaces.Platform.Settings;
using OpenDiscoverSDK.Interfaces.Settings;
using OpenDiscoverSDK.Platform.Inventory.Legacy;

namespace DocumentTaskEngineExample
{
    internal class TaskSettingsHelper
    {
        #region internal static DocumentTaskSettings  CreateDocumentSetTaskSettings(int jobId, string taskGuid, string inputDataFolder, string outputRootFolderPath, ...
        /// <summary>
        /// Creates a DocumentTaskSettings that inventories all the documents in the inputDataFolder.
        /// </summary>
        /// <param name="jobId">Simulated processing job ID.</param>
        /// <param name="taskGuid">Simulated task ID of just one of the processing tasks that make up a complete processing job.</param>
        /// <param name="inputDataFolder">The folder path to a document set to process as a task.</param>
        /// <param name="outputRootFolderPath">The root output folder to write processing task output.</param>
        /// <param name="performNistCheck">
        /// If true, de-NISTs all documents as processing. Folder path argument nistDatabasePath must contain a valid NIST database file.
        /// </param>
        /// <param name="nistDatabasePath">
        /// Folder path that contains a OpenDiscoverPlatform created NIST database file (always named "data.mdb"). If file does not exist set this 
        /// value to null and argument performNistCheck to false.
        /// </param>
        /// <param name="passwordListFilePath">
        /// File path to a text file that contains a list of passwords that can be used to decrypt any supported file formats for encryption. The file
        /// format is one password per line in the file. DO NOT use guess passwords, only use known valid passwords that will decrypt files. Too many
        /// passwords will degrade performance as testing a password in a file's decryption is an expensive operation by design.
        /// </param>
        /// <param name="excludeIgnoreFilePath">
        /// File path to a file that contains file format Ids to either 'exclude' or 'ignore' from processing. These are typically file formats that are 
        /// considered not to have any useful content for indexing, etc. See method <see cref="LoadExcludeIgnoreDocumentTypes"/>.
        /// </param>
        /// <returns>A DocumentSetTaskSettings object that determines what DocumentTaskEngine processes and how.</returns>
        internal static DocumentTaskSettings CreateDocumentSetTaskSettings(int jobId, string taskGuid, string inputDataFolder, string outputRootFolderPath, 
                                                         bool performNistCheck, string nistDatabasePath, string passwordListFilePath, string excludeIgnoreFilePath)
        {
            var taskSettings = new DocumentTaskSettings();

            // Ideally, all task settings parameters would be passed to console app as command line arguments or command line parameter(s) would indicate
            // a service endpoint, a message queue, or a database, to query by using 'jobId' and 'taskId' in as query parameters. 
            taskSettings.CollectionId  = jobId.ToString();
            taskSettings.TaskId        = taskGuid;

            var taskOutputPath = Path.Combine(outputRootFolderPath, string.Format(@"CollectionId_{0}\Task_{1}", taskSettings.CollectionId, taskSettings.TaskId));

            if (!Directory.Exists(taskOutputPath))
            {
                Directory.CreateDirectory(taskOutputPath);
            }

            //
            // VERY FAST INVENTORY OF DIRECTORIES AND FILES - Get all files/sub-directories and their file system attributes:
            // NOTE: In a real world application a list of document paths, e.g., a set of 1000 documents, would be passed in or 
            //       popped off of some message queue instead of inventorying a folder here to get source documents to process.
            var inventoryResult = InventoryLegacy.InventoryDirectory(inputDataFolder);

            taskSettings.ProcessingTaskType = ProcessingType.DocumentSet;

            // Set paths for processing output files:
            taskSettings.DocumentArchiveRootPath = taskOutputPath;

            taskSettings.Documents                = inventoryResult.Documents;  //Sets list of documents to process
            taskSettings.ProcessingMode           = ProcessingMode.TextAndMetadata;
            taskSettings.OutputMode               = OutputMode.Archive; //Write out 'flat' individual files for document data, text, and attachments
            taskSettings.Passwords                = LoadPasswordFile(passwordListFilePath);
            taskSettings.ExcludeInlineEmailImages = true;
            taskSettings.EmbeddedObjectExtraction = EmbeddedExtractionType.EmbeddedDocumentsOnly;
            taskSettings.PerformNistCheck         = true;
            taskSettings.NistRdsDatabasePath      = nistDatabasePath;
            taskSettings.TimeZoneAndEmail.CollectionTimeZone = TimeZoneInfo.Utc;

            // Load document formats to exclude and child document formats to ignore completely:
            LoadExcludeIgnoreDocumentTypes(excludeIgnoreFilePath, taskSettings);

            return taskSettings;
        }
        #endregion

        #region internal static DocumentTaskSettings  CreateArchiveTaskSettings(int jobId, string taskGuid, string archivePath, string outputRootFolderPath, bool performNistCheck, ...
        /// <summary>
        /// Creates a DocumentTaskSettings that processes all the documents in the archive given by 'archivePath' 
        /// </summary>
        /// <param name="collectionId">Simulated processing collection ID.</param>
        /// <param name="taskGuid">Simulated task ID of just one of the processing tasks that make up a complete processing job.</param>
        /// <param name="archivePath">Full file path to an supported archive file format to process.</param>
        /// <param name="outputRootFolderPath">The root output folder to write processing task output.</param>
        /// <param name="performNistCheck">
        /// If true, de-NISTs all documents as processing. Folder path argument nistDatabasePath must contain a valid NIST database file.
        /// </param>
        /// <param name="nistDatabasePath">
        /// Folder path that contains a OpenDiscoverPlatform created NIST database file (always named "data.mdb"). If file does not exist set this 
        /// value to null and argument performNistCheck to false.
        /// </param>
        /// <param name="passwordListFilePath">
        /// File path to a text file that contains a list of passwords that can be used to decrypt any supported file formats for encryption. The file
        /// format is one password per line in the file. DO NOT use guess passwords, only use known valid passwords that will decrypt files. Too many
        /// passwords will degrade performance as testing a password in a file's decryption is an expensive operation by design.
        /// </param>
        /// <param name="excludeIgnoreFilePath">
        /// File path to a file that contains file format Ids to either 'exclude' or 'ignore' from processing. These are typically file formats that are 
        /// considered not to have any useful content for indexing, etc. See method <see cref="LoadExcludeIgnoreDocumentTypes"/>.
        /// </param>
        /// <returns>A ArchiveTaskSettings object that determines what DocumentTaskEngine processes and how.</returns>
        internal static DocumentTaskSettings CreateArchiveTaskSettings(int collectionId, string taskGuid, string archivePath, string outputRootFolderPath, bool performNistCheck, 
                                         string nistDatabasePath, string passwordListFilePath, string excludeIgnoreFilePath)
        {
            // Set up document task configuration:
            var taskSettings = new DocumentTaskSettings();

            // Ideally, all task settings parameters would be passed to console app as command line arguments or command line parameter(s) would indicate
            // a service endpoint, a message queue, or a database, to query by using 'collectionId' and 'taskId' in as query parameters. 
            taskSettings.CollectionId = collectionId.ToString();
            taskSettings.TaskId       = taskGuid;

            taskSettings.ProcessingTaskType = ProcessingType.SingleArchive;

            // If partitioning an 'large' archive (example settings):
            //taskSettings.IsPartitioned   = true;
            //taskSettings.TotalPartitions = 5;
            //taskSettings.PartitionTarget = 2; // The partition # this task will work on

            var taskOutputPath = Path.Combine(outputRootFolderPath, string.Format(@"CollectionId_{0}\Task_{1}", taskSettings.CollectionId, taskSettings.TaskId));

            if (!Directory.Exists(taskOutputPath))
            {
                Directory.CreateDirectory(taskOutputPath);
            }

            //
            // For ArchiveTaskConfig input documents, Document.FilePath and Document.FormatId are required to be set:
            // Note, for a split archive we would need to all split segments to be identified.
            var archiveDocument = new Document();
            archiveDocument.FilePath = archivePath;
            using (var docStream = File.OpenRead(archivePath))
            {
                archiveDocument.FormatId = DocumentIdentifier.Identify(docStream, archivePath);
            }

            // Set paths for processing output files:
            taskSettings.DocumentArchiveRootPath = taskOutputPath;

            taskSettings.Documents                = new List<Document>() { archiveDocument };  //A split archive would take the list of split segments documents in order
            taskSettings.ProcessingMode           = ProcessingMode.TextAndMetadata;
            taskSettings.OutputMode               = OutputMode.IndividualFiles; //Write out 'flat' individual files for document data, text, and attachments
            taskSettings.Passwords                = LoadPasswordFile(passwordListFilePath);
            taskSettings.ExcludeInlineEmailImages = true;
            taskSettings.EmbeddedObjectExtraction = EmbeddedExtractionType.EmbeddedDocumentsOnly;
            taskSettings.PerformNistCheck         = true;
            taskSettings.NistRdsDatabasePath      = nistDatabasePath;
            taskSettings.TimeZoneAndEmail.CollectionTimeZone = TimeZoneInfo.Utc;

            // Load document formats to exclude and child document formats to ignore completely:
            LoadExcludeIgnoreDocumentTypes(excludeIgnoreFilePath, taskSettings);

            return taskSettings;
        }
        #endregion

        #region internal static DocumentTaskSettings  CreateMailStoreTaskSettings(int jobId, string taskGuid, string mailStorePath, string outputRootFolderPath, bool performNistCheck, ...
        /// <summary>
        /// Creates a MailStoreTaskSettings that processes all the documents in the mail store (PST/OST/MBOX/etc) given by 'mailStorePath' 
        /// </summary>
        /// <param name="jobId">Simulated processing job ID.</param>
        /// <param name="taskGuid">Simulated task ID of just one of the processing tasks that make up a complete processing job.</param>
        /// <param name="mailStorePath">Full file path to a supported mail store file format to process.</param>
        /// <param name="outputRootFolderPath">The root output folder to write processing task output.</param>
        /// <param name="performNistCheck">
        /// If true, de-NISTs all documents as processing. Folder path argument nistDatabasePath must contain a valid NIST database file.
        /// </param>
        /// <param name="nistDatabasePath">
        /// Folder path that contains a OpenDiscoverPlatform created NIST database file (always named "data.mdb"). If file does not exist set this 
        /// value to null and argument performNistCheck to false.
        /// </param>
        /// <param name="passwordListFilePath">
        /// File path to a text file that contains a list of passwords that can be used to decrypt any supported file formats for encryption. The file
        /// format is one password per line in the file. DO NOT use guess passwords, only use known valid passwords that will decrypt files. Too many
        /// passwords will degrade performance as testing a password in a file's decryption is an expensive operation by design.
        /// </param>
        /// <param name="excludeIgnoreFilePath">
        /// File path to a file that contains file format Ids to either 'exclude' or 'ignore' from processing. These are typically file formats that are 
        /// considered not to have any useful content for indexing, etc. See method <see cref="LoadExcludeIgnoreDocumentTypes"/>.
        /// </param>
        /// <returns>A MailStoreTaskSettings object that determines what DocumentTaskEngine processes and how.</returns>
        internal static DocumentTaskSettings CreateMailStoreTaskSettings(int jobId, string taskGuid, string mailStorePath, string outputRootFolderPath, bool performNistCheck, 
                                    string nistDatabasePath, string passwordListFilePath, string excludeIgnoreFilePath)
        {
            // Set up document task configuration:
            var taskSettings = new DocumentTaskSettings();

            // Ideally, all task settings parameters would be passed to console app as command line arguments or command line parameter(s) would indicate
            // a service endpoint, a message queue, or a database, to query by using 'jobId' and 'taskId' in as query parameters. 
            taskSettings.CollectionId = jobId.ToString();
            taskSettings.TaskId       = taskGuid;

            taskSettings.ProcessingTaskType = ProcessingType.SingleMailStore;

            // If partitioning a large mail store (example settings):
            //taskSettings.IsPartitioned   = true;
            //taskSettings.TotalPartitions = 2;
            //taskSettings.PartitionTarget = 1; // The partition #, out of TotalPartions, this task will work on

            var taskOutputPath = Path.Combine(outputRootFolderPath, string.Format(@"CollectionId_{0}\Task_{1}", taskSettings.CollectionId, taskSettings.TaskId));

            if (!Directory.Exists(taskOutputPath))
            {
                Directory.CreateDirectory(taskOutputPath);
            }

            //
            // For MailStoreTaskConfig input documents, Document.FilePath and Document.FormatId are required to be set:
            //
            var mailStoreDocument = new Document();
            mailStoreDocument.FilePath = mailStorePath;
            using (var docStream = File.OpenRead(mailStorePath))
            {
                mailStoreDocument.FormatId = DocumentIdentifier.Identify(docStream, mailStorePath);
            }

            // Set paths for processing output files:
            taskSettings.DocumentArchiveRootPath = taskOutputPath;

            taskSettings.Documents                = new List<Document>() { mailStoreDocument };
            taskSettings.ProcessingMode           = ProcessingMode.TextAndMetadata;
            taskSettings.OutputMode               = OutputMode.IndividualFiles; //Write out 'flat' individual files for document data, text, and attachments
            taskSettings.Passwords                = LoadPasswordFile(passwordListFilePath);
            taskSettings.ExcludeInlineEmailImages = true;
            taskSettings.EmbeddedObjectExtraction = EmbeddedExtractionType.EmbeddedDocumentsOnly;
            taskSettings.PerformNistCheck         = true;
            taskSettings.NistRdsDatabasePath      = nistDatabasePath;
            taskSettings.TimeZoneAndEmail.CollectionTimeZone = TimeZoneInfo.Utc;

            // Load document formats to exclude and child document formats to ignore completely:
            LoadExcludeIgnoreDocumentTypes(excludeIgnoreFilePath, taskSettings);

            return taskSettings;
        }
        #endregion


        //
        // Helper Methods:
        //
        #region private static string[] LoadPasswordFile(string passwordListFilePath)
        /// <summary>
        /// Loads a list of passwords from password file to cycle through when encountering password encrypted documents during processing.
        /// </summary>
        /// <param name="passwordListFilePath"></param>
        /// <returns></returns>
        private static string[] LoadPasswordFile(string passwordListFilePath)
        {
            if (string.IsNullOrWhiteSpace(passwordListFilePath))
            {
                Console.WriteLine("No password list file to load in App.config.");
                return null;
            }

            try
            {
                Console.WriteLine("Loading passwords from file '{0}'", passwordListFilePath);

                using (var streamReader = File.OpenText(passwordListFilePath))
                {
                    var all = streamReader.ReadToEnd();

                    if (string.IsNullOrWhiteSpace(all))
                    {
                        Console.WriteLine("Password file was empty(no passwords).");
                    }

                    var lines = all.Trim().Split(new char[] { '\n' });
                    var passwords = new List<string>();

                    foreach (var line in lines)
                    {
                        var password = line.Trim();
                        if (!string.IsNullOrEmpty(password))
                        {
                            passwords.Add(password);
                        }
                    }

                    Console.WriteLine("Successfully loaded {0} passwords from file '{1}'", passwords.Count, passwordListFilePath);

                    return passwords.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception loading passwords file.", ex);
            }

            return null;
        }
        #endregion

        #region private static void     LoadExcludeIgnoreDocumentTypes(string excludeIgnoreTypesFilePath, DocumentSetTaskSettings taskSettings)
        /// <summary>
        /// Loads types to exclude from further processing after identification/hashing and child document to completely ignore (ignored
        /// child documents are usually embedded types with no meaningful content). See example file provided for format that this method parses.
        /// </summary>
        /// <param name="excludeIgnoreTypesFilePath"></param>
        /// <param name="taskSettings"></param>
        private static void LoadExcludeIgnoreDocumentTypes(string excludeIgnoreTypesFilePath, DocumentTaskSettings taskSettings)
        {
            taskSettings.ExcludedDocumentTypes.Clear();

            if (string.IsNullOrWhiteSpace(excludeIgnoreTypesFilePath))
            {
                Console.WriteLine("No excluded file type to load in App.config.");
                return;
            }

            Console.WriteLine("Loading excluded file types from file '{0}'", excludeIgnoreTypesFilePath);

            using (var streamReader = File.OpenText(excludeIgnoreTypesFilePath))
            {
                var all = streamReader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(all))
                {
                    throw new Exception("File was empty (no Exclude/Ignore statements).");
                }

                var lines = all.Trim().Split(new char[] { '\n' });

                foreach (var line in lines)
                {
                    var trimline = line.Trim();

                    if (string.IsNullOrWhiteSpace(trimline))
                    {
                        continue;
                    }

                    var id = (Id)Enum.Parse(typeof(Id), trimline);
                    taskSettings.ExcludedDocumentTypes.Add(id);
                }

                Console.WriteLine("Successfully loaded {0} file formats to Exclude.", taskSettings.ExcludedDocumentTypes.Count);
            }
        }
        #endregion
    }
}
