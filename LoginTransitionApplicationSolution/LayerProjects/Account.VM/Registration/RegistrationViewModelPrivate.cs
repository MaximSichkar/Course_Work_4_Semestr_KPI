using Account.CON;
using Account.DTO;
using Account.MOD;
using CommunityToolkit.Mvvm.ComponentModel;
using Contracts;
using DataTransferObjects;
using DataTrasferObjectInterfaces;

namespace Account.VM
{
    public partial class RegistrationViewModel
    {
        #region Private Methods

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
        /// Property which implies result of registration transition
        /// </summary>
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

        SearchAccountDTO? SearchAccountDTO
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
            SearchAccountDTO = new SearchAccountDTO()
            {
                Email = AccountModel.Email,
                Password = AccountModel.Password
            };

            DataContainer.AddDTOToDataContainer(SearchAccountDTO!, TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX);
        }

        /// <summary>
        /// Rises event that sends request to next layer of logic
        /// </summary>
        private void SendRequestToNextApplicationLayer()
        {
            AddMetaDataToDataContainer();
            RaiseServiceRequest(DataContainer);
            DeleteLastMetaData();
        }

        /// <summary>
        /// Adds metadata to container
        /// </summary>
        private void AddMetaDataToDataContainer()
        {
            IMetaDataDTO metaDataDTO = MetaDataDTO.Create(UseCaseContract.ACCOUNT, StateContract.REGISTER, TransitionContract.REGISTERING, LayerContract.SL);
            DataContainer.AddDTOToDataContainer<IMetaDataDTO>(metaDataDTO, TableTypes.META_DATA);
        }

        private void DeleteLastMetaData()
        {
            DataContainer.DeleteLastDTO<IMetaDataDTO>(TableTypes.META_DATA);
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
        private void GetRegisterResult()
        {
            RegistrationSuccessful = false;

            IMetaDataDTO metaDataDTO = DataContainer.GetFirstDTO<IMetaDataDTO>(TableTypes.META_DATA)!;
            if (metaDataDTO.StateName == StateContract.INITIAL && MessageDTO.MessageType != MessageTypes.Error)
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
