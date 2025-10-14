using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalityV4.Models;

namespace MunicipalityV4.Services
{
    public class EventService
    {
        private SortedDictionary<DateTime, LocalEvent> _events = new();
        private Queue<LocalEvent> _recentViews = new();  // Queue for recently viewed
        private Stack<LocalEvent> _undoStack = new();     // Stack for undo operations
        private HashSet<string> _categories = new();

        public EventService()
        {
            SeedSampleEvents();
        }

        public void SeedSampleEvents()
        {
            var sampleData = new List<LocalEvent>
            {
                new() { Title = "Community Cleanup", Category = "Environment", Location = "Central Park", Date = DateTime.Today.AddDays(2), Description = "Join us to clean the park." },
                new() { Title = "Farmers Market", Category = "Food", Location = "Town Square", Date = DateTime.Today.AddDays(3), Description = "Fresh produce from local farmers." },
                new() { Title = "Music Festival", Category = "Entertainment", Location = "Main Street", Date = DateTime.Today.AddDays(5), Description = "Live bands and performances." },
                new() { Title = "Art Exhibition", Category = "Culture", Location = "City Gallery", Date = DateTime.Today.AddDays(7), Description = "Explore local art talent." },
                new() { Title = "Tech Meetup", Category = "Technology", Location = "Innovation Hub", Date = DateTime.Today.AddDays(10), Description = "Network with tech enthusiasts." },
                new() { Title = "Blood Donation Drive", Category = "Health", Location = "Community Center", Date = DateTime.Today.AddDays(4), Description = "Donate blood and save lives." },
                new() { Title = "Book Fair", Category = "Education", Location = "Library", Date = DateTime.Today.AddDays(8), Description = "Buy and exchange books." },
                new() { Title = "Food Truck Festival", Category = "Food", Location = "Riverside Park", Date = DateTime.Today.AddDays(12), Description = "Enjoy street food and drinks." },
                new() { Title = "Charity Marathon", Category = "Sports", Location = "Downtown", Date = DateTime.Today.AddDays(15), Description = "Run for a cause." },
                new() { Title = "Job Fair", Category = "Employment", Location = "Convention Center", Date = DateTime.Today.AddDays(9), Description = "Meet top employers." },
                new() { Title = "Pet Adoption Day", Category = "Community", Location = "Animal Shelter", Date = DateTime.Today.AddDays(6), Description = "Find your furry friend!" },
                new() { Title = "Coding Bootcamp", Category = "Education", Location = "Tech Campus", Date = DateTime.Today.AddDays(11), Description = "Learn coding fundamentals." },
                new() { Title = "Yoga in the Park", Category = "Health", Location = "Central Park", Date = DateTime.Today.AddDays(1), Description = "Morning yoga for all ages." },
                new() { Title = "Local Theater Play", Category = "Entertainment", Location = "Civic Theater", Date = DateTime.Today.AddDays(13), Description = "Enjoy a classic play." },
                new() { Title = "Eco Seminar", Category = "Environment", Location = "Town Hall", Date = DateTime.Today.AddDays(14), Description = "Talks on sustainability." }
            };

            foreach (var e in sampleData)
            {
                _events[e.Date] = e;
                _categories.Add(e.Category);
            }
        }

        public IEnumerable<LocalEvent> GetAll() => _events.Values;

        public IEnumerable<string> GetCategories() => _categories;

        public IEnumerable<LocalEvent> Filter(string category, DateTime? date)
        {
            return _events.Values.Where(e =>
                (string.IsNullOrEmpty(category) || e.Category == category) &&
                (!date.HasValue || e.Date.Date == date.Value.Date));
        }

        public IEnumerable<LocalEvent> Sort(string criteria)
        {
            return criteria switch
            {
                "Date" => _events.Values.OrderBy(e => e.Date),
                "Category" => _events.Values.OrderBy(e => e.Category),
                "Name" => _events.Values.OrderBy(e => e.Title),
                _ => _events.Values
            };
        }

        public void RecordView(LocalEvent e)
        {
            _recentViews.Enqueue(e);
            if (_recentViews.Count > 10) _recentViews.Dequeue();
        }

        public void IncreasePopularity(LocalEvent e)
        {
            e.Popularity++;
        }

        public IEnumerable<LocalEvent> GetPopularEvents()
        {
            return _events.Values.OrderByDescending(e => e.Popularity).Take(5);
        }

        public void UndoLastAction()
        {
            if (_undoStack.Count > 0)
            {
                var restored = _undoStack.Pop();
                _events[restored.Date] = restored;
            }
        }
    }
}
