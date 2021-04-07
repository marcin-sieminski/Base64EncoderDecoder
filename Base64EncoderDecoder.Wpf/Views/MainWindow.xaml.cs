using Base64EncoderDecoderWpf.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Base64EncoderDecoderWpf.Views
{
    public partial class MainWindow
    {
        public ProcessedTextViewModel ProcessedTextViewModel { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ProcessedTextViewModel;
        }

        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsInvalidInputLength()) return;
            InputError.Content = string.Empty;
            ProcessedTextViewModel.InputText = InputTextBox.Text;
            ProcessedTextViewModel.OutputText = Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextToBase64(ProcessedTextViewModel.InputText);
            OutputTextBox.Text = ProcessedTextViewModel.OutputText;
        }

        private void DecodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsInvalidInputLength()) return;
            if (InputTextBox.Text.Length % 4 != 0)
            {
                InputError.Content = "The input's length must be a multiple of 4";
                return;
            }
            InputError.Content = string.Empty;
            ProcessedTextViewModel.InputText = InputTextBox.Text;
            ProcessedTextViewModel.OutputText = Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextFromBase64(ProcessedTextViewModel.InputText);
            OutputTextBox.Text = ProcessedTextViewModel.OutputText ?? string.Empty;
        }

        private bool IsInvalidInputLength()
        {
            if (InputTextBox.Text.Length >= 1) return false;
            InputError.Content = "The input is empty";
            return true;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Text = string.Empty;
            OutputTextBox.Text = string.Empty;
            InputError.Content = string.Empty;
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    EncodeButton_Click(sender, e);
                    break;
                case Key.F12:
                    DecodeButton_Click(sender, e);
                    break;
                case Key.Escape:
                    ClearButton_Click(sender, e);
                    break;
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    ClearButton_Click(sender, e);
                    break;
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(OutputTextBox.Text);
        }
    }
}
