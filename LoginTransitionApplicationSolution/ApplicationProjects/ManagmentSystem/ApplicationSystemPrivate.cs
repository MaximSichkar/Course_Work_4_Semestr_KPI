using Contracts;
using DataTrasferObjectInterfaces;


namespace ManagmentSystem
{
    public partial class ApplicationSystem
    {
        #region Data fields

        private IMetaDataDTO MetaDataDTO
        {
            get; set;
        } = default!;

        private IDataContainer DataContainer
        {
            get; set;
        } = default!;

        #endregion

        #region Methods

        private void InitializeComponent(ServiceRequestEventArgs serviceRequestEventArgs)
        {
            DataContainer = serviceRequestEventArgs.DataContainer;
        }

        private void InitializeComponent(IDataContainer datatContainer)
        {
            DataContainer = datatContainer;
        }

        private void GetLastMetaDataDTO()
        {
            MetaDataDTO = DataContainer.GetLastDTO<IMetaDataDTO>(TableTypes.META_DATA)!;
        }

        #endregion
    }
}
