using BusinessProcessHandlers;
using DataTrasferObjectInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.DAL
{
    public partial class CheckIfAccountExistsTransitionHandler : TransitionHandler
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
