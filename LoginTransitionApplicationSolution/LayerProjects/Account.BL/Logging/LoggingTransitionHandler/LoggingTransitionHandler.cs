using ApplicationEvents;
using DataTrasferObjectInterfaces;

namespace Account.BL
{
    public partial class LoggingTransitionHandler : ILoggingTransitionHandler
    {
        /// <summary>
        /// Preparation for event
        /// </summary>
        public readonly ManagmentSystemEvents _managmentSystemEvents = new ManagmentSystemEvents();

        #region public Methods

        /// <summary>
        /// DI
        /// </summary>
        /// <param name="loggingTransitionHandler"></param>
        public LoggingTransitionHandler(Account.DPL.ILoggingTransitionHandler loggingTransitionHandler)
        {
            LoginTransitionHandler = loggingTransitionHandler;
        }

        /// <summary>
        /// Method which is part of Login trasition (BuisinessLogic) 
        /// </summary>
        /// <param name="dataContainer"></param>
        public void ProcessRequest(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            SendRequestToNextApplicationLayer();
            ProcessResponseFromApplicationNextLayer();
        }

        #endregion
    }
}
