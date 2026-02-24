using Account.DTO;
using DataTrasferObjectInterfaces;
using MaSystemResourses;

namespace Account.DPL
{
    /// <summary>
    /// Class which is part of Login trasition (DataProccesingLogic) 
    /// </summary>
    public partial class LoggingTransitionHandler
    {
        #region Private properties

        private Account.DAL.ILoggingTransitionHandler LoginTransitionHandler
        {
            get; set;
        }

        /// <summary>
        /// Property which contains user data validation result
        /// </summary>
        private bool InputDataValid
        {
            get; set;
        }

        /// <summary>
        /// DataContainer property implementation 
        /// </summary>
        private DataTrasferObjectInterfaces.IDataContainer DataContainer
        {
            get; set;
        } = default!;

        private SearchAccountDTO SearchAccountDTO
        {
            get; set;
        } = default!;


        private AccountDTO? AccountDTO
        {
            get; set;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method wich initializing components
        /// </summary>
        /// <param name="dataContainer"></param>
        private void InitializeComponent(IDataContainer dataContainer)
        {
            DataContainer = dataContainer;
        }

        /// <summary>
        /// Processes the account data obtained from storage and sets the login result
        /// </summary>
        private void ProcessAccountData()
        {
            if (AccountDTO == null)
            {
                SearchAccountDTO.LoginProcessingResult = CoreComponents.LoginProcessingResult.AccountNotFound;
                DataContainer.AddDTOToDataContainer<MessageDTO>(MessageDTO.Create(Resources.LoginIsFailed, MessageTypes.Error), TableTypes.MESSAGE);
                return;
            }

            if (SearchAccountDTO.Password == AccountDTO.Password)
            {
                SearchAccountDTO.LoginProcessingResult = CoreComponents.LoginProcessingResult.LoginSuccessful;
                DataContainer.AddDTOToDataContainer<MessageDTO>(MessageDTO.Create(Resources.LoginIsSuccessful, MessageTypes.Info), TableTypes.MESSAGE);
            }
            else
            {
                SearchAccountDTO.LoginProcessingResult = CoreComponents.LoginProcessingResult.AccountFoundPasswordMissmatched;
                DataContainer.AddDTOToDataContainer<MessageDTO>(MessageDTO.Create(Resources.LoginIsFailed, MessageTypes.Error), TableTypes.MESSAGE);
            }
        }

        /// <summary>
        /// Method which is part of Login trasition go to access logic 
        /// </summary>
        private void ReadAccountDataFromStorage()
        {
            LoginTransitionHandler.ProcessRequest(DataContainer);
        }

        /// <summary>
        /// Method which validates user input data
        /// </summary>
        private void ValidateInputData()
        {
            bool isValid = Validation.LenghtValidator.UpValidate(SearchAccountDTO!.Password, "Password", 4, out string? errorMessage);

            if (isValid)
            {
                InputDataValid = true;
            }
            else
            {
                DataContainer.AddDTOToDataContainer<MessageDTO>(MessageDTO.Create(errorMessage!, MessageTypes.Error), TableTypes.MESSAGE);
            }
        }

        /// <summary>
        /// Method which gets serch request from container
        /// </summary>
        private void GetSearchRequestFromContainer()
        {
            SearchAccountDTO = DataContainer.GetDTO<SearchAccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX)!;
        }

        /// <summary>
        /// Method which gets serch result from container
        /// </summary>
        private void GetSearchResultFromContainer()
        {
            AccountDTO = DataContainer.GetDTO<AccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_RESULT_SUFFIX)!;
        }

        #endregion
    }
}
