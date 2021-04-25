namespace OGameEmptyPlanetFinder.OGame
{
    public class DFCoordinates : Coordinates
    {
        public int Metal { get; set; }
        public int Crystal { get; set; }
        public int Recyclers { get; set; }

        public DFCoordinates() { }

        public DFCoordinates(string coordinates) : 
            base(coordinates) { }

        public DFCoordinates(int galaxy, int sunsys, int planet, int metal, int crystal, int recyclers = 0)
            : base(galaxy, sunsys, planet) 
        {
            initRes(metal, crystal, recyclers);
        }

        public DFCoordinates(string coordinates, int metal, int crystal, int recyclers = 0)
            : base(coordinates)
        {
            initRes(metal, crystal, recyclers);
        }

        protected void initRes(int metal, int crystal, int recyclers = 0)
        {
            Metal = metal;
            Crystal = crystal;
            Recyclers = recyclers;
        }
    }
}
