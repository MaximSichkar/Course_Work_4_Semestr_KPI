using DataTrasferObjectInterfaces;

namespace Account.DTI
{
    /// <summary>
    /// Interface wich containing account information
    /// </summary>
    public interface IAccountDTO : IDataTransferObject
    {
        #region Properties

        /// <summary>
        /// Accounts email
        /// </summary>
        string? Email
        {
            get; set;
        }

        /// <summary>
        /// Accounts password
        /// </summary>
        string? Password
        {
            get; set;
        }

        #endregion
    }
}
