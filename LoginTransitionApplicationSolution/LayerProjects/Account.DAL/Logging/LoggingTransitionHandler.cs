using BusinessProcessHandlers;
using DataTrasferObjectInterfaces;

namespace Account.DAL
{
    public partial class LoggingTransitionHandler : TransitionHandler
    {

        /// <summary>
        /// Method which is part of Login trasition (DataAccessLogic) 
        /// </summary>
        /// <param name="dataContainer"></param>
        public override void ProcessRequest(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            SearchAccountInDataBase();
            AddAccountDTOToDataContainer();
        }
    }
}
