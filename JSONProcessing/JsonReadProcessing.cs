using JSONObject;
using System.Text.Json;

namespace JSONProcessing
{
    /// <summary>
    /// Provides methods for reading and deserializing JSON data into Movie objects.
    /// </summary>
    public static class JsonReadProcessing
    {
        /// <summary>
        /// Gets the data from a JSON file and deserializes it into a list of Movie objects.
        /// </summary>
        /// <param name="path">The absolute path to the JSON file.</param>
        /// <returns>A list of Movie objects deserialized from the JSON file.</returns>
        public static List<Movie> GetData(string path)
        {
            return JsonDeserialization(path);
        }

        /// <summary>
        /// Deserializes JSON data from a file into a list of Movie objects.
        /// </summary>
        /// <param name="path">The absolute path to the JSON file.</param>
        /// <returns>A list of Movie objects deserialized from the JSON file.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the deserialized list of movies is null.</exception>
        public static List<Movie> JsonDeserialization(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new MovieDeserializer());
                options.Converters.Add(new ActorDeserializer());
                List<Movie>? movies = JsonSerializer.Deserialize<List<Movie>>(fileStream, options);

                if (movies == null)
                {
                    throw new ArgumentNullException(nameof(movies));
                }

                return movies;
            }
        }
    }
}