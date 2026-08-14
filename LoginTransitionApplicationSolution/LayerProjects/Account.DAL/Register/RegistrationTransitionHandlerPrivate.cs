using Account.CON;
using Account.DTO;
using DataTrasferObjectInterfaces;
using MaSystemResourses;

namespace Account.DAL
{
    public partial class RegistrationTransitionHandler
    {
        #region Private properties

        /// <summary>
        /// DataContainer property implementation 
        /// </summary>
        private DataTrasferObjectInterfaces.IDataContainer DataContainer
        {
            get; set;
        } = default!;

        private AccountDTO? FoundAccount;

        private AccountDTO AccountToRegister = new AccountDTO();

        #endregion

        #region Private methods

        /// <summary>l
        /// Method wich initializing components
        /// </summary>
        /// <param name="dataContainer"></param>
        public void InitializeComponent(IDataContainer dataContainer)
        {
            DataContainer = dataContainer;
        }

        /// <summary>
        /// Method сhecks the coincidences in data base
        /// </summary>
        private void SearchAccountInDataBase()
        {
            SearchAccountDTO searchAccountDTO = DataContainer.GetDTO<SearchAccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX)!;

            FoundAccount = _dbContext.Account.FirstOrDefault(account => account.Email == searchAccountDTO.Email);
        }

        /// <summary>
        /// Method adds new account into data base
        /// </summary>
        private void AddAccountDTOToDataBase()
        {
            SearchAccountDTO searchAccountDTO = DataContainer.GetDTO<SearchAccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX)!;

            AccountToRegister.Email = searchAccountDTO.Email;
            AccountToRegister.Password = searchAccountDTO.Password;
            AccountToRegister.CreatedByUserGUID = UseCaseContract.SYSTEM_ACCOUNT_GUID;
            AccountToRegister.CreatedByUserEmail = searchAccountDTO.Email;
            AccountToRegister.ChangedByUserEmail = searchAccountDTO.Email;

            _dbContext.Account.Add(AccountToRegister);
            _dbContext.SaveChanges();

            AddMessageToDataContainer(Resources.RegistrationSuccessful, MessageTypes.Info);
        }

        /// <summary>
        /// Method adds account after searching it in data base
        /// </summary>
        private void AddAccountDTOToDataContainer()
        {
            DataContainer.AddDTOToDataContainer(FoundAccount!, TableTypes.ACCOUNT + TableTypes.SEARCH_RESULT_SUFFIX);
        }

        /// <summary>
        /// Method which adds a MessageDTO to data container
        /// </summary>
        /// <param name="messageText"></param>
        /// <param name="messageType"></param>
        private void AddMessageToDataContainer(string messageText, MessageTypes messageType)
        {
            MessageDTO messageDTO = new MessageDTO();
            messageDTO.MessageText = messageText;
            messageDTO.MessageType = messageType;

            DataContainer.AddDTOToDataContainer(messageDTO, TableTypes.MESSAGE);
        }
        #endregion
    }
}
