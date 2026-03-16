using ManagmentSystem;
using Router;

namespace Builder
{
    public class RequestBuilder
    {
        public ApplicationSystem Build()
        {
            ApplicationRouter applicationRouter = new ApplicationRouter();
            ApplicationSystem application = new ApplicationSystem(applicationRouter);
            application += applicationRouter;

            return application;
        }
    }
}
