using IOController;
using JSONObject;

namespace InOut
{
    /// <summary>
    /// A class for outputting data to the console.
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// Gets a correct number from the user within a specified range.
        /// </summary>
        /// <param name="message">The message to display to the user.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The user's choice as an integer.</returns>
        public static int GetCorrectNumberFromUser(string message, int min, int max)
        {
            while (true)
            {
                ConsoleController.Write(message, ConsoleColor.Blue);

                if (int.TryParse(ConsoleController.ReadLine(), out int number) &&
                    number >= min && number <= max)
                    return number;

                ConsoleController.WriteLine("Некорректные данные, повторите ввод!", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Gets the header to sort the movies by from the user.
        /// </summary>
        /// <returns>The header as a string.</returns>
        public static string GetHeaderFromUser()
        {
            Output.PrintChoicesForHeader();

            int choice = GetCorrectNumberFromUser("Выберите нужный пункт: ", 1, 7);
            string[] choices = { "movieId", "movieTitle", "earnings", "actorsPercent", "releaseYear",
            "genre", "rating"};
            return choices[choice - 1];
        }

        /// <summary>
        /// Gets the field value from the user based on the specified field name and type.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="type">The type of the field (string, double, or int).</param>
        /// <returns>The field value as an object.</returns>
        public static object GetFieldFromUser(string fieldName, string type)
        {
            ConsoleController.Write($"Введите значение для поля {fieldName}: ", ConsoleColor.Blue);
            return GetValueFromUser(type);
        }

        /// <summary>
        /// Gets the value from the user based on the specified type.
        /// </summary>
        /// <param name="type">The type of the value (string, double, or int).</param>
        /// <returns>The value as an object.</returns>
        private static object GetValueFromUser(string type)
        {
            if (type == "string")
            {
                return ConsoleController.ReadLine() ?? string.Empty;
            }
            else if (type == "double")
            {
                return GetDoubleFromUser();
            }
            else
            {
                return GetIntFromUser();
            }
        }

        /// <summary>
        /// Gets a double value from the user.
        /// </summary>
        /// <returns>The double value entered by the user.</returns>
        private static double GetDoubleFromUser()
        {
            while (true)
            {
                if (double.TryParse(ConsoleController.ReadLine(), out double num))
                {
                    return num;
                }
                ConsoleController.Write("Invalid input, please enter a double value: ", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Gets an integer value from the user.
        /// </summary>
        /// <returns>The integer value entered by the user.</returns>
        private static int GetIntFromUser()
        {
            while (true)
            {
                if (int.TryParse(ConsoleController.ReadLine(), out int num))
                {
                    return num;
                }
                ConsoleController.Write("Некорректные данные, введите целое число: ", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Gets variant of sort.
        /// </summary>
        /// <returns>1 if the user wants to display data in the direct order, 2 otherwise.</returns>
        public static int VariantsForSort()
        {
            ConsoleController.WriteLine("Выберите в каком порядке отсортировать:", ConsoleColor.Cyan);
            ConsoleController.WriteLine("1. В прямом порядке.", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("2. В обратном порядке.", ConsoleColor.DarkGreen);
            return GetCorrectNumberFromUser(("Выберите нужный пункт: "), 1, 2);
        }

        /// <summary>
        /// Gets the index of the movie to edit from the user for the given movie.
        /// </summary>
        /// <param name="movie">The movie for which the actor is being selected.</param>
        /// <returns>The index of the selected actor.</returns>
        public static int ObjectVariantsForEditing(List<Movie> movies)
        {
            ConsoleController.WriteLine("Выберите объект по его названию:", ConsoleColor.Cyan);
            for (int i = 0; i < movies.Count; i++)
            {
                ConsoleController.WriteLine($"{i + 1}. {movies[i].MovieTitle}", ConsoleColor.DarkGreen);
            }
            return GetCorrectNumberFromUser("Выберите нужный пункт: ", 1, movies.Count) - 1;
        }

        /// <summary>
        /// Gets the index of the actor to edit from the user for the given movie.
        /// </summary>
        /// <param name="movie">The movie for which the actor is being selected.</param>
        /// <returns>The index of the selected actor.</returns>
        public static int ObjectActorVariantsForEditing(Movie movie)
        {

            ConsoleController.WriteLine("Выберите объект по его названию: ", ConsoleColor.Cyan);

            List<Actor> actors = movie.Actors;
            for (int i = 0; i < actors.Count; i++)
            {
                ConsoleController.WriteLine($"{i + 1}. {actors[i].ActorName}", ConsoleColor.DarkGreen);
            }
            return GetCorrectNumberFromUser("Выберите нужный пункт: ", 1, actors.Count) - 1;
        }

        /// <summary>
        /// Gets the index of the movie field to edit from the user.
        /// </summary>
        /// <returns>The index of the selected movie field.</returns>
        public static int MovieVariantsForEditing()
        {
            ConsoleController.WriteLine("Выберите поле Фильмов для редактирование:", ConsoleColor.Cyan);
            ConsoleController.WriteLine("1. movieTitle\n2. earnings" +
                "\n3. actorsPercent\n4. releaseYear\n5. genre\n6. rating\n7. actors", ConsoleColor.DarkGreen);
            int choice = GetCorrectNumberFromUser("Выберите нужный пункт: ", 1, 7);
            return choice;
        }

        /// <summary>
        /// Gets the index of the actor field to edit from the user.
        /// </summary>
        /// <returns>The index of the selected actor field.</returns>
        public static int ActorVariantsForEditing()
        {
            ConsoleController.WriteLine("Выберите поле Актеров для редактирования", ConsoleColor.Cyan);
            ConsoleController.WriteLine("1. actorName\n2. nationality", ConsoleColor.DarkGreen);
            return GetCorrectNumberFromUser("Выберите нужный пункт: ", 1, 2) + 6;
        }

        /// <summary>
        /// Gets the user's choice whether to display actor data or not.
        /// </summary>
        /// <returns>1 if the user wants to display actor data, 2 otherwise.</returns>
        public static int GetChoiceForActorVariants()
        {
            ConsoleController.WriteLine("Желаете ли вы вывести данные об актерах?", ConsoleColor.Cyan);
            ConsoleController.WriteLine("1. Да", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("2. Нет", ConsoleColor.DarkGreen);
            return GetCorrectNumberFromUser("Выберите нужный пункт: ", 1, 2);
        }
    }
}