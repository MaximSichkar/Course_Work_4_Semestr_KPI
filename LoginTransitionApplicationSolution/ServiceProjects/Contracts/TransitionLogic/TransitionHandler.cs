using DataTrasferObjectInterfaces;

namespace Contracts
{
    public class TransitionHandler : ITransitionHandler
    {
        public event EventHandler<ServiceRequestEventArgs>? ServiceRequest;


        private IMetaDataDTO MetaDataDTO
        {
            get; set;
        } = default!;

        private IDataContainer DataContainer
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

        public void InitializeComponent(IDataContainer dataContainer)
        {
            DataContainer = dataContainer;
        }

        #region Meta Data manipulation

        public void AddMetaData(IMetaDataDTO MetaDataDTO, string key)
        {
            DataContainer.AddDTOToDataContainer(MetaDataDTO, key);
        }

        public void DeleteLastMetaData(string key)
        {
            DataContainer.DeleteLastDTO<IMetaDataDTO>(key);
        }

        #endregion
    }
}
