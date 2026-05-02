using Contracts;
using ManagmentSystem;
using System.Windows;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ApplicationSystem applicationSystem = ApplicationSystem.GetInstance();
            IStateHandler stateHandler = applicationSystem.GetStateHandler(Account.CON.UseCaseContract.ACCOUNT, LayerContract.SL);
            applicationSystem.SubscribeToEvent(stateHandler);
        }
    }
}