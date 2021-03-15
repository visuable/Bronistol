using System;
using System.Collections.Generic;
using System.Text;

namespace Bronistol.Database.DbEntities
{
    public class BookingEntity : DbEntity
    {
        public ReasonEntity Reason { get; set; }
        public NoteEntity Note { get; set; }
        public PriorityEntity Priority { get; set; }
        public NameEntity Name { get; set; }
        public DateEntity SubmitDate { get; set; }
        public DateEntity AssignedDate { get; set; }
    }
}
