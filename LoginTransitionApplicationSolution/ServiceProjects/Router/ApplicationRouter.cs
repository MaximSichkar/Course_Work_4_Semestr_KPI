using Account.CON;
using DataTrasferObjectInterfaces;

namespace Router
{
    public partial class ApplicationRouter : IApplicationRouter
    {
        public void Redirect(IDataContainer dataContainer)
        {
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
