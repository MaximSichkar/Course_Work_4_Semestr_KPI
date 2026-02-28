using DataTrasferObjectInterfaces;

namespace ApplicationEvents
{
    public class ManagmentSystemEvents
    {
        public event Action<IDataContainer> GoToManagmentSystem;

        public void Raise(IDataContainer data)
        {
            GoToManagmentSystem?.Invoke(data);
        }
    }
}
