using CoreComponents;
using DataTrasferObjectInterfaces;


namespace Account.DTI
{
    /// <summary>
    /// Interface wich used to search account information
    /// </summary>
    public interface ISearchAccountDTO : IDataTransferObject
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

        LoginProcessingResult LoginProcessingResult
        {
            get; set;
        }

        #endregion
    }
}
