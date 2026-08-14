using Account.DbContext;
using DataTrasferObjectInterfaces;

namespace Account.DAL
{
    /// <summary>
    /// Method which is part of Register trasition (DataAccessLogic) 
    /// </summary>
    /// <param name="dataContainer"></param>
    public partial class RegistrationTransitionHandler : IRegistrationTransitionHandler
    {
        private readonly AccountDbContext _dbContext;

        public RegistrationTransitionHandler(AccountDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Method which is part of Login trasition (DataAccessLogic) 
        /// </summary>
        /// <param name="dataContainer"></param>
        public void ProcessSearchRequest(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            SearchAccountInDataBase();
            AddAccountDTOToDataContainer();
        }

        public void ProcessRegisterRequest(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            AddAccountDTOToDataBase();
        }
    }
}
