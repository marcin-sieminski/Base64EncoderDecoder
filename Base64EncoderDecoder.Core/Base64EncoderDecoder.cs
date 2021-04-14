﻿using System;
using System.Text;

namespace Base64EncoderDecoderCore
{
    public static class Base64EncoderDecoder
    {
        public static string ConvertTextToBase64(string inputText)
        {
            var originalBytes = Encoding.Default.GetBytes(inputText);
            return Convert.ToBase64String(originalBytes);
        }

        public static string ConvertTextFromBase64(string encodedText)
        {
            var outputBytes = new Span<byte>();
            if (!Convert.TryFromBase64String(encodedText, outputBytes, out int bytesWritten))
            {
                return string.Empty;
            }
            return Encoding.Default.GetString(outputBytes);
        }
    }
}
