using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



   namespace MunicipalityV4.Models
    {
        public class LocalEvent
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Title { get; set; }
            public string Category { get; set; }
            public string Location { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }
            public int Popularity { get; set; } = 0; // Engagement feature

            public override string ToString()
            {
                return $"{Title} | {Category} | {Date:dd MMM yyyy}";
            }
        }
    }


