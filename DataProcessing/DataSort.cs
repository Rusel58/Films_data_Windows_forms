using JSONObject;
using InOut;

namespace DataProcessing
{
    /// <summary>
    /// Static class for sorting a list of movies.
    /// </summary>
    public static class DataSort
    {
        /// <summary>
        /// Sorts the list of movies by the header chosen by the user.
        /// </summary>
        /// <param name="movies">The list of movies to be sorted.</param>
        /// <param name="reverse">A flag indicating whether to sort in reverse order.</param>
        /// <returns>The sorted list of movies.</returns>
        public static List<Movie> Sort(List<Movie> movies, bool reverse)
        {
            string header = Input.GetHeaderFromUser();
            IEnumerable<Movie> sortedMovies = GetSortedMovies(movies, header);

            if (reverse)
            {
                sortedMovies = sortedMovies.Reverse();
            }

            return sortedMovies.ToList();
        }

        /// <summary>
        /// Returns a sorted list of movies by the given header.
        /// </summary>
        /// <param name="movies">The list of movies to be sorted.</param>
        /// <param name="header">The header to sort the movies by.</param>
        /// <returns>The sorted list of movies.</returns>
        private static IEnumerable<Movie> GetSortedMovies(List<Movie> movies, string header)
        {
            return movies.OrderBy(b => MovieProcessing.GetClassField(b, header));
        }

        /// <summary>
        /// Getting boolean answer if sort is reverse.
        /// </summary>
        /// <returns>Boolean answer.</returns>
        public static bool IsReverse()
        {
            if (Input.VariantsForSort() == 1)
            {
                return false;
            }
            return true;
        }
    }
}