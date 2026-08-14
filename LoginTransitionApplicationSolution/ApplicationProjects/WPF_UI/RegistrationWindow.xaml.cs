using Account.DTO;
using Account.MOD;
using Account.VM;
using Builder;
using Contracts;
using ManagmentSystem;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WPFSystemAplication
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

            ServiceCollection services = new ServiceCollection();

            ApplicationBuilder applicationBuilder = new ApplicationBuilder(services);

            //Build application
            ApplicationSystem applicationSystem = applicationBuilder.Build();

            //Get State Handler subscribe to event and convert to LoginViewModel
            IStateHandler stateHandler = applicationSystem.GetStateHandler(Account.CON.UseCaseContract.ACCOUNT, LayerContract.SL)!;
            applicationSystem.SubscribeToEvent(stateHandler);
            RegistrationWindow registrationViewModel = (RegistrationWindow)stateHandler;

            //Created DTO           
            SearchAccountDTO searchAccountDTO = new SearchAccountDTO();

            //Create Model
            AccountModel accountModel = new AccountModel();
            accountModel.SearchAccountDTO = searchAccountDTO;

            registrationViewModel.AccountModel = accountModel;

            /* loginViewModel.AccountModel.Email = "max";
            loginViewModel.AccountModel.Password = "1234"; */

            DataContext = registrationViewModel;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
