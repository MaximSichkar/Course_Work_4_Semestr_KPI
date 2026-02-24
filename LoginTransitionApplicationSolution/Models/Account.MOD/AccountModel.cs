using Account.DTO;
using Account.INT;
using System.ComponentModel;

namespace Account.MOD
{
    /// <summary>
    /// Account model
    /// </summary>
    public class AccountModel : AccountDTO, IAccount, INotifyPropertyChanged
    {
        /// <summary>
        /// Event for checking property state
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Properties

        /// <summary>
        /// Account data transfer object
        /// </summary>
        public SearchAccountDTO? SearchAccountDTO
        {
            get; set;
        }

        /// <summary>
        /// Accounts email
        /// </summary>
        public new string? Email
        {
            get
            {
                if (this.SearchAccountDTO == null)
                {
                    return null;
                }
                else
                {
                    return SearchAccountDTO.Email;
                }
            }

            set
            {
                if (SearchAccountDTO != null)
                {
                    SearchAccountDTO.Email = value;

                    if (value != SearchAccountDTO.Email)
                    {
                        RaisePropertyChangedEvent(nameof(Email));
                    }
                }
            }
        }

        /// <summary>
        /// Accounts password
        /// </summary>
        public new string? Password
        {
            get
            {
                if (this.SearchAccountDTO == null)
                {
                    return null;
                }
                else
                {
                    return SearchAccountDTO.Password;
                }
            }

            set
            {
                if (SearchAccountDTO != null)
                {
                    SearchAccountDTO.Password = value;

                    if (value != SearchAccountDTO.Password)
                    {
                        RaisePropertyChangedEvent(nameof(Password));
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method wich checks property state
        /// </summary>
        /// <param name="propertyName"></param>
        void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
