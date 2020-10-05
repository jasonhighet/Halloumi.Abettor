using System.ComponentModel;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Halloumi.Abettor.Controllers;
using Halloumi.Common.Windows.Controls;

namespace Halloumi.Abettor.Forms
{
    partial class frmAbettor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbettor));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartWithWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHighCPUColour = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLowCPUColour = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRAMColour = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBackColour = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.colourDialog = new System.Windows.Forms.ColorDialog();
            this.aboutDialog = new Halloumi.Common.Windows.Controls.AboutDialog(this.components);
            this.abettorController = new Halloumi.Abettor.Controllers.AbettorController(this.components);
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout,
            this.mnuSep1,
            this.mnuOptions,
            this.mnuSep2,
            this.mnuExit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(117, 82);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Image = global::Halloumi.Abettor.Properties.Resources.about16;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(116, 22);
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnuSep1
            // 
            this.mnuSep1.Name = "mnuSep1";
            this.mnuSep1.Size = new System.Drawing.Size(113, 6);
            // 
            // mnuOptions
            // 
            this.mnuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStartWithWindows,
            this.mnuSep3,
            this.mnuHighCPUColour,
            this.mnuLowCPUColour,
            this.mnuRAMColour,
            this.mnuBackColour,
            this.mnuSep4});
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(116, 22);
            this.mnuOptions.Text = "Options";
            // 
            // mnuStartWithWindows
            // 
            this.mnuStartWithWindows.Checked = true;
            this.mnuStartWithWindows.CheckOnClick = true;
            this.mnuStartWithWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuStartWithWindows.Name = "mnuStartWithWindows";
            this.mnuStartWithWindows.Size = new System.Drawing.Size(186, 22);
            this.mnuStartWithWindows.Text = "&Start with Windows";
            // 
            // mnuSep3
            // 
            this.mnuSep3.Name = "mnuSep3";
            this.mnuSep3.Size = new System.Drawing.Size(183, 6);
            // 
            // mnuHighCPUColour
            // 
            this.mnuHighCPUColour.Name = "mnuHighCPUColour";
            this.mnuHighCPUColour.Size = new System.Drawing.Size(186, 22);
            this.mnuHighCPUColour.Text = "&High CPU Colour...";
            this.mnuHighCPUColour.Click += new System.EventHandler(this.mnuHighCPUColour_Click);
            // 
            // mnuLowCPUColour
            // 
            this.mnuLowCPUColour.Name = "mnuLowCPUColour";
            this.mnuLowCPUColour.Size = new System.Drawing.Size(186, 22);
            this.mnuLowCPUColour.Text = "&Low CPU Colour...";
            this.mnuLowCPUColour.Click += new System.EventHandler(this.mnuLowCPUColour_Click);
            // 
            // mnuRAMColour
            // 
            this.mnuRAMColour.Name = "mnuRAMColour";
            this.mnuRAMColour.Size = new System.Drawing.Size(186, 22);
            this.mnuRAMColour.Text = "&RAM Colour...";
            this.mnuRAMColour.Click += new System.EventHandler(this.mnuRAMColour_Click);
            // 
            // mnuBackColour
            // 
            this.mnuBackColour.Name = "mnuBackColour";
            this.mnuBackColour.Size = new System.Drawing.Size(186, 22);
            this.mnuBackColour.Text = "&Background Colour...";
            this.mnuBackColour.Click += new System.EventHandler(this.mnuBackColour_Click);
            // 
            // mnuSep4
            // 
            this.mnuSep4.Name = "mnuSep4";
            this.mnuSep4.Size = new System.Drawing.Size(183, 6);
            // 
            // mnuSep2
            // 
            this.mnuSep2.Name = "mnuSep2";
            this.mnuSep2.Size = new System.Drawing.Size(113, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::Halloumi.Abettor.Properties.Resources.exit16;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(116, 22);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Text = "Halloumi Abettor\r\n";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // colourDialog
            // 
            this.colourDialog.AnyColor = true;
            this.colourDialog.FullOpen = true;
            // 
            // aboutDialog
            // 
            this.aboutDialog.Image = global::Halloumi.Abettor.Properties.Resources._139;
            this.aboutDialog.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            // 
            // abettorController
            // 
            this.abettorController.BackColour = System.Drawing.Color.Black;
            this.abettorController.HighCPUColour = System.Drawing.Color.White;
            this.abettorController.LowCPUColour = System.Drawing.Color.MediumBlue;
            this.abettorController.RAMColour = System.Drawing.Color.DarkGray;
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalAllowFormChrome = false;
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Black;
            // 
            // frmAbettor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(174)))), ((int)(((byte)(181)))));
            this.ClientSize = new System.Drawing.Size(2, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAbettor";
            this.Opacity = 0;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAbettor_FormClosing);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip contextMenu;
        private NotifyIcon notifyIcon;
        private Timer timer;
        private ToolStripMenuItem mnuAbout;
        private ToolStripSeparator mnuSep1;
        private ToolStripMenuItem mnuOptions;
        private ToolStripSeparator mnuSep2;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuStartWithWindows;
        private ToolStripSeparator mnuSep3;
        private ToolStripMenuItem mnuHighCPUColour;
        private ToolStripMenuItem mnuLowCPUColour;
        private ToolStripMenuItem mnuBackColour;
        private ColorDialog colourDialog;
        private AbettorController abettorController;
        private AboutDialog aboutDialog;
        private ToolStripMenuItem mnuRAMColour;
        private ToolStripSeparator mnuSep4;
        private KryptonManager kryptonManager;
    }
}

