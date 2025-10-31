using System;

namespace MunicipalityV4.Models
{
    public enum RequestStatus { Submitted, InProgress, OnHold, Completed, Cancelled }

    public class ServiceRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public int Priority { get; set; } // lower = higher priority
        public DateTime CreatedAt { get; set; }

        public ServiceRequest(int id, string title, string desc, RequestStatus status, int priority)
        {
            Id = id;
            Title = title;
            Description = desc;
            Status = status;
            Priority = priority;
            CreatedAt = DateTime.Now;
        }

        public override string ToString() => $"[{Id}] {Title} ({Status})";
    }
}
