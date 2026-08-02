using Account.CON;
using Account.DTO;
using Account.MOD;
using CommunityToolkit.Mvvm.ComponentModel;
using DataTransferObjects;
using DataTrasferObjectInterfaces;

namespace Account.VM
{
    public partial class RegistrationViewModel : ObservableObject
    {
        #region Private Methods

        private IDataContainer DataContainer
        {
            get; set;
        } = default!;

        private Account.BL.IRegistrationTransitionHandler RegisterTransitionHandler
        {
            get; set;
        }

        private MessageDTO? MessageDTO
        {
            get; set;
        }

        public bool RegistrationSuccessful
        {
            get; set;
        }

        private bool MessageRecivedFromResponse
        {
            get
            {
                return MessageDTO != null;
            }
        }

        #endregion


        #region Private Methods

        private void CreateNewDataContainer()
        {
            DataContainer = new DataContainer();
        }

        /// <summary>
        /// Adds search account information to request
        /// </summary>
        private void AddSearchAccountDTOToRequest()
        {
            DataContainer.AddDTOToDataContainer(AccountModel.SearchAccountDTO!, TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX);
        }

        /// <summary>
        /// Sends request to next layer of logic
        /// </summary>
        private void SendRequestToApplicationNextLayer()
        {
            RegisterTransitionHandler.ProcessRequest(DataContainer);
        }

        /// <summary>
        /// Adds metadata to container
        /// </summary>
        private void AddMetaDataToDataContainer()
        {
            MetaDataDTO metaDataDTO = new MetaDataDTO();

            metaDataDTO.TransitionName = TransitionContract.REGISTRATION;
            metaDataDTO.StateName = StateContract.REGISTRATION;
            metaDataDTO.UseCaseName = UseCaseContract.ACCOUNT;

            DataContainer.AddDTOToDataContainer(metaDataDTO, TableTypes.META_DATA);
        }

        /// <summary>
        /// Gets message response
        /// </summary>
        private void GetMessageFromeResponse()
        {
            MessageDTO = DataContainer.GetDTO<MessageDTO>(TableTypes.MESSAGE)!;
        }

        /// <summary>
        /// Gets login result
        /// </summary>
        private void GetRegisterResult()
        {
            RegistrationSuccessful = false;

            MetaDataDTO metaDataDTO = DataContainer.GetDTO<MetaDataDTO>(TableTypes.META_DATA)!; //What purpose serves this function?
            if (metaDataDTO.StateName == StateContract.INITIAL)
            {
                RegistrationSuccessful = true;
            }
        }

        /// <summary>
        /// Sets notification
        /// </summary>
        private void SetNotificationMessage()
        {
            if (MessageDTO == null)
            {
                NotificationMessage = default!;
            }
            else
            {
                NotificationMessage = MessageDTO.MessageText;
            }
        }

        /// <summary>
        /// Method which triggers after window loading
        /// </summary>
        private void OnWindowLoaded()
        {
            SearchAccountDTO searchAccountDTO = new SearchAccountDTO();
            AccountModel.SearchAccountDTO = searchAccountDTO;
        }

        #endregion
    }
}
