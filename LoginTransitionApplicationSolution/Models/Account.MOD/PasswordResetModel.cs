using Account.DTO;
using Account.INT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.MOD
{
    public class PasswordResetModel : PasswordResetDTO, IPasswordReset, INotifyPropertyChanged
    {
        /// <summary>
        /// Event for checking property state
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Properties

        public PasswordResetDTO? PasswordResetDTO
        { 
            get; set; 
        }

        /// <summary>
        /// New password for password reset transition
        /// </summary>
        public new string? NewPassword
        {
            get
            {
                if (this.PasswordResetDTO == null)
                {
                    return null;
                }
                else
                {
                    return PasswordResetDTO.NewPassword;
                }
            }
            set
            {
                if (PasswordResetDTO != null)
                {
                    PasswordResetDTO.NewPassword = value;

                    if (value != PasswordResetDTO.NewPassword)
                    {
                        RaisePropertyChangedEvent(nameof(NewPassword));
                    }
                }
            }

        }

        /// <summary>
        /// Password confirmation 
        /// </summary>
        public new string? ConfirmPassword
        {
            get
            {
                if (this.PasswordResetDTO == null)
                {
                    return null;
                }
                else
                {
                    return PasswordResetDTO.ConfirmPassword;
                }
            }
            set
            {
                if (PasswordResetDTO != null)
                {
                    PasswordResetDTO.ConfirmPassword = value;

                    if (value != PasswordResetDTO.ConfirmPassword)
                    {
                        RaisePropertyChangedEvent(nameof(ConfirmPassword));
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
