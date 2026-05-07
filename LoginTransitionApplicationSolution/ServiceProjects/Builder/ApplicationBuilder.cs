using ManagmentSystem;
using Microsoft.Extensions.DependencyInjection;

namespace Builder
{
    public partial class ApplicationBuilder
    {
        readonly IServiceProvider _serviceProvider;

        public ApplicationBuilder(ServiceCollection services)
        {
            RegisterDependency(services);

            _serviceProvider = services.BuildServiceProvider();
        }
        public ApplicationSystem Build()
        {
            ApplicationSystem applicationSystem = ApplicationSystem.GetInstance();
            ApplicationRouter applicationRouter = new ApplicationRouter();

            applicationSystem.ApplicationRouter = applicationRouter;
            applicationSystem.ServiceProvider = _serviceProvider;


            return applicationSystem;
        }
    }
}
