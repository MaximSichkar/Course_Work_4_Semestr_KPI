using Account.CON;
using Account.DTO;
using Account.MOD;
using CommunityToolkit.Mvvm.ComponentModel;
using DataTransferObjects;
using DataTrasferObjectInterfaces;
using Orchestration;

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
        private void SendRequestToNextApplicationLayer()
        {
            _managmentSystemEvents.RouteRequest(DataContainer);
        }

        /// <summary>
        /// Adds metadata to container
        /// </summary>
        private void AddMetaDataToDataContainer()
        {
            DataContainer.AddDTOToDataContainer(MetaDataDTO.Create(UseCaseContract.ACCOUNT, TransitionContract.LOGGING, StateContract.LOGIN, LayerContract.VM), TableTypes.META_DATA);
        }

        /// <summary>
        /// Gets message response
        /// </summary>
        private void GetMessageFromeResponse()
        {
            MessageDTO = DataContainer.GetFirstDTO<MessageDTO>(TableTypes.MESSAGE)!;
        }

        /// <summary>
        /// Gets login result
        /// </summary>
        private void GetLoginResult()
        {
            LoginSuccessful = false;

            MetaDataDTO metaDataDTO = DataContainer.GetFirstDTO<MetaDataDTO>(TableTypes.META_DATA)!;
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
            AccountDTO = DataContainer.GetFirstDTO<AccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_RESULT_SUFFIX)!;
            AccountDTO accountDTOClone = AccountDTO.DeepClone();
            Cache.GetInstance().ApplicationCache.Add(UseCaseContract.CACHED_ACCOUNT, accountDTOClone);
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
