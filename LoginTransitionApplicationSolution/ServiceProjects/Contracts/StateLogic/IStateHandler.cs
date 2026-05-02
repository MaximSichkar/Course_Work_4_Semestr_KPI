namespace Contracts
{
    public interface IStateHandler
    {
        public event EventHandler<ServiceRequestEventArgs>? ServiceRequest;
    }
}
