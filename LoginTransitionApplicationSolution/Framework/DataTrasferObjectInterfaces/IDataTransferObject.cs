namespace DataTrasferObjectInterfaces
{
    /// <summary>
    /// Provides data trasfer objet functionality
    /// </summary>
    public interface IDataTransferObject
    {
        #region Properties

        /// <summary>
        /// GUID of DTO
        /// </summary>
        string? GUID
        {
            get; set;
        }

        /// <summary>
        /// User's GUID wich created this object
        /// </summary>
        string? CreatedByUserGUID
        {
            get; set;
        }

        /// <summary>
        /// Email of Client wich created this object
        /// </summary>
        string? CreatedByUserEmail
        {
            get; set;
        }

        /// <summary>
        /// Client wich change data (Email)
        /// </summary>
        string? ChangedByUserEmail
        {
            get; set;
        }

        /// <summary>
        /// Day of creation of this object
        /// </summary>
        DateTime? DayOfCreation
        {
            get; set;
        }

        /// <summary>
        /// Day of change data of this object
        /// </summary>
        DateTime? DayOfChangeData
        {
            get; set;
        }

        /// <summary>
        /// Indentifier of this object
        /// </summary>
        int? Id
        {
            get; set;
        }

        /// <summary>
        /// Message of Validation (contains the validation message associated with the object)
        /// </summary>
        string? ValidationMessage
        {
            get; set;
        }

        /// <summary>
        /// Type of Validation (contains the validation message type associated with the object)
        /// </summary>
        int? ValidationMessageType
        {
            get; set;
        }

        #endregion
    }
}
