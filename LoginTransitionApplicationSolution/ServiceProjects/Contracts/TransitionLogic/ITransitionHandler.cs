using DataTrasferObjectInterfaces;

namespace Contracts
{
    public interface ITransitionHandler
    {
        event EventHandler<ServiceRequestEventArgs>? ServiceRequest;
        void ProcessRequest(IDataContainer dataContainer);
    }
}
