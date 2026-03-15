using Account.CON;
using ApplicationEvents;
using DataTrasferObjectInterfaces;


namespace LoginTransitionHandlers
{
    public partial class LoginTransitionHandler
    {
        public MainService(ManagmentSystemEvents events)
        {
            events.GoToManagmentSystem += CatchEventFromLogicLayer;
        }

        private void CatchEventFromLogicLayer(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            GetLastMetaDataDTO();


            switch (MetaDataDTO.LayerName)
            {
                case LayerContract.VM:
                    break;

                case LayerContract.BL:
                    break;

                case LayerContract.DPL:
                    break;

                case LayerContract.DAL:
                    break;
            }
        }
    }
}
