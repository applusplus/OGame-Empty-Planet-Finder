using System.Collections.Generic;
using Newtonsoft.Json;
using OGameEmptyPlanetFinder.HTTP;
using OGameEmptyPlanetFinder.OGame;

namespace OGameEmptyPlanetFinder.Settings
{
    public class SettingsEntity
    {
        public string ServerLanguage { get; set; }
        public LoginEntity Login { get; set; }
        public Coordinates StartCoordinates { get; set; }
        public Coordinates StopCoordinates { get; set; }
        public List<PlanetSettingEntity> PlanetLastSearch { get; set; }
        public decimal MinDFResources { get; set; }
        public List<DFSettingsEntity> DFLastSearch { get; set; }
        public ProxyEntity Proxy { get; set; }
        public bool AutoRefresh { get; set; }
        public int AutoRefreshInterval { get; set; }
        public AlertSettingsEntity AlertSettings { get; set; }

        public SettingsEntity()
        {
            Login = new LoginEntity();
            StartCoordinates = new Coordinates();
            StopCoordinates = new Coordinates();
            PlanetLastSearch = new List<PlanetSettingEntity>();
            DFLastSearch = new List<DFSettingsEntity>();
            Proxy = new ProxyEntity();
            AlertSettings = new AlertSettingsEntity();
        }
    }
}
