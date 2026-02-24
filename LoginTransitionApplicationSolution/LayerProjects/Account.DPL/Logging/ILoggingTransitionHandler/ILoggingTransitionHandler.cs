using DataTrasferObjectInterfaces;

namespace Account.DPL
{
    public interface ILoggingTransitionHandler
    {
        void ProcessRequest(IDataContainer container);
    }
}
