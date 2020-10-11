using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Halloumi.Abettor.Plugins.WallpaperChanger.Properties;
using Halloumi.Common.Windows.Helpers;

namespace Halloumi.Abettor.Plugins.WallpaperChanger
{
    /// <summary>
    ///
    /// </summary>
    public partial class WallpaperChangerPlugin : Component, IPlugin
    {
        #region Private Variables

        /// <summary>
        /// Helper class for changing wallpaper
        /// </summary>
        private WallpaperChanger _wallpaperChanger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the WallpaperChangerPlugin class.
        /// </summary>
        public WallpaperChangerPlugin()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the WallpaperChangerPlugin class.
        /// </summary>
        /// <param name="container">The container.</param>
        public WallpaperChangerPlugin(IContainer container)
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
            _wallpaperChanger = new WallpaperChanger();
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
            ChangeWallpaper();
        }

        /// <summary>
        /// Stops the plugin.
        /// </summary>
        public void Stop()
        {
            wallpaperTimer.Stop();
            wallpaperTimer.Enabled = false;
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
                _wallpaperChanger.WallpaperFolder = Settings.Default.WallpaperFolder;
                _wallpaperChanger.ApplyMedianFilter = Settings.Default.ApplyMedianFilter;
                _wallpaperChanger.LandscapeOnly = Settings.Default.LandscapeOnly;

                mnuApplyMedianFilter.Checked = _wallpaperChanger.ApplyMedianFilter;
                mnuLandscapeOnly.Checked = _wallpaperChanger.LandscapeOnly;

                if (_wallpaperChanger.WallpaperFolder == "")
                {
                    _wallpaperChanger.WallpaperFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                }

                SetWallpaperChangeFrequency(Settings.Default.WallpaperChangeFrequency);
            }
            catch (Exception exception)
            {
                ExceptionHelper.HandleException("Error loading settings", exception);
            }
        }

        /// <summary>
        /// Saves the application settings.
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                Settings.Default.WallpaperFolder = _wallpaperChanger.WallpaperFolder;
                Settings.Default.ApplyMedianFilter = _wallpaperChanger.ApplyMedianFilter;
                Settings.Default.WallpaperChangeFrequency = GetWallpaperChangeFrequency();
                Settings.Default.LandscapeOnly = _wallpaperChanger.LandscapeOnly;
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
        private void ChangeWallpaper()
        {
            try
            {
                if (GetWallpaperChangeFrequency() != WallpaperFrequency.Never)
                {
                    _wallpaperChanger.ChangeWallpaper();
                }
            }
            catch (Exception exception)
            {
                ExceptionHelper.HandleException("Error changing wallpaper", exception);
            }
        }

        /// <summary>
        /// Sets the wallpaper.
        /// </summary>
        private void SetWallpaper()
        {
            try
            {
                var file = FileDialogHelper.OpenSingle("Image Files|*.jpg;*.png;*.bmp", _wallpaperChanger.WallpaperFolder);
                _wallpaperChanger.SetWallpaper(file);
            }
            catch (Exception exception)
            {
                ExceptionHelper.HandleException("Error setting wallpaper", exception);
            }
        }

        /// <summary>
        /// Sets the wallpaper change frequency.
        /// </summary>
        /// <param name="frequency">
        /// The frequency in minutes to change the wallpaper, or 0 for startup only, or -1 for never.
        /// </param>
        private void SetWallpaperChangeFrequency(int frequency)
        {
            if (frequency == WallpaperFrequency.OnStartupOnly
                || frequency == WallpaperFrequency.Never)
            {
                wallpaperTimer.Stop();
                wallpaperTimer.Enabled = false;
            }
            else
            {
                wallpaperTimer.Interval = frequency * 60000;
                if (!wallpaperTimer.Enabled)
                {
                    wallpaperTimer.Start();
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
        private int GetWallpaperChangeFrequency()
        {
            foreach (ToolStripMenuItem menuItem in mnuFrequency.DropDownItems)
            {
                if (menuItem.Checked) return int.Parse(menuItem.Tag.ToString());
            }
            return -1;
        }

        /// <summary>
        /// Displays a file dialog to select the wallpaper image folder.
        /// </summary>
        private void SelectWallpaperFolder()
        {
            var dialog = new FolderBrowserDialog();
            dialog.SelectedPath = _wallpaperChanger.WallpaperFolder;
            dialog.Description = "Select Wallpaper Folder";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _wallpaperChanger.WallpaperFolder = dialog.SelectedPath;
            }
        }

        /// <summary>
        /// Deletes the current wallpaper.
        /// </summary>
        private void DeleteWallpaper()
        {
            var wallpaper = Path.Combine(_wallpaperChanger.WallpaperFolder, _wallpaperChanger.CurrentWallpaperImage);

            if (File.Exists(wallpaper))
            {
                if (MessageBoxHelper.Confirm("Are you sure you wish to delete this wallpaper (" + wallpaper + ")?"))
                {
                    try
                    {
                        File.Delete(wallpaper);
                        ChangeWallpaper();
                    }
                    catch
                    {
                        MessageBoxHelper.ShowError("Could not delete file '" + wallpaper + "'");
                    }
                }
            }
        }

        /// <summary>
        /// Edits the current wallpaper.
        /// </summary>
        private void EditWallpaper()
        {
            var wallpaper = Path.Combine(_wallpaperChanger.WallpaperFolder, _wallpaperChanger.CurrentWallpaperImage);
            if (File.Exists(wallpaper))
            {
                try
                {
                    var process = new Process();
                    process.StartInfo.Verb = "Edit";
                    process.StartInfo.FileName = wallpaper;
                    process.Start();
                }
                catch
                {
                    MessageBoxHelper.ShowError("Could not edit file '" + wallpaper + "'");
                }
            }
        }

        /// <summary>
        /// Opens the current wallpaper.
        /// </summary>
        private void OpenWallpaper()
        {
            var wallpaper = Path.Combine(_wallpaperChanger.WallpaperFolder, _wallpaperChanger.CurrentWallpaperImage);
            if (File.Exists(wallpaper))
            {
                try
                {
                    var process = new Process {StartInfo = {Verb = "Open", FileName = wallpaper}};
                    process.Start();
                }
                catch
                {
                    MessageBoxHelper.ShowError("Could not open file '" + wallpaper + "'");
                }
            }
        }

        /// <summary>
        /// Reloads the wallpaper.
        /// </summary>
        private void ReloadWallpaper()
        {
            try
            {
                _wallpaperChanger.ResetCurrentWallpaper();
            }
            catch
            {
                MessageBoxHelper.ShowError("Could reload wallpaper.");
            }
        }

        #endregion

        #region Internal Classes

        /// <summary>
        /// Wallpaper change frequency constants
        /// </summary>
        private class WallpaperFrequency
        {
            public const int Never = -1;
            public const int OnStartupOnly = 0;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles the Click event of the mnuEvery10Minutes control.
        /// </summary>
        private void mnuEvery10Minutes_Click(object sender, EventArgs e)
        {
            SetWallpaperChangeFrequency(10);
        }

        /// <summary>
        /// Handles the Click event of the mnuEvery15Minutes control.
        /// </summary>
        private void mnuEvery15Minutes_Click(object sender, EventArgs e)
        {
            SetWallpaperChangeFrequency(15);
        }

        /// <summary>
        /// Handles the Click event of the mnuEvery30Minutes control.
        /// </summary>
        private void mnuEvery30Minutes_Click(object sender, EventArgs e)
        {
            SetWallpaperChangeFrequency(30);
        }

        /// <summary>
        /// Handles the Click event of the mnuEvery5Minutes control.
        /// </summary>
        private void mnuEvery5Minutes_Click(object sender, EventArgs e)
        {
            SetWallpaperChangeFrequency(5);
        }

        /// <summary>
        /// Handles the Click event of the mnuEveryHour control.
        /// </summary>
        private void mnuEveryHour_Click(object sender, EventArgs e)
        {
            SetWallpaperChangeFrequency(60);
        }

        /// <summary>
        /// Handles the Click event of the mnuNever control.
        /// </summary>
        private void mnuNever_Click(object sender, EventArgs e)
        {
            SetWallpaperChangeFrequency(WallpaperFrequency.Never);
        }

        /// <summary>
        /// Handles the Click event of the mnuOnStartup control.
        /// </summary>
        private void mnuOnStartup_Click(object sender, EventArgs e)
        {
            SetWallpaperChangeFrequency(WallpaperFrequency.OnStartupOnly);
        }

        /// <summary>
        /// Handles the Click event of the mnuSelectWallpaper control.
        /// </summary>
        private void mnuSelectWallpaper_Click(object sender, EventArgs e)
        {
            SetWallpaper();
        }

        /// <summary>
        /// Handles the Click event of the mnuWallpaperFolder control.
        /// </summary>
        private void mnuWallpaperFolder_Click(object sender, EventArgs e)
        {
            SelectWallpaperFolder();
        }

        /// <summary>
        /// Handles the Click event of the mnuChange control.
        /// </summary>
        private void mnuChange_Click(object sender, EventArgs e)
        {
            ChangeWallpaper();
        }

        /// <summary>
        /// Handles the Tick event of the wallpaperTimer control.
        /// </summary>
        private void wallpaperTimer_Tick(object sender, EventArgs e)
        {
            ChangeWallpaper();
        }

        /// <summary>
        /// Handles the Click event of the mnuApplyMedianFilter control.
        /// </summary>
        private void mnuApplyMedianFilter_Click(object sender, EventArgs e)
        {
            _wallpaperChanger.ApplyMedianFilter = mnuApplyMedianFilter.Checked;
            _wallpaperChanger.ResetCurrentWallpaper();
        }

        /// <summary>
        /// Handles the Click event of the mnuOpenWallpaperFolder control.
        /// </summary>
        private void mnuOpenWallpaperFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_wallpaperChanger.WallpaperFolder))
            {
                Process.Start(_wallpaperChanger.WallpaperFolder);
            }
        }

        /// <summary>
        /// Handles the Click event of the mnuDeleteCurrentWallpaper control.
        /// </summary>
        private void mnuDeleteCurrentWallpaper_Click(object sender, EventArgs e)
        {
            DeleteWallpaper();
        }

        /// <summary>
        /// Handles the Click event of the mnuEditCurrentWallpaper control.
        /// </summary>
        private void mnuEditCurrentWallpaper_Click(object sender, EventArgs e)
        {
            EditWallpaper();
        }

        /// <summary>
        /// Handles the Click event of the mnuOpenCurrentWallpaper control.
        /// </summary>
        private void mnuOpenCurrentWallpaper_Click(object sender, EventArgs e)
        {
            OpenWallpaper();
        }

        /// <summary>
        /// Handles the Click event of the mnuReloadCurrentWallpaper control.
        /// </summary>
        private void mnuReloadCurrentWallpaper_Click(object sender, EventArgs e)
        {
            ReloadWallpaper();
        }

        #endregion

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            mnuChange.Enabled = !_wallpaperChanger.IsSettingWallpaper;
        }

        private void mnuLandscapeOnly_Click(object sender, EventArgs e)
        {
            _wallpaperChanger.LandscapeOnly = mnuLandscapeOnly.Checked;
            _wallpaperChanger.ResetCurrentWallpaper();
        }
    }
}