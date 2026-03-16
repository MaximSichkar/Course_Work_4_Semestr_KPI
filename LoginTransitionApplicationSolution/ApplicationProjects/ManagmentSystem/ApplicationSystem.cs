using ApplicationEvents;
using DataTrasferObjectInterfaces;
using Router;


namespace ManagmentSystem
{
    public partial class ApplicationSystem
    {
        private readonly IApplicationRouter _router;

        public ApplicationSystem(ApplicationRouter applicationRouter)
        {
            _router = applicationRouter;
        }

        public ApplicationSystem(ManagmentSystemEvents events)
        {
            events.GoToRouter += CatchEventFromLogicLayer;
        }

        private void CatchEventFromLogicLayer(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            _router.Redirect(dataContainer);

        }
    }
}
