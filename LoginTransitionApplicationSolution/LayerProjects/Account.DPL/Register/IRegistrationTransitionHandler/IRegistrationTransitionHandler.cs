using DataTrasferObjectInterfaces;

namespace Account.DPL
{
    public interface IRegistrationTransitionHandler
    {
        void ProcessRequest(IDataContainer container);
    }
}
