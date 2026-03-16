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

        private void InitializeComponent(IDataContainer dataContainer)
        {
            DataContainer = dataContainer;
        }

        #endregion

    }
}
