namespace Bronistol.Database.DbEntities
{
    public class NameEntity : DbEntity
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string OrganizationName { get; set; }
    }
}