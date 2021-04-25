namespace OGameEmptyPlanetFinder.Settings
{
    public class AlertSettingsEntity
    {
        public bool AlertSoundsEnabled { get; set; }
        public string AlertSoundsDirectory { get; set; }

        public AlertSettingsEntity() { }

        public AlertSettingsEntity(bool alertSoundsEnabled, string alertSoundsDirectory)
        {
            AlertSoundsEnabled = alertSoundsEnabled;
            AlertSoundsDirectory = alertSoundsDirectory;
        }
    }
}
