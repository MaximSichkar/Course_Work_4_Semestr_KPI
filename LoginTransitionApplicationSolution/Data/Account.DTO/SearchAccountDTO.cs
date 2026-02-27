using Account.DTI;
using CoreComponents;
using DataTrasferObject;

namespace Account.DTO
{
    /// <summary>
    /// Class wich used to search account information
    /// </summary>
    public class SearchAccountDTO : DataTransferObject, ISearchAccountDTO
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

        /// <summary>
        /// Gets or sets the result of the user's last login attempt
        /// </summary>
        public LoginProcessingResult LoginProcessingResult
        {
            get; set;
        }

        #endregion
    }
}
