namespace Halloumi.Abettor.Plugins.WallpaperChanger
{
    partial class WallpaperChangerPlugin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuChange = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWallpaper = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectWallpaper = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuWallpaperFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenWallpaperFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpenCurrentWallpaper = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCurrentWallpaper = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteCurrentWallpaper = new System.Windows.Forms.ToolStripMenuItem();
            this.sep4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuApplyMedianFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFrequency = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNever = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOnStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEvery5Minutes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEvery10Minutes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEvery15Minutes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEvery30Minutes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEveryHour = new System.Windows.Forms.ToolStripMenuItem();
            this.sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.wallpaperTimer = new System.Windows.Forms.Timer(this.components);
            this.mnuReloadCurrentWallpaper = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChange,
            this.mnuWallpaper,
            this.sep3});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(237, 58);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // mnuChange
            // 
            this.mnuChange.Name = "mnuChange";
            this.mnuChange.Size = new System.Drawing.Size(199, 22);
            this.mnuChange.Text = "&Change Wallpaper Now";
            this.mnuChange.Click += new System.EventHandler(this.mnuChange_Click);
            // 
            // mnuWallpaper
            // 
            this.mnuWallpaper.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSelectWallpaper,
            this.mnuSep1,
            this.mnuWallpaperFolder,
            this.mnuOpenWallpaperFolder,
            this.sep2,
            this.mnuOpenCurrentWallpaper,
            this.mnuEditCurrentWallpaper,
            this.mnuDeleteCurrentWallpaper,
            this.mnuReloadCurrentWallpaper,
            this.sep4,
            this.mnuApplyMedianFilter,
            this.mnuFrequency});
            this.mnuWallpaper.Name = "mnuWallpaper";
            this.mnuWallpaper.Size = new System.Drawing.Size(236, 24);
            this.mnuWallpaper.Text = "&Wallpaper";
            // 
            // mnuSelectWallpaper
            // 
            this.mnuSelectWallpaper.Name = "mnuSelectWallpaper";
            this.mnuSelectWallpaper.Size = new System.Drawing.Size(250, 24);
            this.mnuSelectWallpaper.Text = "&Select Wallpaper...";
            this.mnuSelectWallpaper.Click += new System.EventHandler(this.mnuSelectWallpaper_Click);
            // 
            // mnuSep1
            // 
            this.mnuSep1.Name = "mnuSep1";
            this.mnuSep1.Size = new System.Drawing.Size(247, 6);
            // 
            // mnuWallpaperFolder
            // 
            this.mnuWallpaperFolder.Name = "mnuWallpaperFolder";
            this.mnuWallpaperFolder.Size = new System.Drawing.Size(250, 24);
            this.mnuWallpaperFolder.Text = "Set Wallpaper &Folder...";
            this.mnuWallpaperFolder.Click += new System.EventHandler(this.mnuWallpaperFolder_Click);
            // 
            // mnuOpenWallpaperFolder
            // 
            this.mnuOpenWallpaperFolder.Name = "mnuOpenWallpaperFolder";
            this.mnuOpenWallpaperFolder.Size = new System.Drawing.Size(250, 24);
            this.mnuOpenWallpaperFolder.Text = "&Open Wallpaper Folder...";
            this.mnuOpenWallpaperFolder.Click += new System.EventHandler(this.mnuOpenWallpaperFolder_Click);
            // 
            // sep2
            // 
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(247, 6);
            // 
            // mnuOpenCurrentWallpaper
            // 
            this.mnuOpenCurrentWallpaper.Name = "mnuOpenCurrentWallpaper";
            this.mnuOpenCurrentWallpaper.Size = new System.Drawing.Size(250, 24);
            this.mnuOpenCurrentWallpaper.Text = "&Open Current Wallpaper";
            this.mnuOpenCurrentWallpaper.Click += new System.EventHandler(this.mnuOpenCurrentWallpaper_Click);
            // 
            // mnuEditCurrentWallpaper
            // 
            this.mnuEditCurrentWallpaper.Name = "mnuEditCurrentWallpaper";
            this.mnuEditCurrentWallpaper.Size = new System.Drawing.Size(250, 24);
            this.mnuEditCurrentWallpaper.Text = "&Edit Current Wallpaper";
            this.mnuEditCurrentWallpaper.Click += new System.EventHandler(this.mnuEditCurrentWallpaper_Click);
            // 
            // mnuDeleteCurrentWallpaper
            // 
            this.mnuDeleteCurrentWallpaper.Name = "mnuDeleteCurrentWallpaper";
            this.mnuDeleteCurrentWallpaper.Size = new System.Drawing.Size(250, 24);
            this.mnuDeleteCurrentWallpaper.Text = "&Delete Current Wallpaper";
            this.mnuDeleteCurrentWallpaper.Click += new System.EventHandler(this.mnuDeleteCurrentWallpaper_Click);
            // 
            // sep4
            // 
            this.sep4.Name = "sep4";
            this.sep4.Size = new System.Drawing.Size(247, 6);
            // 
            // mnuApplyMedianFilter
            // 
            this.mnuApplyMedianFilter.CheckOnClick = true;
            this.mnuApplyMedianFilter.Name = "mnuApplyMedianFilter";
            this.mnuApplyMedianFilter.Size = new System.Drawing.Size(250, 24);
            this.mnuApplyMedianFilter.Text = "&Apply Median Filter";
            this.mnuApplyMedianFilter.Click += new System.EventHandler(this.mnuApplyMedianFilter_Click);
            // 
            // mnuFrequency
            // 
            this.mnuFrequency.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNever,
            this.mnuOnStartup,
            this.mnuEvery5Minutes,
            this.mnuEvery10Minutes,
            this.mnuEvery15Minutes,
            this.mnuEvery30Minutes,
            this.mnuEveryHour});
            this.mnuFrequency.Name = "mnuFrequency";
            this.mnuFrequency.Size = new System.Drawing.Size(250, 24);
            this.mnuFrequency.Text = "&Change Frequency";
            // 
            // mnuNever
            // 
            this.mnuNever.CheckOnClick = true;
            this.mnuNever.Name = "mnuNever";
            this.mnuNever.Size = new System.Drawing.Size(189, 24);
            this.mnuNever.Tag = "-1";
            this.mnuNever.Text = "&Never";
            this.mnuNever.Click += new System.EventHandler(this.mnuNever_Click);
            // 
            // mnuOnStartup
            // 
            this.mnuOnStartup.CheckOnClick = true;
            this.mnuOnStartup.Name = "mnuOnStartup";
            this.mnuOnStartup.Size = new System.Drawing.Size(189, 24);
            this.mnuOnStartup.Tag = "0";
            this.mnuOnStartup.Text = "On &Startup";
            this.mnuOnStartup.Click += new System.EventHandler(this.mnuOnStartup_Click);
            // 
            // mnuEvery5Minutes
            // 
            this.mnuEvery5Minutes.Checked = true;
            this.mnuEvery5Minutes.CheckOnClick = true;
            this.mnuEvery5Minutes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuEvery5Minutes.Name = "mnuEvery5Minutes";
            this.mnuEvery5Minutes.Size = new System.Drawing.Size(189, 24);
            this.mnuEvery5Minutes.Tag = "5";
            this.mnuEvery5Minutes.Text = "Every &5 Minutes";
            this.mnuEvery5Minutes.Click += new System.EventHandler(this.mnuEvery5Minutes_Click);
            // 
            // mnuEvery10Minutes
            // 
            this.mnuEvery10Minutes.CheckOnClick = true;
            this.mnuEvery10Minutes.Name = "mnuEvery10Minutes";
            this.mnuEvery10Minutes.Size = new System.Drawing.Size(189, 24);
            this.mnuEvery10Minutes.Tag = "10";
            this.mnuEvery10Minutes.Text = "Every &10 Minutes";
            this.mnuEvery10Minutes.Click += new System.EventHandler(this.mnuEvery10Minutes_Click);
            // 
            // mnuEvery15Minutes
            // 
            this.mnuEvery15Minutes.CheckOnClick = true;
            this.mnuEvery15Minutes.Name = "mnuEvery15Minutes";
            this.mnuEvery15Minutes.Size = new System.Drawing.Size(189, 24);
            this.mnuEvery15Minutes.Tag = "15";
            this.mnuEvery15Minutes.Text = "Every &15 Minutes";
            this.mnuEvery15Minutes.Click += new System.EventHandler(this.mnuEvery15Minutes_Click);
            // 
            // mnuEvery30Minutes
            // 
            this.mnuEvery30Minutes.CheckOnClick = true;
            this.mnuEvery30Minutes.Name = "mnuEvery30Minutes";
            this.mnuEvery30Minutes.Size = new System.Drawing.Size(189, 24);
            this.mnuEvery30Minutes.Tag = "30";
            this.mnuEvery30Minutes.Text = "Every &30 Minutes";
            this.mnuEvery30Minutes.Click += new System.EventHandler(this.mnuEvery30Minutes_Click);
            // 
            // mnuEveryHour
            // 
            this.mnuEveryHour.CheckOnClick = true;
            this.mnuEveryHour.Name = "mnuEveryHour";
            this.mnuEveryHour.Size = new System.Drawing.Size(189, 24);
            this.mnuEveryHour.Tag = "60";
            this.mnuEveryHour.Text = "Every &Hour";
            this.mnuEveryHour.Click += new System.EventHandler(this.mnuEveryHour_Click);
            // 
            // sep3
            // 
            this.sep3.Name = "sep3";
            this.sep3.Size = new System.Drawing.Size(196, 6);
            // 
            // wallpaperTimer
            // 
            this.wallpaperTimer.Tick += new System.EventHandler(this.wallpaperTimer_Tick);
            // 
            // mnuReloadCurrentWallpaper
            // 
            this.mnuReloadCurrentWallpaper.Name = "mnuReloadCurrentWallpaper";
            this.mnuReloadCurrentWallpaper.Size = new System.Drawing.Size(250, 24);
            this.mnuReloadCurrentWallpaper.Text = "&Reload Current Wallpaper";
            this.mnuReloadCurrentWallpaper.Click += new System.EventHandler(this.mnuReloadCurrentWallpaper_Click);
            this.contextMenuStrip.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuWallpaper;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectWallpaper;
        private System.Windows.Forms.ToolStripSeparator mnuSep1;
        private System.Windows.Forms.ToolStripMenuItem mnuWallpaperFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuFrequency;
        private System.Windows.Forms.ToolStripMenuItem mnuNever;
        private System.Windows.Forms.ToolStripMenuItem mnuOnStartup;
        private System.Windows.Forms.ToolStripMenuItem mnuEvery5Minutes;
        private System.Windows.Forms.ToolStripMenuItem mnuEvery10Minutes;
        private System.Windows.Forms.ToolStripMenuItem mnuEvery15Minutes;
        private System.Windows.Forms.ToolStripMenuItem mnuEvery30Minutes;
        private System.Windows.Forms.ToolStripMenuItem mnuEveryHour;
        private System.Windows.Forms.Timer wallpaperTimer;
        private System.Windows.Forms.ToolStripMenuItem mnuApplyMedianFilter;
        private System.Windows.Forms.ToolStripMenuItem mnuChange;
        private System.Windows.Forms.ToolStripSeparator sep3;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenWallpaperFolder;
        private System.Windows.Forms.ToolStripSeparator sep2;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCurrentWallpaper;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteCurrentWallpaper;
        private System.Windows.Forms.ToolStripSeparator sep4;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenCurrentWallpaper;
        private System.Windows.Forms.ToolStripMenuItem mnuReloadCurrentWallpaper;
    }
}
