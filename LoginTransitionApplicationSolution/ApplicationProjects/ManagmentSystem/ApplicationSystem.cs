using Contracts;
using DataTrasferObjectInterfaces;
using Microsoft.Extensions.DependencyInjection;


namespace ManagmentSystem
{
    public partial class ApplicationSystem
    {
        private readonly ApplicationRouter _router;
        private readonly IServiceProvider _serviceProvider;

        public ApplicationSystem(ApplicationRouter applicationRouter, IServiceProvider serviceProvider)
        {
            _router = applicationRouter;
            _serviceProvider = serviceProvider;
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
            ITransitionHandler transitionHandler = _serviceProvider.GetRequiredKeyedService<ITransitionHandler>(MetaDataDTO.UseCaseName + MetaDataDTO.LayerName);
            return transitionHandler;
        }
    }
}
