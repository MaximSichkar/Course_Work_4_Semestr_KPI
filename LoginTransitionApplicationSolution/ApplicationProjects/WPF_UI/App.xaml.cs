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
            /*
            base.OnStartup(e);

            var services = new ServiceCollection();

            /// Dependencies registration

            #region Login Transition DI registration

            services.AddScoped<LoginWindow>();

            #endregion

            //Startup
            var mainWindow = _serviceProvider.GetRequiredService<LoginWindow>();
            mainWindow.Show();
            */
        }

    }
}
