using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Input;

namespace Base64EncoderDecoderWpf
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void encode_Click_1(object sender, RoutedEventArgs e)
        {
            if (inputTextBox.Text.Length >= 1)
            {
                var processedText = new ProcessedTextModel {InputText = inputTextBox.Text};
                processedText.OutputText =
                    Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextToBase64(processedText.InputText);
                outputTextBox.Text = processedText.OutputText;
            }
        }

        private void decode_Click(object sender, RoutedEventArgs e)
        {
            if (inputTextBox.Text.Length >= 1)
            {
                var processedText = new ProcessedTextModel {InputText = inputTextBox.Text};
                processedText.OutputText =
                    Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextFromBase64(processedText.InputText);
                if (processedText.OutputText == "")
                {
                    outputTextBox.Text = "Invalid input - the length of the input is not a multiple of 4.";
                }

                outputTextBox.Text = processedText.OutputText;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "";
            outputTextBox.Text = "";
        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    encode_Click_1(sender, e);
                    break;
                case Key.Escape:
                    Button_Click(sender, e);
                    break;
            }
        }
    }
}
