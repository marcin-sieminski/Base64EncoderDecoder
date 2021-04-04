using System;
using System.IO;
using System.Text;

namespace Base64EncoderDecoderCore
{
    public static class Base64EncoderDecoder
    {
        public static void ConvertFileToBase64(string inputFileName, string encodedFileName)
        {
            var originalBytes = File.ReadAllBytes(inputFileName);
            var base64String = Convert.ToBase64String(originalBytes);
            File.WriteAllText(encodedFileName, base64String);
        }

        public static void ConvertFileFromBase64(string encodedFileName, string decodedFileName)
        {
            var base64String = File.ReadAllText(encodedFileName);
            var fileBytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(decodedFileName, fileBytes);
        }
        public static string ConvertTextToBase64(string inputText)
        {
            var originalBytes = Encoding.Default.GetBytes(inputText);
            return Convert.ToBase64String(originalBytes);
        }

        public static string ConvertTextFromBase64(string encodedText)
        {
            byte[] outputBytes;
            try
            {
                outputBytes = Convert.FromBase64String(encodedText);
            }
            catch (FormatException)
            {
                return "Invalid input: the length of the input is not a multiple of 4.";
            }
            return Encoding.Default.GetString(outputBytes);
        }
    }
}
