using System.Windows;

namespace Base64EncoderDecoderWpf.Model
{
    public class EncoderDecoderModel
    {
        public string InputText { get; set; }
        public string OutputEncoded { get; set; }
        public string OutputDecoded { get; set; } 

        public void Clear()
        {
            InputText = string.Empty;
            OutputEncoded = string.Empty;
            OutputDecoded = string.Empty;
        }

        public void Encode()
        {
            OutputEncoded = Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextToBase64(InputText);
        }

        public void Decode()
        {
            OutputDecoded = Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextFromBase64(InputText);
        }

        public void CopyEncoded()
        {
            Clipboard.SetText(OutputEncoded);
        }

        public void CopyDecoded()
        {
            Clipboard.SetText(OutputDecoded);
        }
    }
}
