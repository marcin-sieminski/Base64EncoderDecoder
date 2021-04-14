using Base64EncoderDecoderWpf.Model;
using System.Windows.Input;

namespace Base64EncoderDecoderWpf.ViewModel
{
    public class EncoderDecoderViewModel : ViewModelBase
    {
        private EncoderDecoderModel _model = new();

        public string InputText
        {
            get => _model.InputText;
            set
            {
                _model.InputText = value;
                OnPropertyChanged(nameof(InputText));
            }
        }

        public string OutputEncoded => _model.OutputEncoded;

        public string OutputDecoded => _model.OutputDecoded;

        private ICommand _clear;
        public ICommand Clear
        {
            get
            {
                return _clear ??= new RelayCommand(
                    _ =>
                    {
                        _model.Clear();
                        OnPropertyChanged(nameof(InputText));                        
                        OnPropertyChanged(nameof(OutputEncoded));
                        OnPropertyChanged(nameof(OutputDecoded));
                    },
                    _ => _model.InputText is {Length: > 0});
            }
        }

        private ICommand _encode;
        public ICommand Encode
        {
            get
            {
                return _encode ??= new RelayCommand(
                    _ =>
                    {
                        _model.Encode();
                        OnPropertyChanged(nameof(OutputEncoded));
                    },
                    _ => _model.InputText is {Length: > 0});
            }
        }

        private ICommand _decode;
        public ICommand Decode
        {
            get
            {
                return _decode ??= new RelayCommand(
                    _ =>
                    {
                        _model.Decode();
                        OnPropertyChanged(nameof(OutputDecoded));
                    },
                    _ => _model.InputText?.Length > 0 && _model.InputText?.Length % 4 == 0);
            }
        }

        private ICommand _copyEncoded;
        public ICommand CopyEncoded
        {
            get
            {
                return _copyEncoded ??= new RelayCommand(
                    _ =>
                    {
                        _model.CopyEncoded();
                    },
                    _ => _model.OutputEncoded?.Length > 0);
            }
        }

        private ICommand _copyDecoded;
        public ICommand CopyDecoded
        {
            get
            {
                return _copyDecoded ??= new RelayCommand(
                    _ =>
                    {
                        _model.CopyDecoded();
                    },
                    _ => _model.OutputDecoded?.Length > 0);
            }
        }
    }
}
