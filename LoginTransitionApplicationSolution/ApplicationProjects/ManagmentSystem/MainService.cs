using DataTrasferObjectInterfaces;

namespace ManagmentSystem
{
    public class MainService
    {
        public MainService(ManagmentSystemEvents events)
        {
            events.GoToManagmentSystem += CatchEventFromLogicLayer;
        }

        private void CatchEventFromLogicLayer(IDataContainer data)
        {

        }
    }
}
