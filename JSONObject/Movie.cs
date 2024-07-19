using NotificationProcessing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSONObject
{
    /// <summary>
    /// Represents a movie.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Gets the unique identifier of the movie.
        /// </summary>
        [JsonPropertyName("movieId")]
        public Guid MovieId { get; }

        /// <summary>
        /// Gets the title of the movie.
        /// </summary>
        [JsonPropertyName("movieTitle")]
        public string MovieTitle { get; }

        /// <summary>
        /// Gets the total earnings of the movie.
        /// </summary>
        [JsonPropertyName("earnings")]
        public double Earnings { get; }

        /// <summary>
        /// Gets the percentage of earnings allocated to actors.
        /// </summary>
        [JsonPropertyName("actorsPercent")]
        public double ActorsPercent { get; }

        /// <summary>
        /// Gets the release year of the movie.
        /// </summary>
        [JsonPropertyName("releaseYear")]
        public int ReleaseYear { get; }

        /// <summary>
        /// Gets the genre of the movie.
        /// </summary>
        [JsonPropertyName("genre")]
        public string Genre { get; }

        /// <summary>
        /// Gets the rating of the movie.
        /// </summary>
        [JsonPropertyName("rating")]
        public double Rating { get; }

        /// <summary>
        /// Gets the list of actors in the movie.
        /// </summary>
        [JsonPropertyName("actors")]
        public List<Actor> Actors { get; }

        /// <summary>
        /// Initializes a new instance of the Movie class with default values.
        /// </summary>
        public Movie()
        {
            MovieId = Guid.NewGuid();
            MovieTitle = string.Empty;
            Genre = string.Empty;
            Actors = new List<Actor>();
        }

        /// <summary>
        /// Initializes a new instance of the Movie class with the specified values.
        /// </summary>
        /// <param name="movieId">The unique identifier of the movie.</param>
        /// <param name="movieTitle">The title of the movie.</param>
        /// <param name="earnings">The total earnings of the movie.</param>
        /// <param name="actorsPercent">The percentage of earnings allocated to actors.</param>
        /// <param name="releaseYear">The release year of the movie.</param>
        /// <param name="genre">The genre of the movie.</param>
        /// <param name="rating">The rating of the movie.</param>
        /// <param name="actor">The list of actors in the movie.</param>
        public Movie(Guid movieId, string? movieTitle, double earnings, double actorsPercent,
            int releaseYear, string? genre, double rating, List<Actor>? actor)
        {
            this.MovieId = movieId;
            this.MovieTitle = movieTitle ?? string.Empty;
            this.Earnings = earnings;
            this.ActorsPercent = actorsPercent;
            this.ReleaseYear = releaseYear;
            this.Genre = genre ?? string.Empty;
            this.Rating = rating;
            this.Actors = actor ?? new List<Actor>();
        }

        /// <summary>
        /// Converts the movie object to a JSON string.
        /// </summary>
        /// <returns>The JSON string representation of the movie object.</returns>
        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Occurs when the movie properties are updated.
        /// </summary>
        public event EventHandler<UpdatedEventArgs>? Updated;

        /// <summary>
        /// Notifies the Updated event with the current date and time.
        /// </summary>
        public void NotifyUpdated()
        {
            Updated?.Invoke(this, new UpdatedEventArgs(DateTime.Now));
        }

        /// <summary>
        /// Occurs when the movie earnings or actorsPercent are updated.
        /// </summary>
        public event EventHandler<EventArgs>? EarningsUpdated;

        /// <summary>
        /// Notifies the EarningsUpdated event.
        /// </summary>
        public void EarningsNotifyUpdated()
        {
            EarningsUpdated?.Invoke(this, new EventArgs());
        }
    }
}