using JSONObject;
using NotificationProcessing;
using AutoSaverEvent;

namespace EarningsEvent
{
    /// <summary>
    /// EarningsChange class for realising EarningsEvent.
    /// </summary>
    public static class EarningsChange
    {
        /// <summary>
        /// Handles the Updated event of an EarninngsMovie.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        public static void EarningsMovie_Updated(object? sender, UpdatedEventArgs e)
        {
            ChangeEarnings(sender);
        }

        /// <summary>
        /// Changes the earnings of actors in a movie based on the movie's earnings and actors' percentage.
        /// </summary>
        /// <param name="sender">The movie object for which earnings need to be changed.</param>
        private static void ChangeEarnings(object? sender)
        {
            if (sender == null) return;
            Movie movie = (Movie)sender;
            List<Actor> actors = movie.Actors;
            double actorEarnings = Math.Round(movie.Earnings * movie.ActorsPercent / 100 / actors.Count, 2);
            for (int i = 0; i < actors.Count; i++)
            {
                actors[i] = EditActorEarning(actors[i], actorEarnings);
                ActorSubscribing.SubscribeActor(actors[i]);
            }
        }

        /// <summary>
        /// Edits the earnings of an actor.
        /// </summary>
        /// <param name="actor">The actor to edit.</param>
        /// <param name="value">The new earnings of the actor.</param>
        /// <returns>The updated actor object.</returns>
        private static Actor EditActorEarning(Actor actor, double value)
        {
            return new Actor(actor.ActorId, actor.ActorName,
                            actor.Nationality, value);
        }
    }
}