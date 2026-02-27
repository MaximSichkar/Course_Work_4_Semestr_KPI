namespace CoreComponents
{
    /// <summary>
    /// Represents possible results of processing user's login attempt
    /// </summary>
    public enum LoginProcessingResult
    {
        LoginSuccessful,
        AccountNotFound,
        AccountFoundPasswordMissmatched
    }
}
