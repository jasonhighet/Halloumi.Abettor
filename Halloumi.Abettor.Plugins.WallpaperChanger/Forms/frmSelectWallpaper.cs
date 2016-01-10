using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Halloumi.Abettor.Controllers;

namespace Halloumi.Abettor.Plugins.WallpaperChanger.Forms
{
    public partial class frmSelectWallpaper : Halloumi.Common.Windows.Forms.BaseForm
    {
        private WallpaperChanger _wallpaperChanger;

        /// <summary>
        /// Initializes a new instance of the <see cref="frmSelectWallpaper"/> class.
        /// </summary>
        /// <param name="wallpaperController">The wallpaper controller.</param>
        public frmSelectWallpaper(WallpaperChanger wallpaperController)
        {
            InitializeComponent();
            imageListView.SetRenderer(new Manina.Windows.Forms.ImageListViewRenderers.NoirRenderer());
            _wallpaperChanger = wallpaperController;
            AddImagesToList();
        }

        /// <summary>
        /// Add images in folder to the list
        /// </summary>
        private void AddImagesToList()
        {
            imageListView.Items.Clear();
            if (_wallpaperChanger.WallpaperFolder == "") return;

            // add images in folder to list
            List<string> filenames = new List<string>();
            foreach (string file in Directory.GetFiles(_wallpaperChanger.WallpaperFolder))
            {
                string extension = Path.GetExtension(file).ToLower();
                if (extension == ".jpg" || extension == ".png" || extension == ".bmp")
                {
                    filenames.Add(file);
                }
            }
            imageListView.Items.AddRange(filenames.ToArray());

            // select current wallpaper
            foreach (Manina.Windows.Forms.ImageListViewItem item in imageListView.Items)
            {
                if (item.FileName == _wallpaperChanger.CurrentWallpaperImage)
                {
                    item.Selected = true;
                    imageListView.EnsureVisible(item.Index);
                    break;
                }
            }
        }

        /// <summary>
        /// Handles the ItemDoubleClick event of the imageListView control.
        /// Sets the wallpaper to the current image
        /// </summary>
        private void imageListView_ItemDoubleClick(object sender, Manina.Windows.Forms.ItemClickEventArgs e)
        {
            _wallpaperChanger.ChangeWallpaper(e.Item.FileName);
        }

        /// <summary>
        /// Handles the SelectionChanged event of the imageListView control.
        /// Ensures only one images is selected at a time
        /// </summary>
        private void imageListView_SelectionChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < this.imageListView.SelectedItems.Count - 1; i++)
            {
                this.imageListView.SelectedItems[i].Selected = false; 
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// Sets the wallpaper to the current image and closes
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.imageListView.SelectedItems.Count > 0)
            {
                _wallpaperChanger.ChangeWallpaper(this.imageListView.SelectedItems[0].FileName);
            }
            this.Close();
        }

    }
}
