using BusinessProcessHandlers;
using DataTrasferObjectInterfaces;

namespace Account.BL
{
    public partial class LoggingTransitionHandler : TransitionHandler
    {
        #region public Methods

        /// <summary>
        /// Method which is part of Login trasition (BuisinessLogic) 
        /// </summary>
        /// <param name="dataContainer"></param>
        public override void ProcessRequest(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            SendRequestToNextApplicationLayer();
            ProcessResponseFromApplicationNextLayer();
        }

        #endregion
    }
}
