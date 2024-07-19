using IOController;

namespace InOut
{
    /// <summary>
    /// A class for printing data to the console.
    /// </summary>
    public static class Output
    {
        /// <summary>
        /// Prints the main menu options to the console.
        /// </summary>
        public static void PrintMenu()
        {
            ConsoleController.WriteLine("Меню:", ConsoleColor.Cyan);
            ConsoleController.WriteLine("1. Считать данные из файла.", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("2. Отсортировать данные по одному из полей.", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("3. Изменить поле объекта.", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("4. Вывести записи.", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("5. Выход из программы.", ConsoleColor.DarkGreen);
        }

        /// <summary>
        /// Prints the possible header options for sorting.
        /// </summary>
        public static void PrintChoicesForHeader()
        {
            ConsoleController.WriteLine("Возможные заголовки:", ConsoleColor.Cyan);
            ConsoleController.WriteLine("1. movieId\n2. movieTitle\n3. earnings" +
                "\n4. actorsPercent\n5. releaseYear\n6. genre\n7. rating", ConsoleColor.DarkGreen);
        }

        /// <summary>
        /// Separets data in console.
        /// </summary>
        public static void PrintConsoleSeparetor()
        {
            Console.WriteLine('\n');
        }
    }
}