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

            services.AddScoped<MainWindow>();
            services.AddScoped<LoginViewModel>();
            services.AddKeyedScoped<ITransitionHandler, Account.BL.LoggingTransitionHandler>(Account.CON.UseCaseContract.ACCOUNT + LayerContract.BL);
            services.AddKeyedScoped<ITransitionHandler, Account.DPL.LoggingTransitionHandler>("DataProcessingLayer");
            services.AddKeyedScoped<ITransitionHandler, Account.DAL.LoggingTransitionHandler>("DataAccesssLayer");
            services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(
                "Server=192.168.50.10\\SQLEXPRESS;" +
                "Database=MaSystem;" +
                "User Id=Maxim;" +
                "Password=root;" +
                "Encrypt=Optional;" +
                "Connection Timeout=10"));

            #endregion

            _serviceProvider = services.BuildServiceProvider();

            //Startup
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

    }
}
