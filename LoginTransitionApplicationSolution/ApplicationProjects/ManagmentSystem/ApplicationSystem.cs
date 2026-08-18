using Contracts;
using DataTrasferObjectInterfaces;
using Microsoft.Extensions.DependencyInjection;


namespace ManagmentSystem
{
    public partial class ApplicationSystem
    {
        static ApplicationSystem? _applicationSystem = null;

        private ApplicationSystem()
        {

        }

        public IServiceProvider ServiceProvider
        {
            get; set;
        }

        public ApplicationRouter ApplicationRouter
        {
            get; set;
        }

        public static ApplicationSystem GetInstance()
        {
            if (_applicationSystem == null)
            {
                _applicationSystem = new ApplicationSystem();
            }

            return _applicationSystem;
        }

        /// <summary>
        /// Catch event method
        /// </summary>
        /// <param name="dataContainer"></param>
        private void OnServiceRequest(object? sender, ServiceRequestEventArgs e)
        {
            InitializeComponent(e);
            ApplicationRouter.Redirect(DataContainer, this);
        }

        public ITransitionHandler GetTransitionHandler(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            GetLastMetaDataDTO();
            ITransitionHandler transitionHandler = ServiceProvider.GetRequiredKeyedService<ITransitionHandler>(MetaDataDTO.UseCaseName + MetaDataDTO.StateName + MetaDataDTO.TransitionName + MetaDataDTO.LayerName);
            return transitionHandler;
        }

        public IStateHandler GetStateHandler(string useCaseName, string stateName, string layerName)
        {
            IStateHandler stateHandler = ServiceProvider.GetRequiredKeyedService<IStateHandler>(useCaseName + stateName + layerName);
            return stateHandler;
        }

        #region Event Subscription

        public void SubscribeToEvent(ITransitionHandler transitionHandler)
        {
            transitionHandler.ServiceRequest += OnServiceRequest;
        }

        public void SubscribeToEvent(IStateHandler stateHandler)
        {
            stateHandler.ServiceRequest += OnServiceRequest;
        }

        public void UnSubscribeToEvent(ITransitionHandler transitionHandler)
        {
            transitionHandler.ServiceRequest -= OnServiceRequest;
        }

        public void UnSubscribeToEvent(IStateHandler stateHandler)
        {
            stateHandler.ServiceRequest -= OnServiceRequest;
        }

        #endregion
    }
}
