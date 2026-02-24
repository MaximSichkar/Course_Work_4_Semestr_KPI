using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.INT
{
    /// <summary>
    /// Interface for PasswordResetModel
    /// </summary>
    public interface IPasswordReset
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
        public string? ConfirmPassword
        {
            get; set;
        }
    }
}
