using Account.DbContext;
using Account.DTO;
using DataTrasferObjectInterfaces;

namespace Account.DAL
{
    public partial class LoggingTransitionHandler : ILoggingTransitionHandler
    {
        public List<AccountDTO> accounts = new List<AccountDTO>();

        private readonly AccountDbContext _dbContext;

        public LoggingTransitionHandler(AccountDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Method which is part of Login trasition (DataAccessLogic) 
        /// </summary>
        /// <param name="dataContainer"></param>
        public void ProcessRequest(IDataContainer dataContainer)
        {
            InitializeComponent(dataContainer);
            SearchAccountInDataBase();
            AddAccountDTOToDataContainer();
        }
    }
}
