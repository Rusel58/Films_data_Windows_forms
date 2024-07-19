using IOController;
namespace JSONProcessing
{
    /// <summary>
    /// Provides utility methods for file processing operations.
    /// </summary>
    public static class FIleProcessing
    {
        /// <summary>
        /// Prompts the user to enter the absolute path of a JSON file and validates its existence.
        /// </summary>
        /// <returns>The absolute path of the JSON file if it exists, otherwise continues prompting the
        /// user until a valid path is provided.</returns>
        public static string GetJsonPathFromUser()
        {
            while (true)
            {
                ConsoleController.Write("Введите абсолютный путь файла (без кавычек): ", ConsoleColor.Blue);

                string path = ConsoleController.ReadLine();
                if (File.Exists(path))
                    return path;
                ConsoleController.WriteLine("Файл не найден, повторите ввод!", ConsoleColor.Red);
            }
        }
    }
}