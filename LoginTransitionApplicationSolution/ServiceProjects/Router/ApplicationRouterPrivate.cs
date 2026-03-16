using DataTrasferObjectInterfaces;

namespace Router
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

        private void GetLastMetaDataDTO()
        {
            MetaDataDTO = DataContainer.GetLastDTO<IMetaDataDTO>(TableTypes.META_DATA)!;
        }
    }
}
