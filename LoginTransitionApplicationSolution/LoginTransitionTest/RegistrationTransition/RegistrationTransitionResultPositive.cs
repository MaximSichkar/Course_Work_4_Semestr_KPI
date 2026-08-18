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
    public partial class RegistrationTransitionTests
    {
        private ServiceProvider? _serviceProvider;

        [TestMethod]
        public void RegistrationTransitionResultPositive()
        {
            ServiceCollection services = new ServiceCollection();

            ApplicationBuilder applicationBuilder = new ApplicationBuilder(services);

            //Build application
            ApplicationSystem applicationSystem = applicationBuilder.Build();

            //Get State Handler subscribe to event and convert to RegistrationViewModel
            IStateHandler stateHandler = applicationSystem.GetStateHandler(Account.CON.UseCaseContract.ACCOUNT, Account.CON.StateContract.REGISTER, LayerContract.SL)!;
            applicationSystem.SubscribeToEvent(stateHandler);
            RegistrationViewModel registrationViewModel = (RegistrationViewModel)stateHandler;

            //Created DTO           
            SearchAccountDTO searchAccountDTO = new SearchAccountDTO();

            //Create Model
            AccountModel accountModel = new AccountModel();
            accountModel.SearchAccountDTO = searchAccountDTO;

            registrationViewModel.AccountModel = accountModel;

            registrationViewModel.AccountModel.Email = "maxim";
            registrationViewModel.AccountModel.Password = "1234";

            registrationViewModel.Register();

            Assert.IsTrue(registrationViewModel.RegistrationSuccessful);
        }
    }
}
