using JSONObject;

namespace AutoSaverEvent
{
    /// <summary>
    /// The MovieSubscribing class for subscribing movie object to AutoSaverEvent.
    /// </summary>
    public static class MovieSubscribing
    {
        /// <summary>
        /// Subscribes the movie objects.
        /// </summary>
        /// <param name="movies">The movie objects.</param>
        public static void SubscribeMovies(List<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                movie.Updated += AutoSaver.Movie_Updated;
            }
        }

        /// <summary>
        /// Subscribes the movie object.
        /// </summary>
        /// <param name="movie">The movie object.</param>
        public static void SubscribeMovie(Movie movie)
        {
            movie.Updated += AutoSaver.Movie_Updated;
        }
    }
}