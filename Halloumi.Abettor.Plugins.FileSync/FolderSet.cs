using Halloumi.Common.Helpers;

namespace Halloumi.Abettor.Plugins.FileSync
{
    public class FolderSet
    {
        public FolderSet()
        {
            SourceFolder = "";
            DestinationFolder = "";
        }

        public string SourceFolder { get; set; }
        public string DestinationFolder { get; set; }
        public string Description
        {
            get
            {
                if (SourceFolder == "" && DestinationFolder == "") return "";
                return
                    $"{FileSystemHelper.TruncateLongFilename(SourceFolder, 15)} -> {FileSystemHelper.TruncateLongFilename(DestinationFolder, 15)}";
            }
        }
    }
}
