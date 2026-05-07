using DataTrasferObjectInterfaces;

namespace ManagmentSystem
{
    public partial class ApplicationRouter
    {
        /// <summary>
        /// Container for data
        /// </summary>
        private IDataContainer DataContainer
        {
            get; set;
        } = default!;

        private IMetaDataDTO MetaDataDTO
        {
            get; set;
        } = default!;

        public void InitializeComponent(IDataContainer dataContainer)
        {
            DataContainer = dataContainer;
        }

        private void GetLastMetaDataDTO()
        {
            MetaDataDTO = DataContainer.GetLastDTO<IMetaDataDTO>(TableTypes.META_DATA)!;
        }
    }
}
