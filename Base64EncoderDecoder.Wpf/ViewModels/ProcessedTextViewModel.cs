using Base64EncoderDecoderWpf.Annotations;
using Base64EncoderDecoderWpf.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Base64EncoderDecoderWpf.ViewModels
{
    public class ProcessedTextViewModel : INotifyPropertyChanged
    {
        private ProcessedTextModel _model = new ProcessedTextModel();

        public string InputText
        {
            get => _model.InputText;
            set
            {
                _model.InputText = value;
                _model.OutputText = Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextToBase64(_model.InputText);
                OnPropertyChanged(nameof(InputText));
            }
        }

        public string OutputText
        {
            get => _model.OutputText;
            set
            {
                _model.OutputText = value;
                OnPropertyChanged(nameof(OutputText));
            }
        }

        private ICommand _clear = null;

        public ICommand Clear
        {
            get
            {
                if (_clear == null)
                {
                    _clear = new RelayCommand(
                        (object o) =>
                        {
                            _model.Clear();
                            OnPropertyChanged(nameof(InputText));
                        },
                        (object o) => _model.InputText != null && _model.InputText.Length > 0);
                }

                return _clear;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
