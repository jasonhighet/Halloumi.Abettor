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
        private readonly Random _random;

        /// <summary>
        /// A list of recently displayed wallpapers
        /// </summary>
        private readonly List<string> _recentWallpapers = new List<string>();

        /// <summary>
        /// Set to true when the wallpaper is being set
        /// </summary>
        private bool _settingWallpaper;

        /// <summary>
        /// Delegate for setting the wallpaper asynchronusly
        /// </summary>
        private delegate void SetWallpaperDelegate(string imagePath);

        #endregion

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the WallpaperChanger class.
        /// </summary>
        public WallpaperChanger()
        {
            _random = new Random(DateTime.Now.Millisecond);

            // clear log
            ClearLogFile();
            Log = new StringBuilder();
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
        /// If true, each image will be cropped to fit on screen
        /// </summary>
        public bool CropWallpaper
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether wallpaper is currently being changed.
        /// </summary>
        public bool IsSettingWallpaper => _settingWallpaper;

        /// <summary>
        /// Gets the log.
        /// </summary>
        public StringBuilder Log { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Changes the current desktop wallpaper to a random image from the wallpaper folder.
        /// </summary>
        public void ChangeWallpaper()
        {
            if (WallpaperFolder == "" || !Directory.Exists(WallpaperFolder)) return;

            var newWallpaperImage = GetRandomImage();
            if (newWallpaperImage != "")
            {
                SetWallpaperAsync(newWallpaperImage);
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
            ChangeWallpaper(CurrentWallpaperImage);
        }

        /// <summary>
        /// Clears the log file.
        /// </summary>
        public void ClearLogFile()
        {
            if (File.Exists(GetLogFilename()))
            {
                File.Delete(GetLogFilename());
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
            try
            {
                // get all images in folder
                var allImages = FileSystemHelper.SearchFiles(WallpaperFolder, "*.jpg;*.png;*.bmp", false);

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
            }
            catch
            {
                // ignored
            }

            return "";
        }

        /// <summary>
        /// Sets the current desktop wallpaper to the specified image.
        /// </summary>
        /// <param name="imagePath">The path of the image to set as the wallpaper.</param>
        private void SetWallpaperAsync(string imagePath)
        {
            if (_settingWallpaper) return;

            SetWallpaperDelegate setWallpaper = SetWallpaper;
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
                var cachedImageName = GetCachedImageName(imagePath);

                // generate cached image if one doesn't exist
                if (!File.Exists(cachedImageName))
                {
                    var desktopSize = DesktopHelper.GetPrimaryDesktopSize();
                    var image = Image.FromFile(imagePath);
                    ExifRotate(image);

                    Image wallpaper;

                    var cropWallpaper = CropWallpaper;
                    if (desktopSize.Width > desktopSize.Height && image.Width > image.Height)
                        cropWallpaper = true;
                    else if (desktopSize.Width < desktopSize.Height && image.Width < image.Height)
                        cropWallpaper = true;

                    if (cropWallpaper)
                    {
                        wallpaper = ImageHelper.ScaleAndCropImageToFit(image, desktopSize);
                    }
                    else
                    {
                        var smallDesktopSize = new Size(desktopSize.Width / 4, desktopSize.Height / 4);
                        var scaledBackgroundImage = ImageHelper.ScaleAndCropImageToFit(image, smallDesktopSize);
                        var darkBackgroundImage = ImageHelper.DarkenImage(scaledBackgroundImage, 0.5);
                        var blurredBackgroundImage = ImageHelper.BlurFilter(darkBackgroundImage, 10);

                        wallpaper = ImageHelper.ScaleAndCropImageToFit(blurredBackgroundImage, desktopSize);

                        var scaledImage = ImageHelper.ScaleImageToFit(image, desktopSize);

                        using (var graphics = Graphics.FromImage(wallpaper))
                        {
                            var x = (desktopSize.Width - scaledImage.Width) / 2;
                            var y = (desktopSize.Height - scaledImage.Height) / 2;
                            var imageLocation = new Point(x, y);
                            graphics.DrawImage(scaledImage, imageLocation);
                        }

                        scaledImage.Dispose();
                        scaledBackgroundImage.Dispose();
                        blurredBackgroundImage.Dispose();
                        darkBackgroundImage.Dispose();
                    }

                    if (ApplyMedianFilter)
                    {
                        using (var medianImage = ImageHelper.MedianFilter(wallpaper, 4))
                        {
                            medianImage.Save(cachedImageName, ImageFormat.Jpeg);
                        }
                    }
                    else
                    {
                        wallpaper.Save(cachedImageName, ImageFormat.Jpeg);
                    }


                    wallpaper.Dispose();

                    image.Dispose();

                    
                }

                // get name for wallpaper bitmap in temp folder
                var wallpaperPath = Path.Combine(Path.GetTempPath(), "Wallpaper.bmp");

                // save cached image as wallpaper file and set as current wallpaper
                using (var image = Image.FromFile(cachedImageName))
                {
                    image.Save(wallpaperPath, ImageFormat.Bmp);
                }
                WallpaperHelper.SetWallpaper(wallpaperPath);

                // set as recent wallpaper
                CurrentWallpaperImage = imagePath;
                AddToRecentWallpaperList(imagePath);
            }
            catch (Exception e)
            {
                var message = $"Error setting wallpaper'{imagePath}'\r\n{e}";
                AddLogEntry(message);
                SaveLog();
            }
            finally
            {
                _settingWallpaper = false;
            }
        }

        public static void ExifRotate(Image image)
        {
            const int exifOrientationID = 0x112;

            if (!image.PropertyIdList.Contains(exifOrientationID))
                return;

            var property = image.GetPropertyItem(exifOrientationID);
            int propertyValue = BitConverter.ToUInt16(property.Value, 0);

            var rotate = RotateFlipType.RotateNoneFlipNone;

            if (propertyValue == 3 || propertyValue == 4)
                rotate = RotateFlipType.Rotate180FlipNone;
            else if (propertyValue == 5 || propertyValue == 6)
                rotate = RotateFlipType.Rotate90FlipNone;
            else if (propertyValue == 7 || propertyValue == 8)
                rotate = RotateFlipType.Rotate270FlipNone;

            if (propertyValue == 2 || propertyValue == 4 || propertyValue == 5 || propertyValue == 7)
                rotate |= RotateFlipType.RotateNoneFlipX;

            if (rotate != RotateFlipType.RotateNoneFlipNone)
                image.RotateFlip(rotate);
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
            var desktopSize = DesktopHelper.GetPrimaryDesktopSize();

            var imageName = Path.GetFileNameWithoutExtension(imagePath)
                + "."
                + desktopSize.Width
                + "x"
                + desktopSize.Height
                + "."
                + File.GetLastWriteTime(imagePath).ToString("yyyyMMddhhmmss");

            if (ApplyMedianFilter)
            {
                imageName += ".filtered";
            }

            if (CropWallpaper)
            {
                imageName += ".cropped";
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
                File.WriteAllText(GetLogFilename(), Log.ToString());
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// Adds an entry to the log
        /// </summary>
        /// <param name="message">The message.</param>
        private void AddLogEntry(string message)
        {
            try
            {
                Log.AppendLine(message);
                Debug.WriteLine(message);
            }
            catch
            {
                // ignored
            }
        }

        #endregion
    }
}