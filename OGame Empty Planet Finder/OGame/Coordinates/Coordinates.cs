using System;
using System.Text;
using System.Text.RegularExpressions;

namespace OGameEmptyPlanetFinder.OGame
{
    public class Coordinates
    {
        public int Galaxy { get; set; }
        public int SunSys { get; set; }
        public int Planet { get; set; }
        public bool Destroyed { get; set; }

        public Coordinates() { }

        public Coordinates(string coordinates, bool isDestroyed = false)
        {
            initCoordinates(coordinates);
            Destroyed = isDestroyed;
        }

        public Coordinates(int galaxy, int sunsys, int planet, bool isDestroyed = false) 
        {
            Galaxy = galaxy;
            SunSys = sunsys;
            Planet = planet;
            Destroyed = isDestroyed;
        }

        protected void initCoordinates(string coordinates)
        {
            FormatException formatException = new FormatException("Wrong coordinates format!");
            Match match = Regex.Match(coordinates, @"\[{0,1}(\d{1}):\d{1,3}:\d{1,2}");
            if (!match.Success) { throw formatException; }
            Galaxy = Convert.ToInt32(match.Groups[1].Value);
            match = Regex.Match(coordinates, @"\d{1}:(\d{1,3}):\d{1,2}");
            if (!match.Success) { throw formatException; }
            SunSys = Convert.ToInt32(match.Groups[1].Value);
            match = Regex.Match(coordinates, @"\d{1}:\d{1,3}:(\d{1,2})\]{0,1}");
            if (!match.Success) { throw formatException; }
            Planet = Convert.ToInt32(match.Groups[1].Value);
        }

        public string getStatus()
        {
            return Destroyed ? "Destroyed" : "Free";
        }

        // Berechnung der SonnenSysteme die sich zwischen den Koordinaten befinden.
        public int differenceTo(Coordinates another)
        {
            // Die Anfang-SonnenSyste zählt mit, deshalb muss muss 1 - 1 = 1 sein.
            int sunSysDiff = another.SunSys + 1 - SunSys; 
            // hier darf 0 sein, falls wir in der selbe Galaxie bleiben
            int galaxyDiff = another.Galaxy - Galaxy;
            return galaxyDiff * sunSysDiff;
        }

        public override string ToString()
        {
            return new StringBuilder().Append(Galaxy).Append(":").Append(SunSys).Append(":").Append(Planet).ToString();
        }

        public int CompareTo(Coordinates another)
        {
            return (Galaxy.CompareTo(another.Galaxy) == 0 ? 
                    (SunSys.CompareTo(another.SunSys) == 0 ? Planet.CompareTo(another.Planet) 
                        : SunSys.CompareTo(another.SunSys)) : Galaxy.CompareTo(another.Galaxy));
        }

        public static int Compare(Coordinates x, Coordinates y)
        {
            return x.CompareTo(y);
        }
    }
}
