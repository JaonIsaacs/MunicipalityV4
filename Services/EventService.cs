using System;
using System.Collections.Generic;
using MunicipalityV4.Models;

namespace MunicipalityV4.Services
{
    public static class EventService
    {
        private static SortedDictionary<DateTime, Queue<Event>> events = new SortedDictionary<DateTime, Queue<Event>>();
        private static HashSet<string> categories = new HashSet<string>();
        private static Queue<Event> recommendationQueue = new Queue<Event>();

        static EventService()
        {
            SeedSampleEvents();
        }

        public static void SeedSampleEvents()
        {
            AddEvent(new Event { Title = "Community Clean-Up", Category = "Environment", Date = DateTime.Today.AddDays(2), Description = "Join the neighborhood clean-up!" });
            AddEvent(new Event { Title = "Town Hall Meeting", Category = "Governance", Date = DateTime.Today.AddDays(5), Description = "Discuss new city projects." });
            AddEvent(new Event { Title = "Cultural Fair", Category = "Community", Date = DateTime.Today.AddDays(10), Description = "Celebrate local traditions!" });
        }

        public static void AddEvent(Event ev)
        {
            categories.Add(ev.Category);
            if (!events.ContainsKey(ev.Date))
                events[ev.Date] = new Queue<Event>();
            events[ev.Date].Enqueue(ev);
        }

        public static IEnumerable<Event> GetUpcoming()
        {
            foreach (var kvp in events)
            {
                if (kvp.Key >= DateTime.Today)
                {
                    foreach (var ev in kvp.Value)
                        yield return ev;
                }
            }
        }

        public static IEnumerable<Event> SearchEvents(string category, DateTime? date)
        {
            recommendationQueue.Clear();

            foreach (var ev in GetUpcoming())
            {
                bool matches = (string.IsNullOrEmpty(category) || ev.Category == category)
                               && (!date.HasValue || ev.Date.Date == date.Value.Date);
                if (matches)
                {
                    recommendationQueue.Enqueue(ev);
                    yield return ev;
                }
            }
        }

        public static IEnumerable<Event> GetRecommendations()
        {
            foreach (var ev in recommendationQueue)
                yield return ev;
        }

        public static HashSet<string> GetCategories() => categories;
    }
}
