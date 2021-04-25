using System;

namespace OGameEmptyPlanetFinder.HTTP.JsonEntities
{
    namespace ServerEntities
    {
        public class Settings
        {
            public int aks { get; set; }
            public int fleetSpeed { get; set; }
            public int wreckField { get; set; }
            public string serverLabel { get; set; }
            public int economySpeed { get; set; }
            public int planetFields { get; set; }
            public int universeSize { get; set; }
            public string serverCategory { get; set; }
            public int espionageProbeRaids { get; set; }
            public int premiumValidationGift { get; set; }
            public int debrisFieldFactorShips { get; set; }
            public int debrisFieldFactorDefence { get; set; }
        }

        public class Server
        {
            public string language { get; set; }
            public int number { get; set; }
            public string name { get; set; }
            public int playerCount { get; set; }
            public int playersOnline { get; set; }
            public DateTime opened { get; set; }
            public DateTime startDate { get; set; }
            public object endDate { get; set; }
            public int serverClosed { get; set; }
            public int prefered { get; set; }
            public int signupClosed { get; set; }
            public Settings settings { get; set; }
        }
    }
}
