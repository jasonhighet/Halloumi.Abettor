using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FlimFlan.IconEncoder;
using Halloumi.Abettor.Helpers;
using Halloumi.Abettor.Plugins;
using Halloumi.Abettor.Properties;
using Halloumi.Common.Helpers;
using Halloumi.Common.Windows.Forms;

namespace Halloumi.Abettor.Forms
{
    /// <summary>
    /// Hidden form containing components used by the CPU monitor
    /// </summary>
    public partial class frmAbettor : BaseForm
    {
        private readonly List<IPlugin> _plugins;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="frmAbettor"/> class.
        /// </summary>
        public frmAbettor()
        {
            InitializeComponent();
            
            Hide();
            LoadSettings();
            timer.Start();

            _plugins = PluginHelper<IPlugin>.LoadPlugins();
            var count = 0;
            foreach (var plugin in _plugins)
            {
                var items = plugin.GetMenuItems();
                while (items.Count > 0)
                {
                    contextMenu.Items.Insert(2 + count, items[0]);
                    count++;
                }
                plugin.Start();
            }
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
                abettorController.BackColour = Settings.Default.BackColour;
                abettorController.LowCPUColour = Settings.Default.LowCPUColour;
                abettorController.HighCPUColour = Settings.Default.HighCPUColour;
                abettorController.RAMColour = Settings.Default.RAMColour;
                mnuStartWithWindows.Checked = ApplicationHelper.StartWithWindows;
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
                Settings.Default.BackColour = abettorController.BackColour;
                Settings.Default.LowCPUColour = abettorController.LowCPUColour;
                Settings.Default.HighCPUColour = abettorController.HighCPUColour;
                Settings.Default.RAMColour = abettorController.RAMColour;
                ApplicationHelper.StartWithWindows = mnuStartWithWindows.Checked;
                Settings.Default.Save();
            }
            catch (Exception exception)
            {
                ExceptionHelper.HandleException("Error saving settings", exception);
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles the Click event of the mnuHighCPUColour control.
        /// Lets the user select the high color of the histogram gradient
        /// </summary>
        private void mnuHighCPUColour_Click(object sender, EventArgs e)
        {
            // show color dialog for high color of histogram gradient
            colourDialog.Color = abettorController.HighCPUColour;
            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                abettorController.HighCPUColour = colourDialog.Color;
            }
        }

        /// <summary>
        /// Handles the Click event of the mnuLowCPUColour control.
        /// Lets the user select the low color of the histogram gradient
        /// </summary>
        private void mnuLowCPUColour_Click(object sender, EventArgs e)
        {
            // show color dialog for low color of histogram gradient
            colourDialog.Color = abettorController.LowCPUColour;
            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                abettorController.LowCPUColour = colourDialog.Color;
            }
        }

        /// <summary>
        /// Handles the Click event of the mnuBackColour control.
        /// Lets the user select the background color of the histogram
        /// </summary>
        private void mnuBackColour_Click(object sender, EventArgs e)
        {
            // show color dialog for background color of histogram
            colourDialog.Color = abettorController.BackColour;
            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                abettorController.BackColour = colourDialog.Color;
            }
        }

        /// <summary>
        /// Handles the Click event of the mnuRAMColour control.
        /// </summary>
        private void mnuRAMColour_Click(object sender, EventArgs e)
        {
            // show color dialog for memory color of histogram
            colourDialog.Color = abettorController.RAMColour;
            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                abettorController.RAMColour = colourDialog.Color;
            }

        }

        /// <summary>
        /// Handles the Click event of the mnuExit control.
        /// Stops the timer, saves settings, and exits.
        /// </summary>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// Called every second to update the current notification icon with newly generated histogram
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                abettorController.UpdateValues();

                // generate bitmap from monitor values
                using (var bitmap = abettorController.GenerateBitmap())
                {
                    // get old icon
                    var previousIcon = notifyIcon.Icon;
                    
                    // set new icon
                    notifyIcon.Icon = Converter.BitmapToIcon(bitmap);

                    // dispose of old icon resources
                    if (previousIcon != null) previousIcon.Dispose();
                }

                // update icon tooltip
                notifyIcon.Text = abettorController.Text;
            }
            catch(Exception exception)
            {
                ExceptionHelper.HandleException(exception);
                Close();
            }
        }

        /// <summary>
        /// Handles the Click event of the mnuAbout control.
        /// Displays application info in message box
        /// </summary>
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            aboutDialog.Show();
        }

        /// <summary>
        /// Handles the DoubleClick event of the notifyIcon control.
        /// </summary>
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                abettorController.LaunchTaskManager();
            }
            catch(Exception exception)
            {
                ExceptionHelper.HandleException(exception);
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the frmAbettor control.
        /// </summary>
        private void frmAbettor_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            foreach (var plugin in _plugins)
            {
                plugin.Stop();
            }
            SaveSettings();
        }

        #endregion
    }
}