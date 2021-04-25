using System;

namespace OGameEmptyPlanetFinder.OGame
{
    public class Ship
    {
        public String Type { get; set; }
        public int Count { get; set; }
        protected int Damage { get; set; }
        protected int Shield { get; set; }
        protected int Capacity { get; set; }
        protected int Speed { get; set; }
        protected int UnitPoints { get; set; }
        protected int DeuteriumConsume { get; set; }

        public Ship() { }

        public Ship(string type, int count)
        {
            Type = type;
            Count = count;
        }
    }
}
