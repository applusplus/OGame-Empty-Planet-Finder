namespace OGameEmptyPlanetFinder.Settings
{
    public class PlanetSettingEntity
    {
        public string Coordinates { get; set; }
        public string Status { get; set; }

        public PlanetSettingEntity() { }

        public PlanetSettingEntity(string coordinates, string status)
        {
            Coordinates = coordinates;
            Status = status;
        }
    }
}
