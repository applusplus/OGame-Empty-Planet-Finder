namespace OGameEmptyPlanetFinder.Settings
{
    public class DFSettingsEntity
    {
        public string DFCoordinates { get; set; }
        public string DFMetal { get; set; }
        public string DFCrystal { get; set; }
        public string DFRecyclers { get; set; }

        public DFSettingsEntity() { }

        public DFSettingsEntity(string dfCoordinates, string dfMetal, string dfCrystal, string dfRecyclers)
        {
            DFCoordinates = dfCoordinates;
            DFMetal = dfMetal;
            DFCrystal = dfCrystal;
            DFRecyclers = dfRecyclers;
        }
    }
}
