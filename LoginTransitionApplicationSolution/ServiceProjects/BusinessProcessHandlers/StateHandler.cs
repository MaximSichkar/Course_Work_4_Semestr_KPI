using CommunityToolkit.Mvvm.ComponentModel;
using Contracts;
using DataTrasferObjectInterfaces;

namespace BusinessProcessHandlers
{
    public class StateHandler : ObservableObject, IStateHandler
    {
        /// <summary>
        /// Request to ApplicationSystem to serve
        /// </summary>
        public event EventHandler<ServiceRequestEventArgs>? ServiceRequest;

        protected void RaiseServiceRequest(IDataContainer dataContainer)
        {
            if (ServiceRequest != null)
            {
                ServiceRequestEventArgs serviceRequestEventArgs = new ServiceRequestEventArgs(dataContainer);
                ServiceRequest(this, serviceRequestEventArgs);
            }
        }
    }
}
