namespace Validation
{
    /// <summary>
    /// Validator for finding null or white sapce in value
    /// </summary>
    public static class IsNullOrWhiteSpaceValidator
    {
        /// <summary>
        /// Method for finding null pr white space in value
        /// </summary>
        /// <param name="value"> value for validation</param>
        /// <param name="name"> name of value</param>
        /// <param name="throwException"></param>
        /// <returns>True, if al validation req was meeted</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool Validate(string value, string name, bool throwException = false)
        {
            //Space or null
            if (string.IsNullOrWhiteSpace(value) || value.Contains(' '))
            {
                if (throwException)
                {
                    throw new ArgumentNullException(value, name + "Spaces, or Null");
                }

                return false;
            }

            return true;
        }
    }
}
