using Account.CON;
using Account.DTO;
using Contracts;
using DataTrasferObjectInterfaces;

namespace Account.BL
{
    public partial class LoggingTransitionHandler
    {
        #region private Properties

        /// <summary>
        /// DTO that contains information for account lookup
        /// </summary>
        private SearchAccountDTO SearchAccountDTO
        {
            get; set;
        } = default!;

        #endregion


        #region private Methods

        /// <summary>
        /// Rises event that sends request to next layer of logic
        /// </summary>
        private void SendRequestToNextApplicationLayer()
        {
            CreateMetaData(UseCaseContract.ACCOUNT, TransitionContract.LOGGING, StateContract.LOGIN, LayerContract.BL);
            AddMetaData();
            RaiseServiceRequest(DataContainer);
            DeleteLastMetaData();
        }

        private void ProcessResponseFromApplicationNextLayer()
        {
            GetSearchRequestFromContainer();
            GetMetaDataDTO();

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

        private void GetMetaDataDTO()
        {
            MetaDataDTO = DataContainer.GetMetaDataByLayer(LayerContract.SL)!;
        }

        /// <summary>
        /// Method which gets serch request from container
        /// </summary>
        private void GetSearchRequestFromContainer()
        {
            SearchAccountDTO = DataContainer.GetLastDTO<SearchAccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX)!;
        }

        #endregion
    }
}
