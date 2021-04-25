namespace OGameEmptyPlanetFinder.OGame
{
    public class PlanetEntity
    {
        public Coordinates Coordinates { get; set; }
        public string PlanetName { get; set; }
        public string PlanetID { get; set; }
        public string PlanetType { get; set; }

        public PlanetEntity() { }

        public PlanetEntity(Coordinates coordinates, string planetName, string planetID, string planetType = "") 
        {
            Coordinates = coordinates;
            PlanetName = planetName;
            PlanetID = planetID;
            PlanetType = planetType;
        }
    }
}
