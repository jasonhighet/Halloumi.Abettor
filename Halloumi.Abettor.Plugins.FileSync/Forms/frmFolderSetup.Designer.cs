namespace Halloumi.Abettor.Plugins.FileSync.Forms
{
    partial class frmFolderSetup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.beveledLine = new Halloumi.Common.Windows.Controls.BeveledLine();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new Halloumi.Common.Windows.Controls.Button();
            this.btnDelete = new Halloumi.Common.Windows.Controls.Button();
            this.btnUpdate = new Halloumi.Common.Windows.Controls.Button();
            this.pnlButtons = new Halloumi.Common.Windows.Controls.Panel();
            this.pnlMain = new Halloumi.Common.Windows.Controls.Panel();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblFolderSet = new Halloumi.Common.Windows.Controls.Label();
            this.cmbFolderSet = new Halloumi.Common.Windows.Controls.ComboBox();
            this.lblSource = new Halloumi.Common.Windows.Controls.Label();
            this.txtSourceFolder = new Halloumi.Common.Windows.Controls.TextBox();
            this.lblDestination = new Halloumi.Common.Windows.Controls.Label();
            this.txtDestinationFolder = new Halloumi.Common.Windows.Controls.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSelectSource = new Halloumi.Common.Windows.Controls.FolderSelectButton();
            this.btnSelectDestination = new Halloumi.Common.Windows.Controls.FolderSelectButton();
            this.flpButtons.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFolderSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // beveledLine
            // 
            this.beveledLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.beveledLine.Location = new System.Drawing.Point(0, 157);
            this.beveledLine.Name = "beveledLine";
            this.beveledLine.Size = new System.Drawing.Size(413, 2);
            this.beveledLine.TabIndex = 25;
            // 
            // flpButtons
            // 
            this.flpButtons.BackColor = System.Drawing.Color.Transparent;
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnDelete);
            this.flpButtons.Controls.Add(this.btnUpdate);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(0, 1);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(5);
            this.flpButtons.Size = new System.Drawing.Size(413, 42);
            this.flpButtons.TabIndex = 16;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(330, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(254, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 25);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(178, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(70, 25);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlButtons.Controls.Add(this.flpButtons);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 159);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(413, 43);
            this.pnlButtons.Style = Halloumi.Common.Windows.Controls.PanelStyle.ButtonStrip;
            this.pnlButtons.TabIndex = 24;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMain.Controls.Add(this.tblMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(413, 157);
            this.pnlMain.Style = Halloumi.Common.Windows.Controls.PanelStyle.Content;
            this.pnlMain.TabIndex = 26;
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tblMain.Controls.Add(this.lblFolderSet, 0, 0);
            this.tblMain.Controls.Add(this.cmbFolderSet, 0, 1);
            this.tblMain.Controls.Add(this.lblSource, 0, 2);
            this.tblMain.Controls.Add(this.txtSourceFolder, 0, 3);
            this.tblMain.Controls.Add(this.lblDestination, 0, 4);
            this.tblMain.Controls.Add(this.txtDestinationFolder, 0, 5);
            this.tblMain.Controls.Add(this.btnSelectSource, 1, 3);
            this.tblMain.Controls.Add(this.btnSelectDestination, 1, 5);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(10, 10);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 6;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tblMain.Size = new System.Drawing.Size(393, 137);
            this.tblMain.TabIndex = 0;
            // 
            // lblFolderSet
            // 
            this.lblFolderSet.AutoSize = true;
            this.lblFolderSet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFolderSet.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFolderSet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFolderSet.Location = new System.Drawing.Point(3, 2);
            this.lblFolderSet.Name = "lblFolderSet";
            this.lblFolderSet.Size = new System.Drawing.Size(335, 13);
            this.lblFolderSet.Style = Halloumi.Common.Windows.Controls.LabelStyle.Caption;
            this.lblFolderSet.TabIndex = 8;
            this.lblFolderSet.Text = "Folder Set:";
            // 
            // cmbFolderSet
            // 
            this.tblMain.SetColumnSpan(this.cmbFolderSet, 2);
            this.cmbFolderSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbFolderSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFolderSet.DropDownWidth = 335;
            this.cmbFolderSet.ErrorProvider = null;
            this.cmbFolderSet.Location = new System.Drawing.Point(3, 18);
            this.cmbFolderSet.Name = "cmbFolderSet";
            this.cmbFolderSet.Size = new System.Drawing.Size(387, 21);
            this.cmbFolderSet.TabIndex = 0;
            this.cmbFolderSet.SelectedIndexChanged += new System.EventHandler(this.cmbFolderSet_SelectedIndexChanged);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSource.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSource.Location = new System.Drawing.Point(3, 47);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(335, 13);
            this.lblSource.Style = Halloumi.Common.Windows.Controls.LabelStyle.Caption;
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "Source Folder:";
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSourceFolder.ErrorMessage = "Please enter a destination folder.";
            this.txtSourceFolder.ErrorProvider = null;
            this.txtSourceFolder.IsRequired = true;
            this.txtSourceFolder.Location = new System.Drawing.Point(3, 63);
            this.txtSourceFolder.MaximumValue = 2147483647;
            this.txtSourceFolder.MinimumValue = -2147483648;
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(335, 20);
            this.txtSourceFolder.TabIndex = 2;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDestination.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDestination.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDestination.Location = new System.Drawing.Point(3, 92);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(335, 13);
            this.lblDestination.Style = Halloumi.Common.Windows.Controls.LabelStyle.Caption;
            this.lblDestination.TabIndex = 3;
            this.lblDestination.Text = "Destination Folder:";
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDestinationFolder.ErrorMessage = "Please enter a source folder.";
            this.txtDestinationFolder.ErrorProvider = this.errorProvider;
            this.txtDestinationFolder.IsRequired = true;
            this.txtDestinationFolder.Location = new System.Drawing.Point(3, 108);
            this.txtDestinationFolder.MaximumValue = 2147483647;
            this.txtDestinationFolder.MinimumValue = -2147483648;
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.Size = new System.Drawing.Size(335, 20);
            this.txtDestinationFolder.TabIndex = 4;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnSelectSource
            // 
            this.btnSelectSource.AssociatedControl = this.txtSourceFolder;
            this.btnSelectSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSelectSource.Location = new System.Drawing.Point(344, 63);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(46, 24);
            this.btnSelectSource.TabIndex = 5;
            this.btnSelectSource.Values.Text = "...";
            // 
            // btnSelectDestination
            // 
            this.btnSelectDestination.AssociatedControl = this.txtDestinationFolder;
            this.btnSelectDestination.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSelectDestination.Location = new System.Drawing.Point(344, 108);
            this.btnSelectDestination.Name = "btnSelectDestination";
            this.btnSelectDestination.Size = new System.Drawing.Size(46, 24);
            this.btnSelectDestination.TabIndex = 6;
            this.btnSelectDestination.Values.Text = "...";
            // 
            // frmFolderSetup
            // 
            this.AllowFormChrome = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 202);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.beveledLine);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFolderSetup";
            this.Text = "Folder Setup";
            this.UseApplicationIcon = true;
            this.flpButtons.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFolderSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Halloumi.Common.Windows.Controls.BeveledLine beveledLine;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private Halloumi.Common.Windows.Controls.Button btnDelete;
        private Halloumi.Common.Windows.Controls.Panel pnlButtons;
        private Halloumi.Common.Windows.Controls.Button btnCancel;
        private Halloumi.Common.Windows.Controls.Button btnUpdate;
        private Halloumi.Common.Windows.Controls.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private Halloumi.Common.Windows.Controls.ComboBox cmbFolderSet;
        private Halloumi.Common.Windows.Controls.Label lblSource;
        private Halloumi.Common.Windows.Controls.TextBox txtSourceFolder;
        private Halloumi.Common.Windows.Controls.Label lblDestination;
        private Halloumi.Common.Windows.Controls.FolderSelectButton btnSelectSource;
        private Halloumi.Common.Windows.Controls.TextBox txtDestinationFolder;
        private Halloumi.Common.Windows.Controls.FolderSelectButton btnSelectDestination;
        private Halloumi.Common.Windows.Controls.Label lblFolderSet;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}