namespace Validation
{
    /// <summary>
    /// Validator for finding digit in value
    /// </summary>
    public static class AnyCharIsDigitValidator
    {
        /// <summary>
        /// Method for finding digit in value
        /// </summary>
        /// <param name="value"> value for validation</param>
        /// <param name="name"> name of value</param>
        /// <param name="throwException"></param>
        /// <returns>True, if al validation req was meeted</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool Validate(string value, string name, bool throwException = false)
        {
            //numbers in value
            if (value.Any(char.IsDigit))
            {
                if (throwException)
                {
                    throw new ArgumentOutOfRangeException(value, name + "Numbers in value");
                }

                return false;
            }

            return true;
        }
    }
}
