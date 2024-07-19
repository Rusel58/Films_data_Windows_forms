using IOController;
using InOut;
using JSONObject;
using JSONProcessing;
using DataProcessing;
using AutoSaverEvent;
using CustomException;
using EarningsEvent;

namespace _9_Davletov_CHW_3_2_pro
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            bool endOfProgram = false;
            List<Movie> movies = new List<Movie>();
            string path;
            bool firstDataInput = true;
            int menuChoice;
            while (!endOfProgram)
            {
                try
                {
                    // Check for first DataInput.
                    if (firstDataInput)
                    {
                        menuChoice = 1;
                    }
                    else
                    {
                        Output.PrintMenu();

                        menuChoice = Input.GetCorrectNumberFromUser("Выберите пункт меню: ", 1, 5);
                    }
                    switch (menuChoice)
                    {
                        case 1:
                            path = FIleProcessing.GetJsonPathFromUser();

                            // Set path of the file to AutoSaver's path.
                            AutoSaver.filePath = Path.GetFileName(path);

                            movies = JsonReadProcessing.GetData(path);
                            if (movies.Count == 0)
                                throw new InvalidFileFormatException("Считан файл без объектов, повторите ввод!");

                            // Subscribe movies on our events.
                            EarningsSubscribing.SubscribeEarnings(movies);
                            MovieSubscribing.SubscribeMovies(movies);

                            // Set movie objects to AutoSaver's objects.
                            AutoSaver.movies = movies;

                            ConsoleController.WriteLine("Данные успешно считаны!", ConsoleColor.Green);
                            firstDataInput = false;
                            break;
                        case 2:
                            movies = DataSort.Sort(movies, DataSort.IsReverse());

                            // Set movie objects to AutoSaver's objects.
                            AutoSaver.movies = movies;

                            ProgramProcessing.OutputTables(movies);
                            break;
                        case 3:
                            EditingProcessing.EditField(movies);

                            // Set movie objects to AutoSaver's objects.
                            AutoSaver.movies = movies;

                            ProgramProcessing.OutputTables(movies);
                            break;
                        case 4:
                            ProgramProcessing.OutputTables(movies);
                            break;
                        case 5:
                            endOfProgram = true;
                            break;
                    }
                    Output.PrintConsoleSeparetor();
                }

                catch (FileNotFoundException) // Catching the error that the file was not found.
                {
                    ConsoleController.WriteLine("Файл не был найден.", ConsoleColor.Red);
                }
                catch (ArgumentException) // Catching the error related to the file name.
                {
                    ConsoleController.WriteLine("Введено некорректное название файла.", ConsoleColor.Red);
                }
                catch (IOException) // Catching the error when opening a file.
                {
                    ConsoleController.WriteLine("При открытии файла произошла ошибка.", ConsoleColor.Red);
                }
                catch (InvalidFileFormatException ex) // Catching the error if file format is incorrect.
                {
                    ConsoleController.WriteLine($"Ошибка: {ex.Message}", ConsoleColor.Red);
                }
                catch (Exception ex) // Catching the remaining errors.
                {
                    ConsoleController.WriteLine($"Ошибка: {ex.Message}", ConsoleColor.Red);
                }
            }
        }
    }
}