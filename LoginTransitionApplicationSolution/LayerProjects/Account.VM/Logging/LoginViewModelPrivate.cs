using Account.CON;
using Account.DTO;
using Account.MOD;
using CommunityToolkit.Mvvm.ComponentModel;
using DataTransferObjects;
using DataTrasferObjectInterfaces;
using MaSystem.Orchestration;

namespace Account.VM
{
    /// <summary>
    /// Login View Model, (UI file)
    /// </summary>
    public partial class LoginViewModel : ObservableObject
    {
        #region Private Data Fields

        /// <summary>
        /// Container for data
        /// </summary>
        private IDataContainer DataContainer
        {
            get; set;
        } = default!;

        /// <summary>
        /// Model of Account
        /// </summary>
        [ObservableProperty]
        private AccountModel accountModel = default!;

        /// <summary>
        /// DI transition to the next level
        /// </summary>
        private Account.BL.ILoggingTransitionHandler LoggingTransitionHandler
        {
            get; set;
        }

        /// <summary>
        /// Message DTO implementation
        /// </summary>
        private MessageDTO? MessageDTO
        {
            get; set;
        }

        /// <summary>
        /// Property which implies result of login transition
        /// </summary>
        public bool LoginSuccessful
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

        private AccountDTO? AccountDTO
        {
            get; set;
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Method for implementation new Data Container
        /// </summary>
        private void CreateNewDataContainer()
        {
            DataContainer = new DataContainer();
        }

        /// <summary>
        /// Adds search account information to request
        /// </summary>
        private void AddSearchAccountDTOToDataContainer()
        {
            DataContainer.AddDTOToDataContainer(AccountModel.SearchAccountDTO!, TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX);
        }

        /// <summary>
        /// Sends request to next layer of logic
        /// </summary>
        private void SendRequestToApplicationNextLayer()
        {
            LoggingTransitionHandler.ProcessRequest(DataContainer);
        }

        /// <summary>
        /// Adds metadata to container
        /// </summary>
        private void AddMetaDataToDataContainer()
        {
            MetaDataDTO metaDataDTO = new MetaDataDTO();

            metaDataDTO.TransitionName = TransitionContract.LOGGING;
            metaDataDTO.StateName = StateContract.LOGIN;
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
        private void GetLoginResult()
        {
            LoginSuccessful = false;

            MetaDataDTO metaDataDTO = DataContainer.GetDTO<MetaDataDTO>(TableTypes.META_DATA)!;
            if (metaDataDTO.StateName == StateContract.INITIAL)
            {
                LoginSuccessful = true;
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
        /// Method for Caching account
        /// </summary>
        private void CacheAccount()
        {
            AccountDTO = DataContainer.GetDTO<AccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_RESULT_SUFFIX)!;
            AccountDTO accountDTOClone = AccountDTO.DeepClone();
            MaSystemApplication.GetInstance().ApplicationCache.Add(UseCaseContract.CACHED_ACCOUNT, accountDTOClone);
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
