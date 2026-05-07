using BusinessProcessHandlers;
using DataTrasferObjectInterfaces;

namespace Account.DPL
{
    /// <summary>
    /// Class which is part of Login trasition (DataProccesingLogic) 
    /// </summary>
    public partial class LoggingTransitionHandler : TransitionHandler
    {
        /// <summary>
        /// Method which is part of Login trasition (DataProccesingLogic) 
        /// </summary>
        /// <param name="dataContainer">Data container</param>
        public override void ProcessRequest(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            GetSearchRequestFromContainer();
            ValidateInputData();
            if (InputDataValid)
            {
                SendRequestToNextApplicationLayer();
                GetSearchRequestFromContainer();
                GetSearchResultFromContainer();
                ProcessAccountData();
            }
        }
    }
}
