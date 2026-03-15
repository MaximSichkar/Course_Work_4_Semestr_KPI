using ApplicationEvents;
using DataTrasferObjectInterfaces;


namespace ManagmentSystem
{
    public partial class ApplicationSystem
    {
        public ApplicationSystem()
        {
        }

        public ApplicationSystem(ManagmentSystemEvents events)
        {
            events.GoToRouter += CatchEventFromLogicLayer;
        }

        private void CatchEventFromLogicLayer(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            GetLastMetaDataDTO();


        }
    }
}
