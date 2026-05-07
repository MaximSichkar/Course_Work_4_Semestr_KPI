using Account.DTO;
using Account.MOD;
using Account.VM;
using Builder;
using Contracts;
using ManagmentSystem;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordResetTransitionResultTest
{
    [TestClass]
    public partial class LoginTransitionTests
    {
        private ServiceProvider? _serviceProvider;

        [TestMethod]
        public void LoginTransitionResultPositive()
        {
            ServiceCollection services = new ServiceCollection();

            ApplicationBuilder applicationBuilder = new ApplicationBuilder(services);

            //Build application
            ApplicationSystem applicationSystem = applicationBuilder.Build();

            //Get State Handler subscribe to event and convert to LoginViewModel
            IStateHandler stateHandler = applicationSystem.GetStateHandler(Account.CON.UseCaseContract.ACCOUNT, LayerContract.SL)!;
            applicationSystem.SubscribeToEvent(stateHandler);
            LoginViewModel loginViewModel = (LoginViewModel)stateHandler;

            //Created DTO           
            SearchAccountDTO searchAccountDTO = new SearchAccountDTO();

            //Create Model
            AccountModel accountModel = new AccountModel();
            accountModel.SearchAccountDTO = searchAccountDTO;

            loginViewModel.AccountModel = accountModel;

            loginViewModel.AccountModel.Email = "max";
            loginViewModel.AccountModel.Password = "1234";

            loginViewModel.Login();

        }
    }
}
