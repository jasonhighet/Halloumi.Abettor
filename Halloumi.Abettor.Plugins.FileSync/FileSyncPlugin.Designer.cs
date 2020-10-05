using System.ComponentModel;
using System.Windows.Forms;

namespace Halloumi.Abettor.Plugins.FileSync
{
    partial class FileSyncPlugin
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSyncNow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSync = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFrequency = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNever = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOnStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEvery5Minutes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEvery15Minutes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEvery30Minutes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEveryHour = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEvery4Hours = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuViewLog = new System.Windows.Forms.ToolStripMenuItem();
            this.sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mnuEvery8Hours = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSyncNow,
            this.mnuFileSync,
            this.sep3});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(177, 58);
            // 
            // mnuSyncNow
            // 
            this.mnuSyncNow.Name = "mnuSyncNow";
            this.mnuSyncNow.Size = new System.Drawing.Size(153, 22);
            this.mnuSyncNow.Text = "Sync Files &Now";
            this.mnuSyncNow.Click += new System.EventHandler(this.mnuSyncNow_Click);
            // 
            // mnuFileSync
            // 
            this.mnuFileSync.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFolders,
            this.mnuSep1,
            this.mnuFrequency,
            this.mnuSep2,
            this.mnuViewLog});
            this.mnuFileSync.Name = "mnuFileSync";
            this.mnuFileSync.Size = new System.Drawing.Size(176, 24);
            this.mnuFileSync.Text = "S&ync";
            // 
            // mnuFolders
            // 
            this.mnuFolders.Name = "mnuFolders";
            this.mnuFolders.Size = new System.Drawing.Size(199, 24);
            this.mnuFolders.Text = "Set Sync &Folders";
            this.mnuFolders.Click += new System.EventHandler(this.mnuFolders_Click);
            // 
            // mnuSep1
            // 
            this.mnuSep1.Name = "mnuSep1";
            this.mnuSep1.Size = new System.Drawing.Size(196, 6);
            // 
            // mnuFrequency
            // 
            this.mnuFrequency.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNever,
            this.mnuOnStartup,
            this.mnuEvery5Minutes,
            this.mnuEvery15Minutes,
            this.mnuEvery30Minutes,
            this.mnuEveryHour,
            this.mnuEvery4Hours,
            this.mnuEvery8Hours});
            this.mnuFrequency.Name = "mnuFrequency";
            this.mnuFrequency.Size = new System.Drawing.Size(199, 24);
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
            // mnuEvery4Hours
            // 
            this.mnuEvery4Hours.CheckOnClick = true;
            this.mnuEvery4Hours.Name = "mnuEvery4Hours";
            this.mnuEvery4Hours.Size = new System.Drawing.Size(189, 24);
            this.mnuEvery4Hours.Tag = "240";
            this.mnuEvery4Hours.Text = "Every &4 Hours";
            this.mnuEvery4Hours.Click += new System.EventHandler(this.mnuEvery4Hours_Click);
            // 
            // mnuSep2
            // 
            this.mnuSep2.Name = "mnuSep2";
            this.mnuSep2.Size = new System.Drawing.Size(196, 6);
            // 
            // mnuViewLog
            // 
            this.mnuViewLog.Name = "mnuViewLog";
            this.mnuViewLog.Size = new System.Drawing.Size(199, 24);
            this.mnuViewLog.Text = "&View Log File";
            this.mnuViewLog.Click += new System.EventHandler(this.mnuViewLog_Click);
            // 
            // sep3
            // 
            this.sep3.Name = "sep3";
            this.sep3.Size = new System.Drawing.Size(150, 6);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // mnuEvery8Hours
            // 
            this.mnuEvery8Hours.Name = "mnuEvery8Hours";
            this.mnuEvery8Hours.Size = new System.Drawing.Size(189, 24);
            this.mnuEvery8Hours.Tag = "480";
            this.mnuEvery8Hours.Text = "Every &8 Hours";
            this.mnuEvery8Hours.Click += new System.EventHandler(this.mnuEvery8Hours_Click);
            this.contextMenuStrip.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem mnuFileSync;
        private ToolStripSeparator mnuSep1;
        private ToolStripMenuItem mnuFrequency;
        private ToolStripMenuItem mnuNever;
        private ToolStripMenuItem mnuOnStartup;
        private ToolStripMenuItem mnuEvery5Minutes;
        private ToolStripMenuItem mnuEvery4Hours;
        private ToolStripMenuItem mnuEvery15Minutes;
        private ToolStripMenuItem mnuEvery30Minutes;
        private ToolStripMenuItem mnuEveryHour;
        private Timer timer;
        private ToolStripMenuItem mnuSyncNow;
        private ToolStripSeparator sep3;
        private ToolStripSeparator mnuSep2;
        private ToolStripMenuItem mnuViewLog;
        private ToolStripMenuItem mnuFolders;
        private ToolStripMenuItem mnuEvery8Hours;
    }
}
