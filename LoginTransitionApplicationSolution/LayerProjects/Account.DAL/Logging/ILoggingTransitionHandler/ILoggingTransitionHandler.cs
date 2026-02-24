using DataTrasferObjectInterfaces;

namespace Account.DAL
{
    public interface ILoggingTransitionHandler
    {
        void ProcessRequest(IDataContainer container);
    }
}
