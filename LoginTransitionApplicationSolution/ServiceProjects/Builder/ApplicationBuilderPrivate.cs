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
            services.AddScoped<LoginWindow>();
            services.AddKeyedScoped<IStateHandler, LoginViewModel>(Account.CON.UseCaseContract.ACCOUNT + LayerContract.SL);
            services.AddKeyedScoped<ITransitionHandler, Account.BL.LoggingTransitionHandler>(Account.CON.UseCaseContract.ACCOUNT + LayerContract.BL);
            services.AddKeyedScoped<ITransitionHandler, Account.DPL.LoggingTransitionHandler>(Account.CON.UseCaseContract.ACCOUNT + LayerContract.DPL);
            services.AddKeyedScoped<ITransitionHandler, Account.DAL.LoggingTransitionHandler>(Account.CON.UseCaseContract.ACCOUNT + LayerContract.DAL);
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
