using Microsoft.AspNetCore.WebUtilities;
using System;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace Services.Common.Utilities
{
    public static class EncodeHelpers
    {
        public static Encoding GetEncoding(MultipartSection section)
        {
            var hasMediaTypeHeader = MediaTypeHeaderValue.TryParse(section.ContentType, out var mediaType);

            // UTF-7 is insecure and shouldn't be honored. UTF-8 succeeds in
            // most cases.
            if (!hasMediaTypeHeader || Encoding.UTF7.Equals(mediaType.Encoding))
            {
                return Encoding.UTF8;
            }

            return mediaType.Encoding;
        }
    }
   
}
