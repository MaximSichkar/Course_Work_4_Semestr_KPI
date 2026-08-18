using Account.DbContext;
using Account.VM;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Builder
{
    public partial class ApplicationBuilder
    {
        private void RegisterDependency(ServiceCollection services)
        {
            #region Login Transition DI registration

            /// Dependencies registration            
            services.AddKeyedScoped<IStateHandler, LoginViewModel>(Account.CON.UseCaseContract.ACCOUNT + Account.CON.StateContract.LOGIN + LayerContract.SL);
            services.AddKeyedScoped<ITransitionHandler, Account.BL.LoggingTransitionHandler>(Account.CON.UseCaseContract.ACCOUNT + Account.CON.StateContract.LOGIN + Account.CON.TransitionContract.LOGGING + LayerContract.BL);
            services.AddKeyedScoped<ITransitionHandler, Account.DPL.LoggingTransitionHandler>(Account.CON.UseCaseContract.ACCOUNT + Account.CON.StateContract.LOGIN + Account.CON.TransitionContract.LOGGING + LayerContract.DPL);
            services.AddKeyedScoped<ITransitionHandler, Account.DAL.LoggingTransitionHandler>(Account.CON.UseCaseContract.ACCOUNT + Account.CON.StateContract.LOGIN + Account.CON.TransitionContract.CHECKFORCOINCIDANCE + LayerContract.DAL);

            services.AddKeyedScoped<IStateHandler, RegistrationViewModel>(Account.CON.UseCaseContract.ACCOUNT + Account.CON.StateContract.REGISTER + LayerContract.SL);
            services.AddKeyedScoped<ITransitionHandler, Account.BL.RegistrationTransitionHandler>(Account.CON.UseCaseContract.ACCOUNT + Account.CON.StateContract.REGISTER + Account.CON.TransitionContract.REGISTERING + LayerContract.BL);
            services.AddKeyedScoped<ITransitionHandler, Account.DPL.RegistrationTransitionHandler>(Account.CON.UseCaseContract.ACCOUNT + Account.CON.StateContract.REGISTER +  Account.CON.TransitionContract.REGISTERING + LayerContract.DPL);
            services.AddKeyedScoped<ITransitionHandler, Account.DAL.RegistrationTransitionHandler>(Account.CON.UseCaseContract.ACCOUNT + Account.CON.StateContract.REGISTER + Account.CON.TransitionContract.CHECKFORCOINCIDANCE + LayerContract.DAL);
            services.AddKeyedScoped<ITransitionHandler, Account.DAL.RegistrationTransitionHandler>(Account.CON.UseCaseContract.ACCOUNT + Account.CON.StateContract.REGISTER +  Account.CON.TransitionContract.REGISTERACCOUNT + LayerContract.DAL);

            services.AddDbContext<AccountDbContext>(options =>
                options.UseNpgsql(
                "Host=192.168.50.10;" +
                "Port=5432;" +
                "Database=CourseWork;" +
                "Username=postgres;" +
                "Password=1234"));

            #endregion
        }
    }
}
