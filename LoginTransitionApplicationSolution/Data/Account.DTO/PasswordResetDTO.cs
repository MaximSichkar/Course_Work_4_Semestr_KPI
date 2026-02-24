using Account.DTI;
using DataTrasferObject;

namespace Account.DTO
{
    /// <summary>
    /// Class wich used to reset account's password
    /// </summary>
    public class PasswordResetDTO : DataTransferObject, IPasswordResetDTO
    {
        /// <summary>
        /// New password for password reset transition
        /// </summary>
        public string? NewPassword
        {
            get; set;
        }

        /// <summary>
        /// Password confirmation 
        /// </summary>
        public string? ConfirmPassword
        {
            get; set;
        }
    }
}
