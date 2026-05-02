using DataTrasferObjectInterfaces;

namespace Contracts
{
    public class ServiceRequestEventArgs : EventArgs
    {
        readonly IDataContainer _dataContainer;
        public ServiceRequestEventArgs(IDataContainer dataContainer)
        {
            _dataContainer = dataContainer;
        }

        public IDataContainer DataContainer
        {
            get
            {
                return _dataContainer;
            }
        }
    }
}
