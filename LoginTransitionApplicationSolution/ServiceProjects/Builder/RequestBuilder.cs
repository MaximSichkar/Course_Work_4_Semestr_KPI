using ManagmentSystem;
using Router;

namespace Builder
{
    public class RequestBuilder
    {
        public ApplicationSystem Build()
        {
            ApplicationSystem application = new ApplicationSystem();
            ApplicationRouter applicationRouter = new ApplicationRouter();

            application += applicationRouter;

            return application;
        }
    }
}
