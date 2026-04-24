using Contracts;
using DataTrasferObjectInterfaces;


namespace ManagmentSystem
{
    public partial class ApplicationSystem
    {
        private readonly ApplicationRouter _router;

        public ApplicationSystem(ApplicationRouter applicationRouter)
        {
            _router = applicationRouter;
        }

        private void CatchEventFromLogicLayer(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            _router.Redirect(dataContainer, this);

        }

        public ITransitionHandler GetTransitionHandler(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            GetLastMetaDataDTO();
            MetaDataDTO.LayerName //TODO use metadata to get instance of DI
            ITransitionHandler transitionHandler =
            return transitionHandler;
        }
    }
}
