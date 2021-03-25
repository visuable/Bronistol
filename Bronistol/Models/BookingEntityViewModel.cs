namespace Bronistol.Models
{
    public class BookingEntityViewModel
    {
        public NameEntityViewModel Name { get; set; }
        public DateEntityViewModel SubmitDate { get; set; }
        public DateEntityViewModel AssignedDate { get; set; }
        public NoteEntityViewModel Note { get; set; }
        public ReasonEntityViewModel Reason { get; set; }
        public PriorityEntityViewModel Priority { get; set; }
    }
}