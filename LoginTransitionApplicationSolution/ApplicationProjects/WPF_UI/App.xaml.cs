using Account.VM;
using Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider? _serviceProvider;

        /// <summary>
        /// DI
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            /// Dependencies registration

            #region Login Transition DI registration

            services.AddScoped<LoginWindow>();
            services.AddScoped<LoginViewModel>();
            services.AddKeyedScoped<ITransitionHandler, Account.BL.LoggingTransitionHandler>("BL");
            services.AddKeyedScoped<ITransitionHandler, Account.DPL.LoggingTransitionHandler>("DPL");
            services.AddKeyedScoped<ITransitionHandler, Account.DAL.LoggingTransitionHandler>("DAL");
            services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(
                "Server=192.168.50.10\\SQLEXPRESS;" +
                "Database=MaSystem;" +
                "User Id=Maxim;" +
                "Password=root;" +
                "Encrypt=Optional;" +
                "Connection Timeout=10"));

            #endregion
        }

    }
}
