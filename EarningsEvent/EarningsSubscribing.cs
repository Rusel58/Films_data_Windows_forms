using JSONObject;

namespace EarningsEvent
{
    /// <summary>
    /// EarningsSubscribing class for subscribing to earnings-related events.
    /// </summary>
    public static class EarningsSubscribing
    {
        // <summary>
        /// Subscribes to the Updated event of each movie in the provided list.
        /// </summary>
        /// <param name="movies">The list of movies to subscribe to.</param>
        public static void SubscribeEarnings(List<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                movie.Updated += EarningsChange.EarningsMovie_Updated;
            }
        }

        /// <summary>
        /// Subscribes to the Updated event of the provided movie.
        /// </summary>
        /// <param name="movie">The movie to subscribe to.</param>
        public static void SubscribeEarning(Movie movie)
        {
            movie.Updated += EarningsChange.EarningsMovie_Updated;
        }
    }
}