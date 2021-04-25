namespace OGameEmptyPlanetFinder.HTTP.JsonEntities
{
    public class UserEntity
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string gameforgeAccountId { get; set; }
        public bool validated { get; set; }
        public bool portable { get; set; }
        public bool unlinkedAccounts { get; set; }
        public bool migrationRequired { get; set; }
        public string email { get; set; }
        public string unportableName { get; set; }
    }
}
