using System.Text.Json;
using JSONObject;
using NotificationProcessing;
using IOController;

namespace AutoSaverEvent
{
    /// <summary>
    /// The AutoSaver class is responsible for automatically saving a collection of movies to a JSON file
    /// when any of the movies or their actors are updated.
    /// </summary>
    public static class AutoSaver
    {
        public static List<Movie>? movies;
        private static DateTime lastUpdateTime;
        public static string? filePath;


        /// <summary>
        /// Handles the Updated event of a movie.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The UpdatedEventArgs containing the updated time.</param>
        public static void Movie_Updated(object? sender, UpdatedEventArgs e)
        {
            CheckAndSave(e.UpdatedTime);
        }

        /// <summary>
        /// Handles the Updated event of an actor.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The UpdatedEventArgs containing the updated time.</param>
        public static void Actor_Updated(object? sender, UpdatedEventArgs e)
        {
            CheckAndSave(e.UpdatedTime);
        }

        /// <summary>
        /// Checks if the specified updated time is within the last 15 seconds.
        /// If so, it saves the collection of movies to the file.
        /// </summary>
        /// <param name="updatedTime">The time when the update occurred.</param>
        private static void CheckAndSave(DateTime updatedTime)
        {
            if ((updatedTime - lastUpdateTime).TotalSeconds <= 15)
            {
                SaveToJsonFile();
            }
            lastUpdateTime = updatedTime;
        }

        /// <summary>
        /// Saves the collection of movies to the specified file in JSON format.
        /// </summary>
        private static void SaveToJsonFile()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(movies, options);
            if (filePath != null)
            {
                File.WriteAllText(filePath, json);

                ConsoleController.WriteLine("Коллекция объектов была сохранена рядом с exe программы!", ConsoleColor.Green);
            }
            else
                throw new ArgumentNullException();
        }
    }
}