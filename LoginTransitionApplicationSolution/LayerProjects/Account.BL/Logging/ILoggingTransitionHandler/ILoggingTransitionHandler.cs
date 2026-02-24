using DataTrasferObjectInterfaces;

namespace Account.BL
{
    public interface ILoggingTransitionHandler
    {
        void ProcessRequest(IDataContainer container);
    }
}
