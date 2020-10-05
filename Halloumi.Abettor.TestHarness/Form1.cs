using System;
using System.Windows.Forms;
using Halloumi.Abettor.Plugins.WallpaperChanger;

namespace Halloumi.Abettor.TestHarness
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private WallpaperChanger _changer;

        private void Form1_Load(object sender, EventArgs e)
        {
            //FileSync sync = new FileSync();

            //var folderSet = new FolderSet();
            //folderSet.SourceFolder = @"E:\Development\";
            //folderSet.DestinationFolder = @"Z:\Development\";

            //sync.FolderSets = new List<FolderSet>();
            //sync.FolderSets.Add(folderSet);

            //sync.SyncFiles();

            //var items = fileSyncPlugin1.GetMenuItems();
            //int count = 0;
            //while (items.Count > 0)
            //{
            //    this.contextMenu.Items.Insert(count, items[0]);
            //    count++;
            //}

            //fileSyncPlugin1.Start();

            _changer = new WallpaperChanger();
            _changer.ApplyMedianFilter = false;
            _changer.WallpaperFolder = @"D:\Documents\Work Stuff\Fam\";
            _changer.SetWallpaper(@"D:\Documents\Work Stuff\Fam\IMG-20150930-WA0004.png");
            _changer.ChangeWallpaper();

            //var items = wallpaperChangerPlugin1.GetMenuItems();
            //int count = 0;
            //while (items.Count > 0)
            //{
            //    this.contextMenu.Items.Insert(count, items[0]);
            //    count++;
            //}

            //wallpaperChangerPlugin1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _changer.ChangeWallpaper();
        }
    }
}