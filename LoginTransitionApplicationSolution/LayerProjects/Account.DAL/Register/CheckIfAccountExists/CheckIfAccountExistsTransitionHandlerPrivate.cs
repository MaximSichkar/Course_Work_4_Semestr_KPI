using Account.DbContext;
using Account.DTO;
using DataTrasferObjectInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.DAL
{
    public partial class CheckIfAccountExistsTransitionHandler
    {
        #region Private properties

        private AccountDTO? FoundAccount;

        private readonly AccountDbContext _dbContext;

        #endregion

        public CheckIfAccountExistsTransitionHandler(AccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Private methods

        /// <summary>
        /// Method сhecks the coincidences in data base
        /// </summary>
        private void SearchAccountInDataBase()
        {
            SearchAccountDTO searchAccountDTO = DataContainer.GetLastDTO<SearchAccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX)!;
            try
            {
                FoundAccount = _dbContext.Account.FirstOrDefault(account => account.Email == searchAccountDTO.Email);
            }
            catch
            {
                FoundAccount = null;
            }
        }

        /// <summary>
        /// Method adds account after searching it in data base
        /// </summary>
        private void AddAccountDTOToDataContainer()
        {
            DataContainer.AddDTOToDataContainer(FoundAccount!, TableTypes.ACCOUNT + TableTypes.SEARCH_RESULT_SUFFIX);
        }

        #endregion
    }
}
