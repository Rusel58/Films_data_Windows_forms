using JSONObject;
using System.Text.Json.Serialization;
using System.Text.Json;
using CustomException;

namespace JSONProcessing
{
    /// <summary>
    /// Deserializes an Actor object from JSON.
    /// </summary>
    public class ActorDeserializer : JsonConverter<Actor>
    {
        /// <summary>
        /// Reads and deserializes the JSON representation of an Actor object.
        /// </summary>
        /// <param name="reader">The reader used to read the JSON data.</param>
        /// <param name="typeToConvert">The type to convert to.</param>
        /// <param name="options">The options to use during deserialization.</param>
        /// <returns>The deserialized Actor object.</returns>
        /// <exception cref="InvalidFileFormatException">Thrown if the format
        /// of actors objects is incorrect.</exception>
        public override Actor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Guid actorId = default;
            string? actorName = default;
            string? nationality = default;
            double earnings = default;

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
                            case "actorId":
                                actorId = reader.GetGuid();
                                break;
                            case "actorName":
                                actorName = reader.GetString() ?? string.Empty;
                                break;
                            case "nationality":
                                nationality = reader.GetString() ?? string.Empty;
                                break;
                            case "earnings":
                                earnings = reader.GetDouble();
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
            return new Actor(actorId, actorName, nationality, earnings);
        }

        /// <summary>
        /// Writes the JSON representation of an Actor object.
        /// </summary>
        /// <param name="writer">The writer used to write the JSON data.</param>
        /// <param name="value">The Actor object to serialize.</param>
        /// <param name="options">The options to use during serialization.</param>
        /// <exception cref="NotImplementedException">Thrown if the method is not realised.</exception>
        public override void Write(Utf8JsonWriter writer, Actor value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}