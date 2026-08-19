using Account.CON;
using Account.DTO;
using Contracts;
using DataTrasferObjectInterfaces;
using SystemResourses;

namespace Account.DPL
{
    public partial class RegistrationTransitionHandler
    {
        #region Private properties

        /// <summary>
        /// Property which contains user data validation result
        /// </summary>
        private bool InputDataValid
        {
            get; set;
        }

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
        /// Processes the account data obtained from storage and sets the registration result
        /// </summary>
        private void ProcessAccountData()
        {
            if (AccountDTO == null)
            {
                SearchAccountDTO.RegistrationProcessingResult = CoreComponents.RegistrationProcessingResult.RegistrationAllowed;
                return;
            }

            if (SearchAccountDTO.Email == AccountDTO.Email)
            {
                SearchAccountDTO.RegistrationProcessingResult = CoreComponents.RegistrationProcessingResult.AccountAlreadyExist;
                DataContainer.AddDTOToDataContainer<MessageDTO>(MessageDTO.Create(Resources.AccountAlreadyExist, MessageTypes.Error), TableTypes.MESSAGE);
            }
        }

        /// <summary>
        /// Method which is part of Registration trasition, going to access logic for сheck the coincidences in data base
        /// </summary>
        private void CheckIfAccountExists()
        {
            CreateMetaData(UseCaseContract.ACCOUNT, StateContract.REGISTER, TransitionContract.CHECKIFACCOUNTEXISTS, LayerContract.DPL);
            AddMetaData();
            RaiseServiceRequest(DataContainer);
            DeleteLastMetaData();
        }

        /// <summary>
        /// Method which is part of Registration trasition, going to access logic for save new account into data base
        /// </summary>
        private void RegisterAccountToDataBase()
        {
            CreateMetaData(UseCaseContract.ACCOUNT, StateContract.REGISTER, TransitionContract.REGISTERACCOUNT, LayerContract.DPL);
            AddMetaData();
            RaiseServiceRequest(DataContainer);
            DeleteLastMetaData();
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
            SearchAccountDTO = DataContainer.GetLastDTO<SearchAccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX)!;
        }

        /// <summary>
        /// Method which gets serch result from container
        /// </summary>
        private void GetSearchResultFromContainer()
        {
            AccountDTO = DataContainer.GetLastDTO<AccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_RESULT_SUFFIX)!;
        }

        #endregion
    }
}
