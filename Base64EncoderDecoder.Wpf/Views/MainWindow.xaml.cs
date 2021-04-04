using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Input;
using Base64EncoderDecoderWpf.ViewModels;

namespace Base64EncoderDecoderWpf.Views
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void encode_Click_1(object sender, RoutedEventArgs e)
        {
            if (InputTextBox.Text.Length >= 1)
            {
                var processedText = new ProcessedTextViewModel {InputText = InputTextBox.Text};
                processedText.OutputText =
                    Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextToBase64(processedText.InputText);
                OutputTextBox.Text = processedText.OutputText;
            }
        }

        private void decode_Click(object sender, RoutedEventArgs e)
        {
            if (InputTextBox.Text.Length >= 1)
            {
                var processedText = new ProcessedTextViewModel {InputText = InputTextBox.Text};
                processedText.OutputText =
                    Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextFromBase64(processedText.InputText);
                if (processedText.OutputText == "")
                {
                    OutputTextBox.Text = "Invalid input - the length of the input is not a multiple of 4.";
                }

                OutputTextBox.Text = processedText.OutputText;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Text = "";
            OutputTextBox.Text = "";
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
