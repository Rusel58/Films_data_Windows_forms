namespace NotificationProcessing
{
    /// <summary>
    /// Represents the event arguments for the Updated event.
    /// </summary>
    public class UpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the time when the object was updated.
        /// </summary>
        public DateTime UpdatedTime;

        /// <summary>
        /// Initializes a new instance of the UpdatedEventArgs class with default values.
        /// </summary>
        public UpdatedEventArgs() { }

        /// <summary>
        /// Initializes a new instance of the UpdatedEventArgs class with the specified updated time.
        /// </summary>
        /// <param name="updatedTime">The time when the object was updated.</param>
        public UpdatedEventArgs(DateTime updatedTime)
        {
            UpdatedTime = updatedTime;
        }
    }
}