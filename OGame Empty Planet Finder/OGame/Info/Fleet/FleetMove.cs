using System;
using System.Collections.Generic;

namespace OGameEmptyPlanetFinder.OGame
{
    public class FleetMove
    {
        public MissionType Mission { get; set; }
        public Coordinates Origin { get; set; }
        public int Fleet { get; set; }
        public Coordinates Target { get; set; }
        public DateTime ArrivalTime { get; set; }
        public bool FleetReturns { get; set; }
        public string OriginPlayer { get; set; }
        public string TargetPlanet { get; set; }
        public bool IsEnemy { get; set; }

        public FleetMove() { }

        public FleetMove(MissionType mission, Coordinates origin, int fleet, Coordinates target, DateTime arrivalTime, 
            bool fleetReturns, string originPlayer, string targetPlanet, bool isEnemy)
        {
            Mission = mission;
            Origin = origin;
            Fleet = fleet;
            Target = target;
            ArrivalTime = arrivalTime;
            FleetReturns = fleetReturns;
            OriginPlayer = originPlayer;
            TargetPlanet = targetPlanet;
            IsEnemy = isEnemy;
        }

        public bool isCurrentFleetEnemy()
        {
            return IsEnemy && (MissionType.Spying.Equals(Mission) || MissionType.Attack.Equals(Mission) || MissionType.Destroy.Equals(Mission) || MissionType.AKS.Equals(Mission));
        }

        public static bool isEnemyPresence(List<FleetMove> fleetMoveList)
        {
            bool isEnemy = false;
            foreach (FleetMove fleet in fleetMoveList)
            {
                isEnemy = fleet.isCurrentFleetEnemy();
                if (isEnemy)
                {
                    break;
                }
            }
            return isEnemy;
        }

        public static MissionType getMostImportantMission(List<FleetMove> fleetMoveList)
        {
            MissionType missionType = MissionType.None;
            foreach (FleetMove fleet in fleetMoveList)
            {
                if (MissionType.None.Equals(missionType))
                {
                    missionType = fleet.Mission;
                }
                else if (MissionType.Destroy.Equals(fleet.Mission))
                {
                    missionType = fleet.Mission;
                    break;
                }
                else if (MissionType.AKS.Equals(fleet.Mission) && !MissionType.Destroy.Equals(missionType))
                {
                    missionType = fleet.Mission;
                }
                else if (MissionType.Attack.Equals(fleet.Mission) && (!MissionType.AKS.Equals(missionType) || !MissionType.Destroy.Equals(missionType)))
                {
                    missionType = fleet.Mission;
                }
                else if (MissionType.Spying.Equals(fleet.Mission) && (!MissionType.Attack.Equals(missionType) || !MissionType.AKS.Equals(missionType) || !MissionType.Destroy.Equals(missionType)))
                {
                    missionType = fleet.Mission;
                }
            }
            return missionType;
        }
    }

    public enum MissionType 
    {
        None = 0,
        Attack = 1,
        AKS = 2,
        Transport = 3,
        Station = 4,
        Hold = 5,
        Spying = 6,
        Colonising = 7,
        Recycle = 8,
        Destroy = 9,
        Expedition = 15
    }
}
