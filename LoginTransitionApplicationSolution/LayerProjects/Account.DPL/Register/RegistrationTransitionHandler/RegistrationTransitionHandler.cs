using DataTrasferObjectInterfaces;

namespace Account.DPL
{
    /// <summary>
    /// Class which is part of Register trasition (DataProcessLogic) 
    /// </summary>
    public partial class RegistrationTransitionHandler : IRegistrationTransitionHandler
    {
        /// <summary>
        /// DI
        /// </summary>
        /// <param name="loggingTransitionHandler"></param>
        public RegistrationTransitionHandler(Account.DAL.IRegistrationTransitionHandler registrationTransitionHandler)
        {
            RegisterTransitionHandler = registrationTransitionHandler;
        }

        /// <summary>
        /// Method which is part of Register trasition (DataProcessLogic) 
        /// </summary>
        /// <param name="dataContainer"></param>
        public void ProcessRequest(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            GetSearchRequestFromContainer();
            ValidateInputData();
            if (InputDataValid)
            {
                CheckForCoincidenceDataFromStorage();
                GetSearchRequestFromContainer();
                GetSearchResultFromContainer();
                ProcessAccountData();
                if (SearchAccountDTO.RegisterProcessingResult == CoreComponents.RegisterProcessingResult.RegistrationAllowed)
                {
                    RegisterAccountToDataBase();
                }
            }
        }
    }
}
