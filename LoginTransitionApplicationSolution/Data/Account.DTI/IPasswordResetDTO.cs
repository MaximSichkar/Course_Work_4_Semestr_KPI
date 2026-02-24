using DataTrasferObjectInterfaces;

namespace Account.DTI
{
    /// <summary>
    /// Interface wich used to reset account's password
    /// </summary>
    public interface IPasswordResetDTO : IDataTransferObject
    {
        /// <summary>
        /// New password for password reset transition
        /// </summary>
        string? NewPassword
        {
            get; set;
        }

        /// <summary>
        /// Password confirmation 
        /// </summary>
        string? ConfirmPassword
        {
            get; set;
        }
    }
}
