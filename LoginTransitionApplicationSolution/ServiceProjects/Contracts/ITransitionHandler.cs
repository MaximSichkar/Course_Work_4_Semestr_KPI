using DataTrasferObjectInterfaces;

namespace Contracts
{
    public interface ITransitionHandler
    {
        void ProcessRequest(IDataContainer container);
    }
}
