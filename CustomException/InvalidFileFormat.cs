namespace CustomException
{
    /// <summary>
    /// The error is thrown when the file does not match the format.
    /// </summary>
    public class InvalidFileFormatException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFileFormatException"/> class.
        /// </summary>
        public InvalidFileFormatException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFileFormatException"/> class 
        /// with a error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidFileFormatException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFileFormatException"/> class 
        /// with a error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message of the current exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidFileFormatException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
    }
}