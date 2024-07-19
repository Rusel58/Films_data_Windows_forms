using JSONObject;
using InOut;
using AutoSaverEvent;
using EarningsEvent;

namespace DataProcessing
{
    /// <summary>
    /// Class for editing fields of movies and actors.
    /// </summary>
    public static class EditingProcessing
    {
        /// <summary>
        /// Edits the selected field of a movie or an actor.
        /// </summary>
        /// <param name="movies">The list of movies.</param>
        /// <returns>The list of movies with edited fields.</returns>
        public static List<Movie> EditField(List<Movie> movies)
        {
            int objectIndex = GetObjectIndexFromUser(movies);
            int fieldIndex = GetFieldIndexFromUser();
            int actorIndex = 0;

            if (fieldIndex == 7)
            {
                actorIndex = GetActorIndexFromUser(movies[objectIndex]);
                fieldIndex = GetActorFieldIndexFromUser();
            }

            EditSelectedField(movies, objectIndex, fieldIndex, actorIndex);

            return movies;
        }

        /// <summary>
        /// Gets the index of the movie to edit from the user.
        /// </summary>
        /// <param name="movies">The list of movies.</param>
        /// <returns>The index of the selected movie.</returns>
        private static int GetObjectIndexFromUser(List<Movie> movies)
        {
            return Input.ObjectVariantsForEditing(movies);
        }

        /// <summary>
        /// Gets the index of the field to edit from the user.
        /// </summary>
        /// <returns>The index of the selected field.</returns>
        private static int GetFieldIndexFromUser()
        {
            return Input.MovieVariantsForEditing();
        }

        /// <summary>
        /// Gets the index of the actor field to edit from the user.
        /// </summary>
        /// <returns>The index of the selected actor field.</returns>
        private static int GetActorFieldIndexFromUser()
        {
            return Input.ActorVariantsForEditing();
        }

        /// <summary>
        /// Edits the selected field of a movie or an actor.
        /// </summary>
        /// <param name="movies">The list of movies.</param>
        /// <param name="objectIndex">The index of the movie to edit.</param>
        /// <param name="fieldIndex">The index of the field to edit.</param>
        /// <param name="actorIndex">The index of the actor to edit (if applicable).</param>
        private static void EditSelectedField(List<Movie> movies, int objectIndex, int fieldIndex,
            int actorIndex)
        {
            Movie movie = movies[objectIndex];
            Actor actor = movies[objectIndex].Actors[actorIndex];
            switch (fieldIndex)
            {
                case 1:
                    string movieTitle = (string)Input.GetFieldFromUser("MovieTitle", "string");

                    movies[objectIndex] = new Movie(movie.MovieId, movieTitle, movie.Earnings,
                        movie.ActorsPercent, movie.ReleaseYear, movie.Genre, movie.Rating, movie.Actors);

                    SubscribeMovieToEvents(movies[objectIndex]);
                    break;
                case 2:
                    double earnings = (double)Input.GetFieldFromUser("Earnings", "double");

                    movies[objectIndex] = new Movie(movie.MovieId, movie.MovieTitle, earnings,
                        movie.ActorsPercent, movie.ReleaseYear, movie.Genre, movie.Rating, movie.Actors);

                    SubscribeMovieToEvents(movies[objectIndex]);

                    movies[objectIndex].EarningsNotifyUpdated();
                    break;
                case 3:
                    double actorsPercent = (double)Input.GetFieldFromUser("ActorsPercent", "double");

                    movies[objectIndex] = new Movie(movie.MovieId, movie.MovieTitle, movie.Earnings,
                        actorsPercent, movie.ReleaseYear, movie.Genre, movie.Rating, movie.Actors);

                    SubscribeMovieToEvents(movies[objectIndex]);

                    movies[objectIndex].EarningsNotifyUpdated();
                    break;
                case 4:
                    int releaseYear = (int)Input.GetFieldFromUser("ReleaseYear", "int");

                    movies[objectIndex] = new Movie(movie.MovieId, movie.MovieTitle, movie.Earnings,
                        movie.ActorsPercent, releaseYear, movie.Genre, movie.Rating, movie.Actors);

                    SubscribeMovieToEvents(movies[objectIndex]);
                    break;
                case 5:
                    string genre = (string)Input.GetFieldFromUser("Genre", "string");

                    movies[objectIndex] = new Movie(movie.MovieId, movie.MovieTitle, movie.Earnings,
                        movie.ActorsPercent, movie.ReleaseYear, genre, movie.Rating, movie.Actors);

                    SubscribeMovieToEvents(movies[objectIndex]);
                    break;
                case 6:
                    double rating = (double)Input.GetFieldFromUser("Rating", "double");

                    movies[objectIndex] = new Movie(movie.MovieId, movie.MovieTitle, movie.Earnings,
                        movie.ActorsPercent, movie.ReleaseYear, movie.Genre, rating, movie.Actors);

                    SubscribeMovieToEvents(movies[objectIndex]);
                    break;
                case 7:
                    string actorName = (string)Input.GetFieldFromUser("ActorName", "string");

                    movies[objectIndex].Actors[actorIndex] = new Actor(actor.ActorId, actorName,
                        actor.Nationality, actor.Earnings);

                    ActorSubscribing.SubscribeActor(movies[objectIndex].Actors[actorIndex]);
                    break;
                case 8:
                    string nationality = (string)Input.GetFieldFromUser("Nationality", "string");

                    movies[objectIndex].Actors[actorIndex] = new Actor(actor.ActorId, actor.ActorName,
                        nationality, actor.Earnings);

                    ActorSubscribing.SubscribeActor(movies[objectIndex].Actors[actorIndex]);
                    break;
            }
            if (fieldIndex >= 1 && fieldIndex <= 6)
                movies[objectIndex].NotifyUpdated();
            else
                movies[objectIndex].Actors[actorIndex].NotifyUpdated();
        }

        /// <summary>
        /// Sibscribes movie to events.
        /// </summary>
        /// <param name="movie">The movie object.</param>
        public static void SubscribeMovieToEvents(Movie movie)
        {
            MovieSubscribing.SubscribeMovie(movie);
            EarningsSubscribing.SubscribeEarning(movie);
        }

        /// <summary>
        /// Gets the index of the actor to edit from the user.
        /// </summary>
        /// <param name="movie">The movie for which the actor is being selected.</param>
        /// <returns>The index of the selected actor.</returns>
        private static int GetActorIndexFromUser(Movie movie)
        {
            return Input.ObjectActorVariantsForEditing(movie);
        }
    }
}