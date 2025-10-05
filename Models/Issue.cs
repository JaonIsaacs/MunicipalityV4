using System;
using System.Collections.Generic;

namespace MunicipalityV4.Models
{
    public class Issue
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<string> Attachments { get; set; } = new List<string>();
        public string Status { get; set; } = "Pending";
        public DateTime SubmittedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{Category} - {Location} ({Status})";
        }
    }
}
