using System.Text.RegularExpressions;

namespace Validation
{
    /// <summary>
    /// Validator for validating special characters of value
    /// </summary>
    public static class SpecialCharacterValidator
    {
        /// <summary>
        /// Method for validate special characters of given value 
        /// </summary>
        /// <param name="value"> value for validation</param>
        /// <param name="name"> Name of value</param>
        /// <param name="throwException">Argument for examination the problem</param>
        /// <returns>True, if al validation req was meeted</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool Validate(string value, string name, bool throwException = false)
        {
            //using for finding special charecters
            string pattern = @"[~`!@#$%^&*()_+=\[\]{}|\\;:'"",.<>/?]";


            //No special chars
            if (Regex.IsMatch(value, pattern))
            {
                if (throwException)
                {
                    throw new ArgumentOutOfRangeException(value, name + "Special char");
                }

                return false;
            }

            return true;
        }
    }
}
