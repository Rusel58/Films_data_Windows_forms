using JSONObject;

namespace AutoSaverEvent
{
    /// <summary>
    /// The ActorSubscribing class for subscribing actor object to AutoSaverEvent.
    /// </summary>
    public static class ActorSubscribing
    {
        /// <summary>
        /// Subscribes the actor objects.
        /// </summary>
        /// <param name="actors">The actor objects.</param>
        public static void SubscribeActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                actor.Updated += AutoSaver.Actor_Updated;
            }
        }

        /// <summary>
        /// Subscribes the actor object.
        /// </summary>
        /// <param name="actor">The actor object.</param>
        public static void SubscribeActor(Actor actor)
        {
            actor.Updated += AutoSaver.Actor_Updated;
        }
    }
}