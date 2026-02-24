namespace DataTrasferObjectInterfaces
{
    /// <summary>
    /// Message data transfer object
    /// </summary>
    public class MessageDTO : IMessageDTO
    {
        public string MessageText
        {
            get; set;
        } = default!;

        public MessageTypes MessageType
        {
            get; set;
        }

        /// <summary>
        /// Method for creating MessageDTO
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="type">Type of message</param>
        /// <returns>Created new MessageDTO</returns>
        public static MessageDTO Create(string message, MessageTypes type)
        {
            return new MessageDTO
            {
                MessageText = message,
                MessageType = type
            };
        }


    }
}
