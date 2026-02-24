namespace DataTrasferObjectInterfaces
{
    /// <summary>
    /// Message data transfer object interface 
    /// </summary>
    public interface IMessageDTO
    {
        /// <summary>
        /// Text of the message
        /// </summary>
        string MessageText
        {
            get; set;
        }

        /// <summary>
        /// Type of message
        /// </summary>
        MessageTypes MessageType
        {
            get; set;
        }
    }
}
