using DataTrasferObjectInterfaces;

namespace Account.DAL
{
    public interface IRegistrationTransitionHandler
    {
        void ProcessSearchRequest(IDataContainer container);

        void ProcessRegisterRequest(IDataContainer container);
    }
}
