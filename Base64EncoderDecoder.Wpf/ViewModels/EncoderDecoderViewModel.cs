using Base64EncoderDecoderWpf.Annotations;
using Base64EncoderDecoderWpf.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Base64EncoderDecoderWpf.ViewModels
{
    public class EncoderDecoderViewModel : INotifyPropertyChanged
    {
        private EncoderDecoderModel _model = new EncoderDecoderModel();

        public string InputText
        {
            get => _model.InputText;
            set
            {
                _model.InputText = value;
                _model.OutputEncoded = Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextToBase64(_model.InputText);
                _model.OutputDecoded =
                    Base64EncoderDecoderCore.Base64EncoderDecoder.ConvertTextFromBase64(_model.InputText);
                OnPropertyChanged(nameof(InputText));
            }
        }

        public string OutputEncoded
        {
            get
            {
                return _model.OutputEncoded;
            }
            set
            {
               // _model.OutputEncoded = value;
            }
        }

        public string OutputDecoded
        {
            get
            {
                return _model.OutputDecoded;
            }
            set
            {
                //_model.OutputDecoded = value;
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
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
