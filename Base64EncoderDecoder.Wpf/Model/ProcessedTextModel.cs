namespace Base64EncoderDecoderWpf.Model
{
    public class ProcessedTextModel
    {
        public string InputText { get; set; }
        public string OutputText { get; set; }

        public void Clear()
        {
            InputText = string.Empty;
            OutputText = string.Empty;
        }
    }
}
