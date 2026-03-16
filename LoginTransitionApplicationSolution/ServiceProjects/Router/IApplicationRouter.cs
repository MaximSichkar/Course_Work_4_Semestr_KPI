using DataTrasferObjectInterfaces;

namespace Router
{
    public interface IApplicationRouter
    {
        void Redirect(IDataContainer data);
    }
}
