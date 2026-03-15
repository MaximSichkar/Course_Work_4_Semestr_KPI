using DataTrasferObjectInterfaces;

namespace ApplicationEvents
{
    public class ManagmentSystemEvents
    {
        public event Action<IDataContainer>? GoToRouter;

        public void RouteRequest(IDataContainer dataContainer)
        {
            GoToRouter?.Invoke(dataContainer);
        }
    }
}
