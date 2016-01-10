using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halloumi.Common.Helpers;

namespace Halloumi.Abettor.Plugins.FileSync
{
    public class FolderSet
    {
        public FolderSet()
        {
            this.SourceFolder = "";
            this.DestinationFolder = "";
        }

        public string SourceFolder { get; set; }
        public string DestinationFolder { get; set; }
        public string Description
        {
            get
            {
                if (this.SourceFolder == "" && this.DestinationFolder == "") return "";
                return string.Format("{0} -> {1}",
                    FileSystemHelper.TruncateLongFilename(this.SourceFolder, 15),
                    FileSystemHelper.TruncateLongFilename(this.DestinationFolder, 15));
            }
        }
    }
}
