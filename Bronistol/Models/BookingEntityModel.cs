using Bronistol.Database.Enumerations;

namespace Bronistol.Models
{
    public class BookingEntityModel
    {
        public string Reason { get; set; }
        public string Note { get; set; }
        public Priority Priority { get; set; }
        public string MeetName { get; set; }
        public string AssignedDate { get; set; }
        public string SubmitDate { get; set; }
    }
}