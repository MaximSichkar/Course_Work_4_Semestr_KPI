using Account.CON;
using Account.DbContext;
using Account.DTO;
using Contracts;
using DataTrasferObjectInterfaces;
using SystemResourses;

namespace Account.DAL
{
    public partial class RegistrationTransitionHandler
    {
        #region Private properties

        private AccountDTO AccountToRegister = new AccountDTO();

        private readonly AccountDbContext _dbContext;

        #endregion

        public RegistrationTransitionHandler(AccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Private methods
        
        /// <summary>
        /// Method adds new account into data base
        /// </summary>
        private void AddAccountDTOToDataBase()
        {
            SearchAccountDTO searchAccountDTO = DataContainer.GetLastDTO<SearchAccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX)!;

            AccountToRegister.Email = searchAccountDTO.Email;
            AccountToRegister.Password = searchAccountDTO.Password;
            AccountToRegister.CreatedByUserGUID = UseCaseContract.SYSTEM_ACCOUNT_GUID;
            AccountToRegister.CreatedByUserEmail = searchAccountDTO.Email;
            AccountToRegister.ChangedByUserEmail = searchAccountDTO.Email;

            _dbContext.Account.Add(AccountToRegister);
            _dbContext.SaveChanges();

            DataContainer.AddDTOToDataContainer<MessageDTO>(MessageDTO.Create(Resources.RegistrationSuccessful, MessageTypes.Info), TableTypes.MESSAGE);
        }

        #endregion
    }
}
