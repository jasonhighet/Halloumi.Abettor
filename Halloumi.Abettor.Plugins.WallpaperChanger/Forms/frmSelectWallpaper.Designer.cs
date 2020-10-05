using System.ComponentModel;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Halloumi.Common.Windows.Controls;
using Manina.Windows.Forms;

namespace Halloumi.Abettor.Plugins.WallpaperChanger.Forms
{
    partial class frmSelectWallpaper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectWallpaper));
            this.flpButtonsRight = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.beveledLine1 = new Halloumi.Common.Windows.Controls.BeveledLine();
            this.beveledLine2 = new Halloumi.Common.Windows.Controls.BeveledLine();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.imageListView = new Manina.Windows.Forms.ImageListView();
            this.flpButtonsRight.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpButtonsRight
            // 
            this.flpButtonsRight.BackColor = System.Drawing.SystemColors.Control;
            this.flpButtonsRight.Controls.Add(this.btnCancel);
            this.flpButtonsRight.Controls.Add(this.btnOK);
            this.flpButtonsRight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtonsRight.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtonsRight.Location = new System.Drawing.Point(0, 411);
            this.flpButtonsRight.Name = "flpButtonsRight";
            this.flpButtonsRight.Padding = new System.Windows.Forms.Padding(5);
            this.flpButtonsRight.Size = new System.Drawing.Size(516, 42);
            this.flpButtonsRight.TabIndex = 15;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(433, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Values.Text = "&Cancel";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(351, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 25);
            this.btnOK.TabIndex = 6;
            this.btnOK.Values.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // beveledLine1
            // 
            this.beveledLine1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.beveledLine1.Location = new System.Drawing.Point(0, 453);
            this.beveledLine1.Name = "beveledLine1";
            this.beveledLine1.Size = new System.Drawing.Size(516, 2);
            this.beveledLine1.TabIndex = 16;
            // 
            // beveledLine2
            // 
            this.beveledLine2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.beveledLine2.Location = new System.Drawing.Point(0, 409);
            this.beveledLine2.Name = "beveledLine2";
            this.beveledLine2.Size = new System.Drawing.Size(516, 2);
            this.beveledLine2.TabIndex = 17;
            // 
            // tblMain
            // 
            this.tblMain.BackColor = System.Drawing.Color.White;
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.Controls.Add(this.imageListView, 0, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.Padding = new System.Windows.Forms.Padding(10);
            this.tblMain.RowCount = 1;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(516, 409);
            this.tblMain.TabIndex = 18;
            // 
            // imageListView
            // 
            this.imageListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.imageListView.DefaultImage = ((System.Drawing.Image)(resources.GetObject("imageListView.DefaultImage")));
            this.imageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListView.ErrorImage = ((System.Drawing.Image)(resources.GetObject("imageListView.ErrorImage")));
            this.imageListView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageListView.HeaderFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageListView.Location = new System.Drawing.Point(13, 13);
            this.imageListView.Name = "imageListView";
            this.imageListView.Size = new System.Drawing.Size(490, 383);
            this.imageListView.SortColumn = Manina.Windows.Forms.ColumnType.FileName;
            this.imageListView.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.imageListView.TabIndex = 0;
            this.imageListView.SelectionChanged += new System.EventHandler(this.imageListView_SelectionChanged);
            this.imageListView.ItemDoubleClick += new Manina.Windows.Forms.ItemDoubleClickEventHandler(this.imageListView_ItemDoubleClick);
            // 
            // frmSelectWallpaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 455);
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.beveledLine2);
            this.Controls.Add(this.flpButtonsRight);
            this.Controls.Add(this.beveledLine1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelectWallpaper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Wallpaper";
            this.flpButtonsRight.ResumeLayout(false);
            this.tblMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flpButtonsRight;
        private KryptonButton btnCancel;
        private KryptonButton btnOK;
        private BeveledLine beveledLine1;
        private BeveledLine beveledLine2;
        private TableLayoutPanel tblMain;
        private ImageListView imageListView;
    }
}