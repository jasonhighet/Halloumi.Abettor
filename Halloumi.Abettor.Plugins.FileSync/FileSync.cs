using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Halloumi.Common.Helpers;
using Halloumi.Common.Windows.Helpers;
using Microsoft.Win32;

namespace Halloumi.Abettor.Plugins.FileSync
{
    public class FileSync
    {
        #region Events

        /// <summary>
        /// Occurs when a sync is completed.
        /// </summary>
        public event EventHandler SyncCompleted;

        /// <summary>
        /// Occurs when a sync is started.
        /// </summary>
        public event EventHandler SyncStarted;

        #endregion

        #region Private Variables

        /// <summary>
        /// Set to true when file syncing is occurring
        /// </summary>
        private bool _syncingFiles = false;

        /// <summary>
        /// Delegate for syncing files asynchronously
        /// </summary>
        private delegate void SyncFilesDelegate();

        #endregion

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the FileSync class.
        /// </summary>
        public FileSync()
        { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the folders when syncing
        /// </summary>
        public List<FolderSet> FolderSets { get; set; }

        /// <summary>
        /// Gets the log.
        /// </summary>
        public StringBuilder Log { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Syncs files between the source and destination folders
        /// </summary>
        public void SyncFilesAsync()
        {
            if (_syncingFiles) return;

            var syncFiles = new SyncFilesDelegate(this.SyncFiles);
            syncFiles.BeginInvoke(null, null);
        }

        /// <summary>
        /// Launches the process to sync files between the source and destination folders
        /// </summary>
        public void SyncFiles()
        {
            try
            {
                _syncingFiles = true;

                // raise sync started event
                if (this.SyncStarted != null) SyncStarted(this, EventArgs.Empty);

                // clear log
                ClearLogFile();
                this.Log = new StringBuilder();

                if (this.FolderSets != null)
                {
                    var folderSets = this.FolderSets.ToList();
                    foreach (var folderSet in folderSets)
                    {
                        SyncFolderSet(folderSet.SourceFolder, folderSet.DestinationFolder);
                    }
                }
            }
            catch (Exception e)
            {
                AddLogEntry(e.ToString());
            }
            finally
            {
                AddLogEntry(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " - Finished");
                _syncingFiles = false;

                SaveLog();

                // raise completed event
                if (this.SyncCompleted != null) SyncCompleted(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Views the log file.
        /// </summary>
        public void ViewLogFile()
        {
            if (_syncingFiles)
            {
                SaveLog();
            }
            if (File.Exists(this.GetLogFilename()))
            {
                Process.Start(this.GetLogFilename());
            }
        }

        /// <summary>
        /// Clears the log file.
        /// </summary>
        public void ClearLogFile()
        {
            if (File.Exists(this.GetLogFilename()))
            {
                File.Delete(this.GetLogFilename());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Launches the process to sync files between the source and destination files
        /// </summary>
        /// <param name="sourceFolder">The source folder.</param>
        /// <param name="destinationFolder">The destination folder.</param>
        private void SyncFolderSet(string sourceFolder, string destinationFolder)
        {
            try
            {
                // clean folder names
                string pathSeparator = @"\";
                if (!sourceFolder.EndsWith(pathSeparator)) sourceFolder += pathSeparator;
                if (!destinationFolder.EndsWith(pathSeparator)) destinationFolder += pathSeparator;

                AddLogEntry(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")
                    + " - Syncing '"
                    + sourceFolder
                    + "' with '"
                    + destinationFolder
                    + "'");

                // abort if files don't exist
                if (!Directory.Exists(sourceFolder))
                {
                    AddLogEntry(sourceFolder + " does not exist.");
                    return;
                }

                if (!Directory.Exists(destinationFolder))
                {
                    AddLogEntry(destinationFolder + " does not exist.");
                    return;
                }

                // sync the root folder
                SyncFolder(sourceFolder, destinationFolder);
            }
            catch (Exception e)
            {
                AddLogEntry(e.ToString());
            }
        }

        /// <summary>
        /// Returns the filename of the log file
        /// </summary>
        /// <returns>The filename of the log file</returns>
        private string GetLogFilename()
        {
            return Path.Combine(Path.GetTempPath(), "FileSync.Log.txt");
        }

        /// <summary>
        /// Saves the log entries to a text file
        /// </summary>
        private void SaveLog()
        {
            try
            {
                File.WriteAllText(this.GetLogFilename(), this.Log.ToString());
            }
            catch
            { }
        }

        /// <summary>
        /// Returns true if a file should not be synced, based on filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>True if the file should be skipped</returns>
        private bool IsFileToSkip(string filename)
        {
            filename = Path.GetFileName(filename).ToLower();

            if (filename == "ehthumbs_vista.db") return true;
            if (filename == "thumbs.db") return true;
            if (filename == ".ds_store") return true;

            return false;
        }

        /// <summary>
        /// Returns true if a folder should not be synced, based on the folder name.
        /// </summary>
        /// <param name="folderName">The folder name.</param>
        /// <returns>True if the file should be skipped</returns>
        private bool IsFolderToSkip(string folderName)
        {
            folderName = GetFolderName(folderName).ToLower();

            if (folderName == ".wd_tv") return true;
            if (folderName == "bin") return true;
            if (folderName == "obj") return true;

            return false;
        }

        /// <summary>
        /// Gets the name of the last folder from a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The last folder name</returns>
        private static string GetFolderName(string path)
        {
            if (path.Length > 1 && path.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                path = Path.GetDirectoryName(path);
            }
            return Path.GetFileName(path);
        }

        /// <summary>
        /// Syncs a source folder with a destination folder, including all subfolders
        /// </summary>
        /// <param name="sourceFolder">The source folder.</param>
        /// <param name="destinationFolder">The destination folder.</param>
        private void SyncFolder(string sourceFolder, string destinationFolder)
        {
            if (IsFolderToSkip(sourceFolder)) return;

            var sourceFolderName = GetFolderName(sourceFolder);

            // loop through all subfolders on the source.
            // if the subfolder does not exist on the destination, copy it
            // otherwise, sync each subfolder
            foreach (var sourceSubFolder in GetSubfolders(sourceFolder))
            {
                var subFolderName = GetFolderName(sourceSubFolder);
                var destinationSubFolder = Path.Combine(destinationFolder, subFolderName);

                if (!Directory.Exists(destinationSubFolder))
                {
                    CopyFolder(sourceSubFolder, destinationSubFolder);
                }
                else
                {
                    SyncFolder(sourceSubFolder, destinationSubFolder);
                }
            }

            Debug.WriteLine("Syncing " + sourceFolderName);

            // delete folders on the destination that do not exist on the source
            foreach (var destinationSubFolder in GetSubfolders(destinationFolder))
            {
                var subFolderName = GetFolderName(destinationSubFolder);
                var sourceSubFolder = Path.Combine(sourceFolder, subFolderName);

                if (!Directory.Exists(sourceSubFolder))
                {
                    DeleteFolder(destinationSubFolder);
                }
            }

            // loop through all files on the source.
            // if the file does not exist on the destination, copy it
            // if the file has a different timestamp or length to the destination, copy it
            foreach (string sourceFile in GetFiles(sourceFolder))
            {
                string fileName = Path.GetFileName(sourceFile);
                string destinationFile = Path.Combine(destinationFolder, fileName);

                Debug.WriteLine("\t" + fileName);

                if (!File.Exists(destinationFile))
                {
                    CopyFile(sourceFile, destinationFile);
                }
                else
                {
                    var sourceInfo = new FileInfo(sourceFile);
                    var destinationInfo = new FileInfo(destinationFile);

                    if (sourceInfo.Length != destinationInfo.Length
                        || GetLastWriteTimestamp(sourceInfo) != GetLastWriteTimestamp(destinationInfo))
                    {
                        CopyFile(sourceFile, destinationFile);
                    }

                    if (GetLastWriteTimestamp(sourceInfo) != GetLastWriteTimestamp(destinationInfo))
                    {
                        SyncFileDateTimes(sourceFile, destinationFile);
                    }
                }
            }

            // delete files on the destination that do not exist on the source
            foreach (string destinationFile in GetFiles(destinationFolder))
            {
                string fileName = Path.GetFileName(destinationFile);
                string sourceFile = Path.Combine(sourceFolder, fileName);

                if (!File.Exists(sourceFile))
                {
                    DeleteFile(destinationFile);
                }
            }
        }

        /// <summary>
        /// Gets the sub-folders in a folder, in alphabetical order
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <returns>The files in a folder, in alphabetical order</returns>
        private List<string> GetSubfolders(string folder)
        {
            return Directory
                .GetDirectories(folder)
                .Where(x => !IsFolderToSkip(x))
                .OrderBy(x => x)
                .ToList();
        }

        /// <summary>
        /// Gets the files in a folder, in alphabetical order
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <returns>The files in a folder, in alphabetical order</returns>
        private List<string> GetFiles(string folder)
        {
            return Directory
                .GetFiles(folder)
                .Where(x => !IsFileToSkip(x))
                .OrderBy(x => x)
                .ToList();
        }

        /// <summary>
        /// Copies a folder to a destination folder.  Also copies all subfolders
        /// If the destination folder does not exist, it will be created
        /// </summary>
        /// <param name="sourceFolder">The source folder.</param>
        /// <param name="destinationFolder">The destination folder.</param>
        private void CopyFolder(string sourceFolder, string destinationFolder)
        {
            // if folder doesn't exist, create it.
            // if it can't be created, exit
            if (!Directory.Exists(destinationFolder))
            {
                if (!CreateFolder(destinationFolder)) return;
            }

            // loop through all files on the source and copy to destination
            foreach (string sourceFile in GetFiles(sourceFolder))
            {
                if (IsFileToSkip(sourceFile)) continue;

                string fileName = Path.GetFileName(sourceFile);
                string destinationFile = Path.Combine(destinationFolder, fileName);
                CopyFile(sourceFile, destinationFile);
            }

            // loop through all subfolders on the source and copy to destination
            foreach (string sourceSubFolder in GetSubfolders(sourceFolder))
            {
                string subFolderName = GetFolderName(sourceSubFolder);
                string destinationSubFolder = Path.Combine(destinationFolder, subFolderName);
                CopyFolder(sourceSubFolder, destinationSubFolder);
            }
        }

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="file">The file to delete.</param>
        private void DeleteFile(string file)
        {
            try
            {
                File.Delete(file);
                AddLogEntry("Deleted file '" + file + "'");
            }
            catch (Exception e)
            {
                AddLogEntry("** Could not delete file '" + file + "'");
                AddLogEntry(e.ToString());
            }
        }

        /// <summary>
        /// Copies a file.
        /// </summary>
        /// <param name="sourceFile">The source file.</param>
        /// <param name="destinationFile">The destination file.</param>
        private void CopyFile(string sourceFile, string destinationFile)
        {
            try
            {
                if (File.Exists(destinationFile))
                    File.Delete(destinationFile);

                FileSystemHelper.Copy(sourceFile, destinationFile);
                SyncFileDateTimes(sourceFile, destinationFile);

                AddLogEntry("Copied file '" + Path.GetFileName(sourceFile)
                    + "' to '"
                    + Path.GetDirectoryName(destinationFile)
                    + "'");
            }
            catch (Exception e)
            {
                AddLogEntry("** Could not copy file '"
                    + Path.GetFileName(sourceFile)
                    + "' to '"
                    + Path.GetDirectoryName(destinationFile)
                    + "'");
                AddLogEntry(e.ToString());
            }
        }

        /// <summary>
        /// Synchronizes the create/last write date-times of two files
        /// </summary>
        /// <param name="sourceFile">The source file.</param>
        /// <param name="destinationFile">The destination file.</param>
        private void SyncFileDateTimes(string sourceFile, string destinationFile)
        {
            try
            {
                var sourceLastWriteTime = GetLastWriteTimestamp(sourceFile);
                var sourceCreationTime = GetCreationTimestamp(sourceFile);

                if (IsReadOnly(destinationFile))
                {
                    SetFileToNotReadOnly(destinationFile);
                }

                File.SetLastWriteTime(destinationFile, sourceLastWriteTime);
                File.SetCreationTime(destinationFile, sourceCreationTime);

                var destinationLastWriteTime = GetLastWriteTimestamp(destinationFile);
                if (sourceLastWriteTime != destinationLastWriteTime)
                {
                    if (IsReadOnly(sourceFile))
                    {
                        SetFileToNotReadOnly(sourceFile);
                    }

                    File.SetLastWriteTime(sourceFile, destinationLastWriteTime);
                }
            }
            catch (Exception e)
            {
                AddLogEntry("** Could not sync file date-times of '"
                    + Path.GetFileName(sourceFile)
                    + "' and '"
                    + Path.GetDirectoryName(destinationFile)
                    + "'");
                AddLogEntry(e.ToString());
            }
        }

        /// <summary>
        /// Gets the last-write timestamp of a file
        /// </summary>
        /// <param name="fileInfo">The file information.</param>
        /// <returns>
        /// The last-write timestamp
        /// </returns>
        private DateTime GetLastWriteTimestamp(FileInfo fileInfo)
        {
            try
            {
                return fileInfo.LastWriteTime;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Gets the last-write timestamp of a file
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The last-write timestamp</returns>
        private DateTime GetLastWriteTimestamp(string filename)
        {
            var fileInfo = new FileInfo(filename);
            return GetLastWriteTimestamp(fileInfo);
        }

        /// <summary>
        /// Determines whether a file is read only
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>
        /// True if read only
        /// </returns>
        private bool IsReadOnly(string filename)
        {
            try
            {
                var fileInfo = new FileInfo(filename);
                return fileInfo.IsReadOnly;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the file to not be read only.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private void SetFileToNotReadOnly(string filePath)
        {
            if (!File.Exists(filePath)) return;
            var fileInfo = new FileInfo(filePath);
            fileInfo.IsReadOnly = false;
        }

        /// <summary>
        /// Gets the create timestamp of a file
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The create timestamp</returns>
        private DateTime GetCreationTimestamp(string filename)
        {
            try
            {
                var fileInfo = new FileInfo(filename);
                return fileInfo.CreationTime;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Deletes a folder.
        /// </summary>
        /// <param name="folder">The folder to delete.</param>
        private void DeleteFolder(string folder)
        {
            try
            {
                FileSystemHelper.DeleteFolder(folder);
                AddLogEntry("Deleted folder '" + folder + "'");
            }
            catch (Exception e)
            {
                AddLogEntry("** Could not delete folder '" + folder + "'");
                AddLogEntry(e.ToString());
            }
        }

        /// <summary>
        /// Creates a folder.
        /// </summary>
        /// <param name="folder">The folder to create.</param>
        /// <returns>True if successful</returns>
        private bool CreateFolder(string folder)
        {
            try
            {
                Directory.CreateDirectory(folder);
                AddLogEntry("Created folder '" + folder + "'");
                return true;
            }
            catch (Exception e)
            {
                AddLogEntry("** Could not create folder '" + folder + "'");
                AddLogEntry(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Adds an entry to the log
        /// </summary>
        /// <param name="message">The message.</param>
        private void AddLogEntry(string message)
        {
            try
            {
                this.Log.AppendLine(message);
                Debug.WriteLine(message);
            }
            catch
            { }
        }

        #endregion
    }
}