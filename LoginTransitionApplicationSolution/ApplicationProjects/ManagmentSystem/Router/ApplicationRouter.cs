using Contracts;
using DataTrasferObjectInterfaces;

namespace ManagmentSystem
{
    public partial class ApplicationRouter
    {

        public void Redirect(IDataContainer dataContainer, ApplicationSystem applicationSystem)
        {
            GetLastMetaDataDTO();

            switch (MetaDataDTO.LayerName)
            {
                case LayerContract.VM:
                    MetaDataDTO.LayerName = LayerContract.BL;
                    break;

                case LayerContract.BL:
                    MetaDataDTO.LayerName = LayerContract.DPL;
                    break;

                case LayerContract.DPL:
                    MetaDataDTO.LayerName = LayerContract.DAL;
                    break;

                case LayerContract.DAL:
                    break;
            }

            ITransitionHandler transitionHandler = applicationSystem.GetTransitionHandler(dataContainer);
            transitionHandler.ProcessRequest();
        }
    }
}
