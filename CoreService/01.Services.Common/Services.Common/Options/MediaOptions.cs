using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.Options
{
    public class MediaOptions
    {
        public string Host { get; set; }
        public string LocalUploadUrl { get; set; }
        public string MediaUploadUrl { get; set; }
        public string FolderForWeb { get; set; }
        public string[] PermittedExtensions { get; set; }
        public long SizeLimit { get; set; }
    }
}
