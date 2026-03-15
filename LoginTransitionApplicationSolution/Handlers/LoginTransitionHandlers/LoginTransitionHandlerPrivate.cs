using DataTrasferObjectInterfaces;


namespace LoginTransitionHandlers
{
    public partial class LoginTransitionHandler
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

        private void InitializeComponent(IDataContainer dataContainer)
        {
            DataContainer = dataContainer;
        }

        private void GetLastMetaDataDTO()
        {
            MetaDataDTO = DataContainer.GetLastDTO<IMetaDataDTO>(TableTypes.META_DATA)!;
        }

        #endregion

    }
}
