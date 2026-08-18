using BusinessProcessHandlers;
using DataTrasferObjectInterfaces;

namespace Account.DAL
{
    /// <summary>
    /// Method which is part of Register trasition (DataAccessLogic) 
    /// </summary>
    /// <param name="dataContainer"></param>
    public partial class RegistrationTransitionHandler : TransitionHandler
    {
        /// <summary>
        /// Method which is part of Login trasition (DataAccessLogic) 
        /// </summary>
        /// <param name="dataContainer"></param>
        
        public override void ProcessRequest(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            ProcessSearchRequest();

            if ()
            {
                InitializeComponent(dataContainer);
                ProcessRegisterRequest();

            }
        }

        #region Buisiness methods

        public void ProcessSearchRequest()
        {            
            SearchAccountInDataBase();
            AddAccountDTOToDataContainer();
        }

        public void ProcessRegisterRequest()
        {            
            AddAccountDTOToDataBase();
        }

        #endregion
    }
}
