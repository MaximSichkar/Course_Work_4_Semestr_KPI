using Account.VM;
using System.Windows;

namespace WPFSystemAplication
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow(RegistrationViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
