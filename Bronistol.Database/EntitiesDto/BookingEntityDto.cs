using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bronistol.Database.EntitiesDto
{
    public class BookingEntityDto
    {
        public ReasonEntityDto Reason { get; set; }
        public NoteEntityDto Note { get; set; }
        public PriorityEntityDto Priority { get; set; }
        public NameEntityDto Name { get; set; }
        public DateEntityDto SubmitDate { get; set; }
        public DateEntityDto AssignedDate { get; set; }
    }
}
