using Account.DbContext;
using Account.DTO;
using Contracts;
using DataTrasferObjectInterfaces;

namespace Account.DAL
{
    public partial class LoggingTransitionHandler : ITransitionHandler
    {
        #region Private properties

        private AccountDTO? FoundAccount;

        private readonly AccountDbContext _dbContext;

        #endregion

        public LoggingTransitionHandler(AccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Private methods

        /// <summary>
        /// Method which is part of Login trasition go to access logic 
        /// </summary>
        private void SearchAccountInDataBase()
        {
            SearchAccountDTO searchAccountDTO = DataContainer.GetLastDTO<SearchAccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX)!;

            FoundAccount = _dbContext.Account.FirstOrDefault(account => account.Email == searchAccountDTO.Email);
        }

        private void AddAccountDTOToDataContainer()
        {
            DataContainer.AddDTOToDataContainer(FoundAccount!, TableTypes.ACCOUNT + TableTypes.SEARCH_RESULT_SUFFIX);
        }

        #endregion
    }
}
