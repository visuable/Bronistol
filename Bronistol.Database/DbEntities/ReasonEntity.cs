using System.Diagnostics.CodeAnalysis;

namespace Bronistol.Database.DbEntities
{
    public class ReasonEntity : DbEntity
    {
        [NotNull] public string Description { get; set; }
    }
}