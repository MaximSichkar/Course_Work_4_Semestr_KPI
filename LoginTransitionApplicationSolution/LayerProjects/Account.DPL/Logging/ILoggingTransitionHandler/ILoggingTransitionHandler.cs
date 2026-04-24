using Contracts;
using DataTrasferObjectInterfaces;

namespace Account.DPL
{
    public interface ILoggingTransitionHandler : ITransitionHandler
    {
        void ProcessRequest(IDataContainer container);
    }
}
