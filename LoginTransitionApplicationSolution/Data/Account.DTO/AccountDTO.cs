using Account.DTI;
using DataTrasferObject;

namespace Account.DTO
{
    /// <summary>
    /// Class wich containing account information
    /// </summary>
    public class AccountDTO : DataTransferObject, IAccountDTO
    {
        #region public properties

        /// <summary>
        /// Accounts email
        /// </summary>
        public string? Email
        {
            get; set;
        }

        /// <summary>
        /// Accounts password
        /// </summary>
        public string? Password
        {
            get; set;
        }

        #endregion

        public AccountDTO(AccountDTO accountDTO)
        {
            this.Email = accountDTO.Email;
            this.Password = accountDTO.Password;
        }

        public AccountDTO()
        {

        }

        public AccountDTO DeepClone()
        {
            return new AccountDTO(this);
        }
    }
}
