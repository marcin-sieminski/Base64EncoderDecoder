using Base64EncoderDecoderWpf.ViewModel;

namespace Base64EncoderDecoderWpf.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new EncoderDecoderViewModel();
        }
    }
}
