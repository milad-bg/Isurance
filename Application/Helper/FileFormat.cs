using System;
using System.Collections.Generic;

namespace Application.Helper
{
    public static class FileFormat
    {
        private static IDictionary<string, string> _mappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) {

        #region Big freaking list of mime types for video and image
      
        {".art", "image/x-jg"},
        {".bmp", "image/bmp"},
        {".cmx", "image/x-cmx"},
        {".cod", "image/cis-cod"},
        {".dib", "image/bmp"},
        {".ico", "image/x-icon"},
        {".ief", "image/ief"},
        {".jfif", "image/pjpeg"},
        {".jpe", "image/jpeg"},
        {".jpeg", "image/jpeg"},
        {".jpg", "image/jpeg"},
        {".mac", "image/x-macpaint"},
        {".pbm", "image/x-portable-bitmap"},
        {".pct", "image/pict"},
        {".pgm", "image/x-portable-graymap"},
        {".pic", "image/pict"},
        {".pict", "image/pict"},
        {".png", "image/png"},
        {".pnm", "image/x-portable-anymap"},
        {".pnt", "image/x-macpaint"},
        {".pntg", "image/x-macpaint"},
        {".pnz", "image/png"},
        {".ppm", "image/x-portable-pixmap"},
        {".qti", "image/x-quicktime"},
        {".qtif", "image/x-quicktime"},
        {".ras", "image/x-cmu-raster"},
        {".rf", "image/vnd.rn-realflash"},
        {".rgb", "image/x-rgb"},
        {".tif", "image/tiff"},
        {".tiff", "image/tiff"},
        {".wdp", "image/vnd.ms-photo"},
        {".xbm", "image/x-xbitmap"},
        {".xpm", "image/x-xpixmap"},
        {".xwd", "image/x-xwindowdump"},
        {".wbmp", "image/vnd.wap.wbmp"},
        {".qt", "video/quicktime"},
        {".IVF", "video/x-ivf"},
        {".3g2", "video/3gpp2"},
        {".3gp", "video/3gpp"},
        {".3gp2", "video/3gpp2"},
        {".3gpp", "video/3gpp"},
        {".asf", "video/x-ms-asf"},
        {".asr", "video/x-ms-asf"},
        {".asx", "video/x-ms-asf"},
        {".avi", "video/x-msvideo"},
        {".dif", "video/x-dv"},
        {".dv", "video/x-dv"},
        {".flv", "video/x-flv"},
        {".lsx", "video/x-la-asf"},
        {".m1v", "video/mpeg"},
        {".m2t", "video/vnd.dlna.mpeg-tts"},
        {".m2ts", "video/vnd.dlna.mpeg-tts"},
        {".m2v", "video/mpeg"},
        {".m4v", "video/x-m4v"},
        {".mod", "video/mpeg"},
        {".mov", "video/quicktime"},
        {".movie", "video/x-sgi-movie"},
        {".mp2", "video/mpeg"},
        {".mp2v", "video/mpeg"},
        {".mp4", "video/mp4"},
        {".mp4v", "video/mp4"},
        {".mpa", "video/mpeg"},
        {".mpe", "video/mpeg"},
        {".mpeg", "video/mpeg"},
        {".mpg", "video/mpeg"},
        {".mpv2", "video/mpeg"},
        {".mqv", "video/quicktime"},
        {".mts", "video/vnd.dlna.mpeg-tts"},
        {".nsc", "video/x-ms-asf"},
        {".ts", "video/vnd.dlna.mpeg-tts"},
        {".tts", "video/vnd.dlna.mpeg-tts"},
        {".vbk", "video/mpeg"},
        {".wm", "video/x-ms-wm"},
        {".wmp", "video/x-ms-wmp"},
        {".wmv", "video/x-ms-wmv"},
        {".wmx", "video/x-ms-wmx"},
        {".wvx", "video/x-ms-wvx"},
        {".pdf", "application/pdf"},

        #endregion
        
        };

        public static string GetMimeType(string extension)
        {
            if (extension == null)
                throw new ArgumentNullException("extension");

            if (!extension.StartsWith("."))
                extension = "." + extension;

            if (_mappings.TryGetValue(extension, out string mime))
                return mime;

            return "application/octet-stream";
        }
    }
}
