using DataTrasferObjectInterfaces;

namespace Account.BL
{
    public interface IRegistrationTransitionHandler
    {
        void ProcessRequest(IDataContainer container);
    }
}
