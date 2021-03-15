using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Bronistol.Database.DbEntities
{
    public class NoteEntity : DbEntity
    {
        [AllowNull]
        public string Description { get; set; }
    }
}
