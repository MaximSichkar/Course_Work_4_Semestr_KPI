using DataTrasferObjectInterfaces;

namespace Account.BL
{
    public partial class RegistrationTransitionHandler : IRegistrationTransitionHandler
    {
        /// <summary>
        /// Method which is part of Register trasition (BuisinessLogic) 
        /// </summary>
        /// <param name="dataContainer"></param>
        public RegistrationTransitionHandler(Account.DPL.IRegistrationTransitionHandler registrationTransitionHandler)
        {
            RegisterTransitionHandler = registrationTransitionHandler;
        }

        /// <summary>
        /// Method which is part of Login trasition (BuisinessLogic) 
        /// </summary>
        /// <param name="dataContainer"></param>
        public void ProcessRequest(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            SendRequestToApplicationNextLayer();
            ProcessResponseFromApplicationNextLayer();
        }
    }
}
