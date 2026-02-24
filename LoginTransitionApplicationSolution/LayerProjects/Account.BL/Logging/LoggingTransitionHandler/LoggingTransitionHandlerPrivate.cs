using Account.CON;
using Account.DTO;
using DataTransferObjects;
using DataTrasferObjectInterfaces;

namespace Account.BL
{
    public partial class LoggingTransitionHandler
    {
        #region private Properties

        private Account.DPL.ILoggingTransitionHandler LoginTransitionHandler
        {
            get; set;
        }

        IDataContainer DataContainer
        {
            get; set;
        } = default!;

        /// <summary>
        /// DTO that contains information for account lookup
        /// </summary>
        private SearchAccountDTO SearchAccountDTO
        {
            get; set;
        } = default!;

        /// <summary>
        /// DTO which contains metadata
        /// </summary>
        private MetaDataDTO MetaDataDTO
        {
            get; set;
        } = default!;

        #endregion


        #region private Methods

        /// <summary>
        /// Method which is part of Login trasition (BuisinessLogic) 
        /// </summary>
        private void SendRequestToApplicationNextLayer()
        {
            LoginTransitionHandler.ProcessRequest(DataContainer);
        }

        private void ProcessResponseFromApplicationNextLayer()
        {
            GetSearchRequestFromContainer();
            GetMetaDataFromContainer();

            switch (SearchAccountDTO.LoginProcessingResult)
            {
                case CoreComponents.LoginProcessingResult.AccountNotFound:
                    break;

                case CoreComponents.LoginProcessingResult.AccountFoundPasswordMissmatched:
                    break;

                case CoreComponents.LoginProcessingResult.LoginSuccessful:
                    MetaDataDTO.StateName = StateContract.INITIAL;
                    break;
            }
        }

        /// <summary>
        /// Method which initializes components
        /// </summary>
        /// <param name="dataContainer"></param>
        private void InitializeComponent(IDataContainer dataContainer)
        {
            DataContainer = dataContainer;
        }

        /// <summary>
        /// Method which gets serch request from container
        /// </summary>
        private void GetSearchRequestFromContainer()
        {
            SearchAccountDTO = DataContainer.GetDTO<SearchAccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX)!;
        }

        /// <summary>
        /// Method which gets metadata from container
        /// </summary>
        private void GetMetaDataFromContainer()
        {
            MetaDataDTO = DataContainer.GetDTO<MetaDataDTO>(TableTypes.META_DATA)!;
        }

        #endregion
    }
}
