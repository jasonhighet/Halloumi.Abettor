using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Halloumi.Abettor.Plugins.FileSync.Forms;
using Halloumi.Abettor.Plugins.FileSync.Helpers;
using Halloumi.Abettor.Plugins.FileSync.Properties;
using Halloumi.Common.Helpers;

namespace Halloumi.Abettor.Plugins.FileSync
{
    public partial class FileSyncPlugin : Component, IPlugin
    {
        #region Private Variables

        /// <summary>
        /// Helper class for syncing files
        /// </summary>
        private FileSync _fileSync;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the FileSyncPlugin class.
        /// </summary>
        public FileSyncPlugin()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the FileSyncPlugin class.
        /// </summary>
        /// <param name="container">The container.</param>
        public FileSyncPlugin(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Initializes the plugin.
        /// </summary>
        private void Initialize()
        {
            _fileSync = new FileSync();
            _fileSync.SyncStarted += FileSync_SyncStarted;
            _fileSync.SyncCompleted += FileSync_SyncCompleted;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the menu item for the plugin
        /// </summary>
        /// <returns>The menu item for the plugin</returns>
        public ToolStripItemCollection GetMenuItems()
        {
            return contextMenuStrip.Items;
        }

        /// <summary>
        /// Starts the plugin.
        /// </summary>
        public void Start()
        {
            LoadSettings();
            SyncFiles();
        }

        /// <summary>
        /// Stops the plugin.
        /// </summary>
        public void Stop()
        {
            timer.Stop();
            timer.Enabled = false;
            SaveSettings();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Loads the application settings.
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                _fileSync.FolderSets = LoadFolderSets();

                SetSyncFrequency(Settings.Default.SyncFrequency);
            }
            catch (Exception exception)
            {
                ExceptionHelper.HandleException("Error loading settings", exception);
            }
        }

        /// <summary>
        /// Loads the folder sets.
        /// </summary>
        private List<FolderSet> LoadFolderSets()
        {
            try
            {
                var xml = Settings.Default.FolderSets;
                return SerializationHelper<List<FolderSet>>.FromXmlString(xml);
            }
            catch
            {
                return new List<FolderSet>();
            }
        }

        /// <summary>
        /// Saves the application settings.
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                Settings.Default.SyncFrequency = GetSyncFrequency();
                Settings.Default.Save();
            }
            catch (Exception exception)
            {
                ExceptionHelper.HandleException("Error saving settings", exception);
            }
        }

        /// <summary>
        /// Changes the wallpaper.
        /// </summary>
        private void SyncFiles()
        {
            try
            {
                if (GetSyncFrequency() != SyncFrequency.Never)
                {
                    _fileSync.SyncFilesAsync();
                }
            }
            catch (Exception exception)
            {
                ExceptionHelper.HandleException("Error syncing files", exception);
            }
        }

        /// <summary>
        /// Sets the wallpaper change frequency.
        /// </summary>
        /// <param name="frequency">
        /// The frequency in minutes to change the wallpaper, or 0 for startup only, or -1 for never.
        /// </param>
        private void SetSyncFrequency(int frequency)
        {
            if (frequency == SyncFrequency.OnStartupOnly
                || frequency == SyncFrequency.Never)
            {
                timer.Stop();
                timer.Enabled = false;
            }
            else
            {
                timer.Interval = frequency * 60000;
                if (!timer.Enabled)
                {
                    timer.Start();
                }
            }
            foreach (ToolStripMenuItem menuItem in mnuFrequency.DropDownItems)
            {
                menuItem.Checked = (menuItem.Tag.ToString() == frequency.ToString());
            }
        }

        /// <summary>
        /// Gets the wallpaper change frequency.
        /// </summary>
        /// <returns>
        /// The frequency in minutes to change the wallpaper, or 0 for startup only, or -1 for never.
        /// </returns>
        private int GetSyncFrequency()
        {
            foreach (ToolStripMenuItem menuItem in mnuFrequency.DropDownItems)
            {
                if (menuItem.Checked) return int.Parse(menuItem.Tag.ToString());
            }
            return -1;
        }

        #endregion

        #region Internal Classes

        /// <summary>
        /// Wallpaper change frequency constants
        /// </summary>
        private class SyncFrequency
        {
            public const int Never = -1;
            public const int OnStartupOnly = 0;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles the SyncCompleted event of the FileSync control.
        /// </summary>
        private void FileSync_SyncCompleted(object sender, EventArgs e)
        {
            try
            {
                contextMenuStrip.BeginInvoke((MethodInvoker)delegate
                {
                    mnuSyncNow.Enabled = true;
                });
            }
            catch { }
            try
            {
                mnuSyncNow.Enabled = true;
            }
            catch { }
        }

        /// <summary>
        /// Handles the SyncStarted event of the FileSync control.
        /// </summary>
        private void FileSync_SyncStarted(object sender, EventArgs e)
        {
            try
            {
                contextMenuStrip.BeginInvoke((MethodInvoker)delegate
                {
                    mnuSyncNow.Enabled = false;
                });
            }
            catch { }
            try
            {
                mnuSyncNow.Enabled = false;
            }
            catch { }
        }

        /// <summary>
        /// Handles the Click event of the mnuEvery4Hours control.
        /// </summary>
        private void mnuEvery4Hours_Click(object sender, EventArgs e)
        {
            SetSyncFrequency(60 * 4);
        }

        /// <summary>
        /// Handles the Click event of the mnuEvery8Hours control.
        /// </summary>
        private void mnuEvery8Hours_Click(object sender, EventArgs e)
        {
            SetSyncFrequency(60 * 8);
        }

        /// <summary>
        /// Handles the Click event of the mnuEvery15Minutes control.
        /// </summary>
        private void mnuEvery15Minutes_Click(object sender, EventArgs e)
        {
            SetSyncFrequency(15);
        }

        /// <summary>
        /// Handles the Click event of the mnuEvery30Minutes control.
        /// </summary>
        private void mnuEvery30Minutes_Click(object sender, EventArgs e)
        {
            SetSyncFrequency(30);
        }

        /// <summary>
        /// Handles the Click event of the mnuEvery5Minutes control.
        /// </summary>
        private void mnuEvery5Minutes_Click(object sender, EventArgs e)
        {
            SetSyncFrequency(5);
        }

        /// <summary>
        /// Handles the Click event of the mnuEveryHour control.
        /// </summary>
        private void mnuEveryHour_Click(object sender, EventArgs e)
        {
            SetSyncFrequency(60);
        }

        /// <summary>
        /// Handles the Click event of the mnuNever control.
        /// </summary>
        private void mnuNever_Click(object sender, EventArgs e)
        {
            SetSyncFrequency(SyncFrequency.Never);
        }

        /// <summary>
        /// Handles the Click event of the mnuOnStartup control.
        /// </summary>
        private void mnuOnStartup_Click(object sender, EventArgs e)
        {
            SetSyncFrequency(SyncFrequency.OnStartupOnly);
        }

        /// <summary>
        /// Handles the Click event of the mnuSyncNow control.
        /// </summary>
        private void mnuSyncNow_Click(object sender, EventArgs e)
        {
            SyncFiles();
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            SyncFiles();
        }

        /// <summary>
        /// Handles the Click event of the mnuViewLog control.
        /// </summary>
        private void mnuViewLog_Click(object sender, EventArgs e)
        {
            _fileSync.ViewLogFile();
        }

        /// <summary>
        /// Handles the Click event of the mnuFolders control.
        /// </summary>
        private void mnuFolders_Click(object sender, EventArgs e)
        {
            (new frmFolderSetup()).ShowDialog();
            _fileSync.FolderSets = LoadFolderSets();
        }

        #endregion
    }
}