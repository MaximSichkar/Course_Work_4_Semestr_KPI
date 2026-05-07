using Contracts;
using DataTrasferObjectInterfaces;

namespace BusinessProcessHandlers
{
    public class TransitionHandler : ITransitionHandler
    {
        public event EventHandler<ServiceRequestEventArgs>? ServiceRequest;

        protected IDataContainer DataContainer
        {
            get; set;
        } = default!;

        protected IMetaDataDTO MetaDataDTO
        {
            get; set;
        } = default!;

        #region Logistic methods

        /// <summary>
        /// Main flow of Request
        /// </summary>
        public virtual void ProcessRequest(IDataContainer dataContainer)
        {

        }

        protected void RaiseServiceRequest(IDataContainer dataContainer)
        {
            if (ServiceRequest != null)
            {
                ServiceRequestEventArgs serviceRequestEventArgs = new ServiceRequestEventArgs(dataContainer);
                ServiceRequest(this, serviceRequestEventArgs);
            }
        }

        #endregion

        protected void InitializeComponent(IDataContainer dataContainer)
        {
            DataContainer = dataContainer;
        }

        #region Meta Data manipulation

        protected void CreateMetaData(string useCaseName, string transitionName, string stateName, string layerName)
        {
            MetaDataDTO = DataTransferObjects.MetaDataDTO.Create(useCaseName, transitionName, stateName, layerName);
        }

        protected void AddMetaData()
        {
            DataContainer.AddDTOToDataContainer(MetaDataDTO, TableTypes.META_DATA);
        }

        protected void DeleteLastMetaData()
        {
            DataContainer.DeleteLastDTO<IMetaDataDTO>(TableTypes.META_DATA);
        }

        #endregion
    }
}
