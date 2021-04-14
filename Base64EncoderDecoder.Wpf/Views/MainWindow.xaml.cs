using Base64EncoderDecoderWpf.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace Base64EncoderDecoderWpf.Views
{
    public partial class MainWindow
    {
        private EncoderDecoderViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new EncoderDecoderViewModel();
            DataContext = _viewModel;
        }

        //private void EncodeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (IsInvalidInputLength()) return;
        //    InputError.Content = string.Empty;
        //    EncoderDecoderViewModel.InputText = InputTextBox.Text;
        //    EncoderDecoderViewModel.OutputEncoded = Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextToBase64(EncoderDecoderViewModel.InputText);
        //    OutputDecoded.Text = EncoderDecoderViewModel.OutputEncoded;
        //}

        //private void DecodeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (IsInvalidInputLength()) return;
        //    if (InputTextBox.Text.Length % 4 != 0)
        //    {
        //        InputError.Content = "The input's length must be a multiple of 4";
        //        return;
        //    }
        //    InputError.Content = string.Empty;
        //    EncoderDecoderViewModel.InputText = InputTextBox.Text;
        //    try
        //    {
        //        EncoderDecoderViewModel.OutputEncoded = Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextFromBase64(EncoderDecoderViewModel.InputText);
        //    }
        //    catch (Exception exception)
        //    {
        //        InputError.Content = exception.Message;
        //    }
        //    OutputDecoded.Text = EncoderDecoderViewModel.OutputEncoded ?? string.Empty;
        //}

        private bool IsInvalidInputLength()
        {
            if (InputTextBox.Text.Length >= 1) return false;
            InputError.Content = "The input is empty";
            return true;
        }

        //private void ClearButton_Click(object sender, RoutedEventArgs e)
        //{
        //    InputTextBox.Text = string.Empty;
        //    OutputEncoded.Text = string.Empty;
        //    InputError.Content = string.Empty;
        //}

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    //EncodeButton_Click(sender, e);
                    break;
                case Key.F12:
                    //DecodeButton_Click(sender, e);
                    break;
                case Key.Escape:
                    //ClearButton_Click(sender, e);
                    break;
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    //ClearButton_Click(sender, e);
                    break;
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(OutputDecoded.Text);
        }
    }
}
