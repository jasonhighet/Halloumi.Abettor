using System;
using System.Collections.Generic;
using System.Linq;
using Halloumi.Abettor.Plugins.FileSync.Helpers;
using Halloumi.Abettor.Plugins.FileSync.Properties;
using Halloumi.Common.Helpers;
using Halloumi.Common.Windows.Forms;

namespace Halloumi.Abettor.Plugins.FileSync.Forms
{
    public partial class frmFolderSetup : BaseForm
    {
        /// <summary>
        /// Initializes a new instance of the frmFolderSetup class.
        /// </summary>
        public frmFolderSetup()
        {
            InitializeComponent();
            LoadFolderSets();
            BindData();
        }

        /// <summary>
        /// Binds the data.
        /// </summary>
        private void BindData()
        {
            _bindingData = true;

            var oldIndex = cmbFolderSet.SelectedIndex;
            
            cmbFolderSet.Items.Clear();
            cmbFolderSet.Items.Add("New folder set...");
            foreach (var folderSet in FolderSets)
            {
                cmbFolderSet.Items.Add(folderSet.Description);
            }

            cmbFolderSet.SelectedIndex = 0;
            if (oldIndex > 0 && oldIndex < cmbFolderSet.Items.Count)
            {
                cmbFolderSet.SelectedIndex = oldIndex;
            }
            else if (FolderSets.Count > 0) 
            {
                cmbFolderSet.SelectedIndex = 1;
            }

            BindCurrentFolderSet();

            _bindingData = false;
        }
        private bool _bindingData;

        /// <summary>
        /// Binds the current folder set.
        /// </summary>
        private void BindCurrentFolderSet()
        {
            var folderSet = CurrentFolderSet;

            if (folderSet == null)
            {
                txtDestinationFolder.Text = "";
                txtSourceFolder.Text = "";
            }
            else
            {
                txtDestinationFolder.Text = folderSet.DestinationFolder;
                txtSourceFolder.Text = folderSet.SourceFolder;
            }

            btnDelete.Visible = (CurrentFolderSet != null);
        }

        /// <summary>
        /// Loads the folder sets.
        /// </summary>
        private void LoadFolderSets()
        {
            try
            {
                var xml = Settings.Default.FolderSets;
                FolderSets = SerializationHelper<List<FolderSet>>.FromXmlString(xml);
            }
            catch 
            {
                FolderSets = new List<FolderSet>();
            }
        }

        /// <summary>
        /// Updates the data.
        /// </summary>
        private void UpdateData()
        {
            var folderSet = CurrentFolderSet;

            if (folderSet == null)
            {
                var newFolderSet = new FolderSet();
                newFolderSet.DestinationFolder = txtDestinationFolder.Text;
                newFolderSet.SourceFolder = txtSourceFolder.Text;
                FolderSets.Add(newFolderSet);
            }
            else
            {
                folderSet.DestinationFolder = txtDestinationFolder.Text;
                folderSet.SourceFolder = txtSourceFolder.Text;
            }
            BindData();
        }

        /// <summary>
        /// Saves the folder sets.
        /// </summary>
        private void SaveFolderSets()
        {
            try
            {
                var xml = SerializationHelper<List<FolderSet>>.ToXmlString(FolderSets);
                Settings.Default.FolderSets = xml;
                Settings.Default.Save();
            }
            catch (Exception exception)
            {
                ExceptionHelper.HandleException("Error saving settings", exception);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!txtDestinationFolder.IsValid() || !txtSourceFolder.IsValid()) return;
            UpdateData();
            SaveFolderSets();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            BindCurrentFolderSet();
        }

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            FolderSets.Remove(CurrentFolderSet);
            SaveFolderSets();
            BindData();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbFolderSet control.
        /// </summary>
        private void cmbFolderSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_bindingData) return;
            BindCurrentFolderSet();
        }

        /// <summary>
        /// Gets or sets the folder sets.
        /// </summary>
        private List<FolderSet> FolderSets { get; set; }

        /// <summary>
        /// Gets the current folder set.
        /// </summary>
        private FolderSet CurrentFolderSet 
        {
            get 
            { 
                return FolderSets
                    .Where(fs => fs.Description == cmbFolderSet.Text)
                    .FirstOrDefault(); 
            }
        }
    }
}
