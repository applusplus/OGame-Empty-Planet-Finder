using System;
using System.Collections.Generic;

namespace OGameEmptyPlanetFinder.OGame
{
    public class PlayerInfo
    {
        private static PlayerInfo instance;
        private static object syncRoot = new Object();

        public static PlayerInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new PlayerInfo();
                    }
                }
                return instance;
            }            
        }

        public ResourceEntity Resources { get; set; }

        private List<FleetMove> _fleetMove;
        public List<FleetMove> FleetMove
        {
            get { return _fleetMove ?? (_fleetMove = new List<FleetMove>()); }
            set => _fleetMove = value;
        }

        public PlanetEntity CurrentPlanet { get; set; }

        public string UniverseID { get; set; }
        public string UniverseName { get; set; }
        public string UniverseSpeed { get; set; }
        public string PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string AllianceID { get; set; }
        public string AllianceTag { get; set; }
        public string AllianceName { get; set; }

        public List<PlanetEntity> Planets { get; set; }

        private PlayerInfo() { Planets = new List<PlanetEntity>(); }
    }
}
