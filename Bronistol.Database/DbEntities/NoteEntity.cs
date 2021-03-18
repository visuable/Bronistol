using System.Diagnostics.CodeAnalysis;

namespace Bronistol.Database.DbEntities
{
    public class NoteEntity : DbEntity
    {
        [AllowNull] public string Description { get; set; }
    }
}