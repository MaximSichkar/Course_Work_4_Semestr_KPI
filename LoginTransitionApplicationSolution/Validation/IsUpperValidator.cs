namespace Validation
{
    /// <summary>
    /// Validator for finding first upper character in value
    /// </summary>
    public static class IsUpperValidator
    {
        /// <summary>
        /// Method for finding first upper character in value
        /// </summary>
        /// <param name="value"> value for validation</param>
        /// <param name="name"> name of value</param>
        /// <param name="throwException"></param>
        /// <returns>True, if al validation req was meeted</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool Validate(string value, string name, bool throwException = false)
        {
            //First letter must be Upper one
            if (!char.IsUpper(value[0]))
            {
                if (throwException)
                {
                    throw new ArgumentOutOfRangeException(value, name + "First letter must be Upper one");
                }

                return false;
            }

            return true;
        }
    }
}
