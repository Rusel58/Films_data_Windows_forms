using JSONObject;
using System.Text.Json.Serialization;
using System.Text.Json;
using CustomException;

namespace JSONProcessing
{
    /// <summary>
    /// Deserializes a Movie object from JSON.
    /// </summary>
    public class MovieDeserializer : JsonConverter<Movie>
    {
        /// <summary>
        /// Reads and deserializes the JSON representation of a Movie object.
        /// </summary>
        /// <param name="reader">The reader used to read the JSON data.</param>
        /// <param name="typeToConvert">The type to convert to.</param>
        /// <param name="options">The options to use during deserialization.</param>
        /// <returns>The deserialized Movie object.</returns>
        /// <exception cref="InvalidFileFormatException">Thrown if the format
        /// of movies objects is incorrect.</exception>
        public override Movie Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Guid movieId = default;
            string? movieTitle = default;
            double earnings = default;
            double actorsPercent = default;
            int releaseYear = default;
            string? genre = default;
            double rating = default;
            List<Actor>? actors = default;

            try
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        break;

                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        string propertyName = reader.GetString() ?? string.Empty;
                        reader.Read();

                        switch (propertyName)
                        {
                            case "movieId":
                                movieId = reader.GetGuid();
                                break;
                            case "movieTitle":
                                movieTitle = reader.GetString();
                                break;
                            case "earnings":
                                earnings = reader.GetDouble();
                                break;
                            case "actorsPercent":
                                actorsPercent = reader.GetDouble();
                                break;
                            case "releaseYear":
                                releaseYear = reader.GetInt32();
                                break;
                            case "genre":
                                genre = reader.GetString();
                                break;
                            case "rating":
                                rating = reader.GetDouble();
                                break;
                            case "actors":
                                actors = JsonSerializer.Deserialize<List<Actor>>(ref reader,
                                    new JsonSerializerOptions { Converters = { new ActorDeserializer() } });
                                if (actors?.Count == 0)
                                    throw new InvalidFileFormatException("Некорректный формат данных!");
                                break;
                            default:
                                throw new InvalidFileFormatException("Некорректный формат данных!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return new Movie(movieId, movieTitle, earnings, actorsPercent, releaseYear, genre, rating, actors);
        }

        /// <summary>
        /// Writes the JSON representation of a Movie object.
        /// </summary>
        /// <param name="writer">The writer used to write the JSON data.</param>
        /// <param name="value">The Movie object to serialize.</param>
        /// <param name="options">The options to use during serialization.</param>
        /// <exception cref="NotImplementedException">Thrown if the method is not realised.</exception>
        public override void Write(Utf8JsonWriter writer, Movie value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}