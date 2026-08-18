using Account.CON;
using Account.DTO;
using Contracts;
using DataTrasferObjectInterfaces;

namespace Account.BL
{
    public partial class RegistrationTransitionHandler
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
        /// Method which is part of Login trasition (BuisinessLogic) 
        /// </summary>
        private void SendRequestToApplicationNextLayer()
        {
            CreateMetaData(UseCaseContract.ACCOUNT, StateContract.REGISTER, TransitionContract.REGISTERING, LayerContract.BL);
            AddMetaData();
            RaiseServiceRequest(DataContainer);
            DeleteLastMetaData();
        }

        private void ProcessResponseFromApplicationNextLayer()
        {
            GetSearchRequestFromContainer();
            GetMetaDataDTO();


            //TODO
            switch (SearchAccountDTO.RegistrationProcessingResult)
            {
                case CoreComponents.RegistrationProcessingResult.AccountAlreadyExist:
                    break;

                case CoreComponents.RegistrationProcessingResult.RegistrationAllowed:
                    MetaDataDTO.StateName = StateContract.INITIAL;
                    break;
            }
        }

        /// <summary>
        /// Method which gets metadata from container
        /// </summary>
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
