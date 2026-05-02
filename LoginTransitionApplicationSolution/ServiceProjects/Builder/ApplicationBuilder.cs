using ManagmentSystem;

namespace Builder
{
    public class ApplicationBuilder
    {
        readonly IServiceProvider _serviceProvider;

        public ApplicationBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
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
