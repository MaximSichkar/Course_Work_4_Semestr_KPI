using BusinessProcessHandlers;
using DataTrasferObjectInterfaces;

namespace Account.BL
{
    public partial class RegistrationTransitionHandler : TransitionHandler
    {
        /// <summary>
        /// Method which is part of Login trasition (BuisinessLogic) 
        /// </summary>
        /// <param name="dataContainer"></param>
        public override void ProcessRequest(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            SendRequestToApplicationNextLayer();
            ProcessResponseFromApplicationNextLayer();
        }
    }
}
