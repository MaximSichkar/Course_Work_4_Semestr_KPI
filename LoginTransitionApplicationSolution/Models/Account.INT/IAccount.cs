namespace Account.INT
{
    /// <summary>
    /// Account interface
    /// </summary>
    public interface IAccount
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
