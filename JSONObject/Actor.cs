using NotificationProcessing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSONObject
{
    /// <summary>
    /// Represents an actor.
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Gets the unique identifier of the actor.
        /// </summary>
        [JsonPropertyName("actorId")]
        public Guid ActorId { get; }

        /// <summary>
        /// Gets the name of the actor.
        /// </summary>
        [JsonPropertyName("actorName")]
        public string ActorName { get; }

        /// <summary>
        /// Gets the nationality of the actor.
        /// </summary>
        [JsonPropertyName("nationality")]
        public string Nationality { get; }

        /// <summary>
        /// Gets the earnings of the actor.
        /// </summary>
        [JsonPropertyName("earnings")]
        public double Earnings { get; }

        /// <summary>
        /// Initializes a new instance of the Actor class with default values.
        /// </summary>
        public Actor()
        {
            ActorId = Guid.NewGuid();
            ActorName = string.Empty;
            Nationality = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the Actor class with the specified values.
        /// </summary>
        /// <param name="actorId">The unique identifier of the actor.</param>
        /// <param name="actorName">The name of the actor.</param>
        /// <param name="nationality">The nationality of the actor.</param>
        /// <param name="earnings">The earnings of the actor.</param>
        public Actor(Guid actorId, string? actorName, string? nationality, double earnings)
        {
            this.ActorId = actorId;
            this.ActorName = actorName ?? string.Empty;
            this.Nationality = nationality ?? string.Empty;
            this.Earnings = earnings;
        }

        /// <summary>
        /// Converts the actor object to a JSON string.
        /// </summary>
        /// <returns>The JSON string representation of the actor object.</returns>
        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Occurs when the actor properties are updated.
        /// </summary>
        public event EventHandler<UpdatedEventArgs>? Updated;

        /// <summary>
        /// Notifies the Updated event with the current date and time.
        /// </summary>
        public void NotifyUpdated()
        {
            Updated?.Invoke(this, new UpdatedEventArgs(DateTime.Now));
        }
    }
}