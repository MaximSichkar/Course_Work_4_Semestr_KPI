using Account.DTO;
using DataTrasferObjectInterfaces;
using MaSystemResourses;

namespace Account.DPL
{
    public partial class RegistrationTransitionHandler
    {
        #region Private properties

        private Account.DAL.IRegistrationTransitionHandler RegisterTransitionHandler
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
        /// Processes the account data obtained from storage and sets the registration result
        /// </summary>
        private void ProcessAccountData()
        {
            if (AccountDTO == null)
            {
                SearchAccountDTO.RegisterProcessingResult = CoreComponents.RegisterProcessingResult.RegistrationAllowed;
                return;
            }

            if (SearchAccountDTO.Email == AccountDTO.Email)
            {
                SearchAccountDTO.RegisterProcessingResult = CoreComponents.RegisterProcessingResult.AccountAlreadyExist;
                DataContainer.AddDTOToDataContainer<MessageDTO>(MessageDTO.Create(Resources.AccountAlreadyExist, MessageTypes.Error), TableTypes.MESSAGE);
            }
        }

        /// <summary>
        /// Method which is part of Registration trasition, going to access logic for сheck the coincidences in data base
        /// </summary>
        private void CheckForCoincidenceDataFromStorage()
        {
            RegisterTransitionHandler.ProcessSearchRequest(DataContainer);
        }

        /// <summary>
        /// Method which is part of Registration trasition, going to access logic for save new account into data base
        /// </summary>
        private void RegisterAccountToDataBase()
        {
            RegisterTransitionHandler.ProcessRegisterRequest(DataContainer);
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
