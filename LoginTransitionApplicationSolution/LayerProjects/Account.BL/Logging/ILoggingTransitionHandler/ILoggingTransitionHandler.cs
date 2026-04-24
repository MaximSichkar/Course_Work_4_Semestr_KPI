using Contracts;
using DataTrasferObjectInterfaces;

namespace Account.BL
{
    public interface ILoggingTransitionHandler : ITransitionHandler
    {
        void ProcessRequest(IDataContainer container);
    }
}
