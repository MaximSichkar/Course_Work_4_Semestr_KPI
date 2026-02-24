using Account.DTO;
using DataTrasferObjectInterfaces;

namespace Account.DAL
{
    public partial class LoggingTransitionHandler
    {
        #region Private properties

        /// <summary>
        /// DataContainer property implementation 
        /// </summary>
        private DataTrasferObjectInterfaces.IDataContainer DataContainer
        {
            get; set;
        } = default!;

        private AccountDTO? FoundAccount;

        #endregion

        #region Private methods

        /// <summary>l
        /// Method wich initializing components
        /// </summary>
        /// <param name="dataContainer"></param>
        public void InitializeComponent(IDataContainer dataContainer)
        {
            DataContainer = dataContainer;
        }

        /// <summary>
        /// Method which is part of Login trasition go to access logic 
        /// </summary>
        private void SearchAccountInDataBase()
        {
            SearchAccountDTO searchAccountDTO = DataContainer.GetDTO<SearchAccountDTO>(TableTypes.ACCOUNT + TableTypes.SEARCH_REQUEST_SUFFIX)!;

            FoundAccount = _dbContext.Account.FirstOrDefault(account => account.Email == searchAccountDTO.Email);
        }

        private void AddAccountDTOToDataContainer()
        {
            DataContainer.AddDTOToDataContainer(FoundAccount!, TableTypes.ACCOUNT + TableTypes.SEARCH_RESULT_SUFFIX);
        }

        #endregion
    }
}
