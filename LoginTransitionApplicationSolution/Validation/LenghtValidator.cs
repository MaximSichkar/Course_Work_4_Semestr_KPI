
namespace Validation
{
    /// <summary>
    /// Validator for finding lenght of value
    /// </summary>
    public static class LenghtValidator
    {
        /// <summary>
        /// Method for validate lenght of given value (over lenght)
        /// </summary>
        /// <param name="value"> value for validation</param>
        /// <param name="name"> Name of value</param>
        /// <param name="neededLenght">Lenght of value which must be valideted</param>
        /// <param name="throwException">Argument for examination the problem</param>
        /// <returns>True, if al validation req was meeted</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool UpValidate(string? value, string name, int neededLenght, out string? errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                errorMessage = "ValueIsRequired";

                return false;
            }
            else
            {
                //Lenght must be under argument value "neededLenght"
                if (value.Length < neededLenght)
                {
                    errorMessage = string.Format($"Password lenght must be at least {neededLenght} amount:");

                    return false;
                }
            }

            errorMessage = null;

            return true;
        }

        /// <summary>
        /// Method for validate lenght of given value (under lenght)
        /// </summary>
        /// <param name="value">Concrete value</param>
        /// <param name="name">Name of value</param>
        /// <param name="neededLenght">Lenght of value which must be valideted</param>
        /// <param name="throwException">Argument for examination the problem</param>
        /// <returns>True, if al validation req was meeted</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool DownValidate(string? value, string name, int neededLenght, out string? errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                errorMessage = "Value is required";

                return false;
            }
            else
            {
                //Lenght must be under argument value "neededLenght"
                if (value.Length < neededLenght)
                {
                    errorMessage = $"Password lenght must be lower then {neededLenght} characters";

                    return false;
                }
            }

            errorMessage = null;

            return true;
        }

    }
}

