using BusinessProcessHandlers;
using DataTrasferObjectInterfaces;

namespace Account.DPL
{
    /// <summary>
    /// Class which is part of Register trasition (DataProcessLogic) 
    /// </summary>
    public partial class RegistrationTransitionHandler : TransitionHandler
    {
        /// <summary>
        /// Method which is part of Register trasition (DataProcessLogic) 
        /// </summary>
        /// <param name="dataContainer"></param>
        public override void ProcessRequest(IDataContainer dataContainer)
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
                if (SearchAccountDTO.RegistrationProcessingResult == CoreComponents.RegistrationProcessingResult.RegistrationAllowed)
                {
                    RegisterAccountToDataBase();
                }
            }
        }
    }
}
