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
    }
}
