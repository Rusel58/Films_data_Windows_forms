namespace JSONObject
{
    /// <summary>
    /// Provides utility methods for processing movie objects.
    /// </summary>
    public static class MovieProcessing
    {
        /// <summary>
        /// Gets the value of a specific field from a movie object as a string.
        /// </summary>
        /// <param name="movie">The movie object.</param>
        /// <param name="header">The name of the field to retrieve.</param>
        /// <returns>The string representation of the requested field value, or an empty string if the field is not found.</returns>
        public static string GetClassField(Movie movie, string header)
        {
            string result = header switch
            {
                "movieId" => movie.MovieId.ToString(),
                "movieTitle" => movie.MovieTitle,
                "earnings" => movie.Earnings.ToString(),
                "actorsPercent" => movie.ActorsPercent.ToString(),
                "releaseYear" => movie.ReleaseYear.ToString(),
                "genre" => movie.Genre,
                "rating" => movie.Rating.ToString(),
                _ => String.Empty
            };
            return result;
        }
    }
}