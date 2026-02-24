using DataTrasferObjectInterfaces;

namespace DataTrasferObject
{
    /// <summary>
    /// Provides data trasfer objet functionality
    /// </summary>
    public class DataTransferObject : IDataTransferObject
    {
        #region Properties

        /// <summary>
        /// GUID of DTO
        /// </summary>
        public string? GUID
        {
            get; set;
        } = Guid.NewGuid().ToString();

        /// <summary>
        /// User's GUID wich created this object
        /// </summary>
        public string? CreatedByUserGUID
        {
            get; set;
        }

        /// <summary>
        /// Email of Client wich created this object
        /// </summary>
        public string? CreatedByUserEmail
        {
            get; set;
        }

        /// <summary>
        /// Client wich change data (Email)
        /// </summary>
        public string? ChangedByUserEmail
        {
            get; set;
        }

        /// <summary>
        /// Day of creation of this object
        /// </summary>
        public DateTime? DayOfCreation
        {
            get; set;
        } = DateTime.Now;

        /// <summary>
        /// Day of change data of this object
        /// </summary>
        public DateTime? DayOfChangeData
        {
            get; set;
        } = DateTime.Now;

        /// <summary>
        /// Indentifier of this object
        /// </summary>
        public int? Id
        {
            get; set;
        }

        /// <summary>
        /// Message of Validation (contains the validation message associated with the object)
        /// </summary>
        public string? ValidationMessage
        {
            get; set;
        }

        /// <summary>
        /// Type of Validation (contains the validation message type associated with the object)
        /// </summary>
        public int? ValidationMessageType
        {
            get; set;
        }

        #endregion
    }
}
