namespace Biyahe.Models
{
    public class QueueEntry
    {
        public int QueueID { get; set; }
        public int UserID { get; set; }
        public int RouteID { get; set; }
        public int? DriverID { get; set; } 
        public bool IsPriority { get; set; }
        public string Status { get; set; } // Waiting, Boarding, Boarded
        public int? QueuePosition { get; set; }
        public DateTime JoinedAt { get; set; }


        // Navigation — populated via JOIN queries
        public string UserFullName { get; set; }
        public string RouteCode { get; set; }

        //constructor for easier initialization
        public QueueEntry() { }
    }
}