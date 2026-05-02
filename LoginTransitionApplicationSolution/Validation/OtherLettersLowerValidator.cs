namespace Validation
{
    /// <summary>
    /// Validator for validating other characters in lower case of value
    /// </summary>
    public static class OtherLettersLowerValidator
    {
        /// <summary>
        /// Method for validate other characters in lower case of given value 
        /// </summary>
        /// <param name="value"> value for validation</param>
        /// <param name="name"> Name of value</param>
        /// <param name="throwException">Argument for examination the problem</param>
        /// <returns>True, if al validation req was meeted</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool Validate(string value, string name, bool throwException = false)
        {
            //Cycle for other letters if they are Upper, they must be in lower case
            for (int i = 1; i < value.Length; i++)
            {
                if (!char.IsLower(value[i]))
                {
                    if (throwException)
                    {
                        throw new ArgumentOutOfRangeException(value, name + "Special char");
                    }

                    return false;
                }
            }

            return true;
        }

    }
}
