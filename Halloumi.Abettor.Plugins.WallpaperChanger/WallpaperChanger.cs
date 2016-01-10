using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using Halloumi.Common.Helpers;
using Halloumi.Common.Windows.Helpers;

namespace Halloumi.Abettor.Plugins.WallpaperChanger
{
    public class WallpaperChanger
    {
        #region Private Variables

        /// <summary>
        /// Random number generator
        /// </summary>
        private Random _random = null;

        /// <summary>
        /// A list of recently displayed wallpapers
        /// </summary>
        private List<string> _recentWallpapers = new List<string>();

        /// <summary>
        /// Set to true when the wallpaper is being set
        /// </summary>
        private bool _settingWallpaper = false;

        /// <summary>
        /// Delegate for setting the wallpaper asynchronusly
        /// </summary>
        private delegate void SetWallpaperDelegate(string imagePath);

        #endregion

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WallpaperChangerController"/> class.
        /// </summary>
        public WallpaperChanger()
        {
            _random = new Random(DateTime.Now.Millisecond);

            // clear log
            ClearLogFile();
            this.Log = new StringBuilder();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the folder to load wallpaper images from.
        /// </summary>
        public string WallpaperFolder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the last wallpaper image set.
        /// </summary>
        public string CurrentWallpaperImage
        {
            get;
            private set;
        }

        /// <summary>
        /// If true, a median filter should be applied to each image
        /// </summary>
        public bool ApplyMedianFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether wallpaper is currently being changed.
        /// </summary>
        public bool IsSettingWallpaper
        {
            get { return _settingWallpaper; }
        }

        /// <summary>
        /// Gets the log.
        /// </summary>
        public StringBuilder Log { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Changes the current desktop wallpaper to a random image from the wallpaper folder.
        /// </summary>
        public void ChangeWallpaper()
        {
            if (this.WallpaperFolder != "" && Directory.Exists(this.WallpaperFolder))
            {
                string newWallpaperImage = GetRandomImage();
                if (newWallpaperImage != "")
                {
                    SetWallpaperAsync(newWallpaperImage);
                }
            }
        }

        /// <summary>
        /// Changes the current desktop wallpaper to the specified wallpaper
        /// </summary>
        public void ChangeWallpaper(string wallpaperImage)
        {
            if (File.Exists(wallpaperImage))
            {
                SetWallpaperAsync(wallpaperImage);
            }
        }

        /// <summary>
        /// Resets the current wallpaper.
        /// </summary>
        public void ResetCurrentWallpaper()
        {
            this.ChangeWallpaper(this.CurrentWallpaperImage);
        }

        /// <summary>
        /// Clears the log file.
        /// </summary>
        public void ClearLogFile()
        {
            if (File.Exists(this.GetLogFilename()))
            {
                File.Delete(this.GetLogFilename());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns the path of a random image in the wallpaper folder.
        /// </summary>
        /// <returns>The path of a random image in the wallpaper folder</returns>
        private string GetRandomImage()
        {
            //try
            //{
            // get all images in folder
            var allImages = FileSystemHelper.SearchFiles(this.WallpaperFolder, "*.jpg;*.png;*.bmp", false);

            // get images except ones already displayed
            var images = allImages.Except(_recentWallpapers).ToList();

            // if none left, clear already-displayed list
            if (images.Count == 0)
            {
                _recentWallpapers.Clear();
                images = allImages;
            }

            // return a random image
            if (images.Count > 0)
            {
                return images[_random.Next(0, images.Count - 1)];
            }
            //}
            //catch
            //{ }

            return "";
        }

        /// <summary>
        /// Sets the current desktop wallpaper to the specified image.
        /// </summary>
        /// <param name="imagePath">The path of the image to set as the wallpaper.</param>
        private void SetWallpaperAsync(string imagePath)
        {
            if (_settingWallpaper) return;

            SetWallpaperDelegate setWallpaper = new SetWallpaperDelegate(this.SetWallpaper);
            setWallpaper.BeginInvoke(imagePath, null, null);
        }

        /// <summary>
        /// Sets the current desktop wallpaper to the specified image.
        /// </summary>
        /// <param name="imagePath">The path of the image to set as the wallpaper.</param>
        public void SetWallpaper(string imagePath)
        {
            if (_settingWallpaper) return;
            if (!File.Exists(imagePath)) return;

            _settingWallpaper = true;

            try
            {
                // get name cached
                string cachedImageName = GetCachedImageName(imagePath);

                // generate cached image if one doesn't exist
                if (!File.Exists(cachedImageName))
                {
                    Size desktopSize = DesktopHelper.GetPrimaryDesktopSize();
                    using (Image image = Image.FromFile(imagePath))
                    using (Image scaledImage = ImageHelper.ScaleAndCropImageToFit(image, desktopSize))
                    {
                        if (this.ApplyMedianFilter)
                        {
                            using (Image medianImage = ImageHelper.MedianFilter(scaledImage, 4))
                            {
                                medianImage.Save(cachedImageName, ImageFormat.Jpeg);
                            }
                        }
                        else
                        {
                            scaledImage.Save(cachedImageName, ImageFormat.Jpeg);
                        }
                    }
                }

                // get name for wallpaper bitmap in temp folder
                string wallpaperPath = Path.Combine(Path.GetTempPath(), "Wallpaper.bmp");

                // save cached image as wallpaper file and set as current wallpaper
                using (Image image = Image.FromFile(cachedImageName))
                {
                    image.Save(wallpaperPath, ImageFormat.Bmp);
                }
                WallpaperHelper.SetWallpaper(wallpaperPath);

                // set as recent wallpaper
                this.CurrentWallpaperImage = imagePath;
                AddToRecentWallpaperList(imagePath);
            }
            catch (Exception e)
            {
                string message = String.Format("Error setting wallpaper'{0}'\r\n{1}", imagePath, e);
                AddLogEntry(message);
                SaveLog();
            }
            finally
            {
                _settingWallpaper = false;
            }
        }

        /// <summary>
        /// Adds an image to the recent wallpaper list.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        private void AddToRecentWallpaperList(string imagePath)
        {
            if (!_recentWallpapers.Contains(imagePath))
            {
                _recentWallpapers.Add(imagePath);
            }
        }

        /// <summary>
        /// Gets the name for the cached version of the specified image.
        /// </summary>
        /// <param name="imagePath">The image path to cache.</param>
        /// <returns>The name of the associated cached image</returns>
        private string GetCachedImageName(string imagePath)
        {
            Size desktopSize = DesktopHelper.GetPrimaryDesktopSize();

            string imageName = Path.GetFileNameWithoutExtension(imagePath)
                + "."
                + desktopSize.Width.ToString()
                + "x"
                + desktopSize.Height.ToString()
                + "."
                + File.GetLastWriteTime(imagePath).ToString("yyyyMMddhhmmss");

            if (this.ApplyMedianFilter)
            {
                imageName += ".filtered";
            }

            imageName += ".jpg";

            return Path.Combine(Path.GetTempPath(), imageName);
        }

        /// <summary>
        /// Returns the filename of the log file
        /// </summary>
        /// <returns>The filename of the log file</returns>
        private string GetLogFilename()
        {
            return Path.Combine(Path.GetTempPath(), "FileSync.Log.txt");
        }

        /// <summary>
        /// Saves the log entries to a text file
        /// </summary>
        private void SaveLog()
        {
            try
            {
                File.WriteAllText(this.GetLogFilename(), this.Log.ToString());
            }
            catch
            { }
        }

        /// <summary>
        /// Adds an entry to the log
        /// </summary>
        /// <param name="message">The message.</param>
        private void AddLogEntry(string message)
        {
            try
            {
                this.Log.AppendLine(message);
                Debug.WriteLine(message);
            }
            catch
            { }
        }

        #endregion
    }
}