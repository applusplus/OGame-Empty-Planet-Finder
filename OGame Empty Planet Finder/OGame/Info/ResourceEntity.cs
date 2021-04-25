using System.Text;

namespace OGameEmptyPlanetFinder.OGame
{
    public class ResourceEntity
    {
        public int Metal { get; set;}
        public int Crystal { get; set; }
        public int Deuterium { get; set; }
        public int DarkMatter { get; set; }
        public int Energy { get; set; }

        public ResourceEntity() { }

        public ResourceEntity(int metal, int crystal, int deuterium, int darkmatter, int energy) 
        {
            Metal = metal;
            Crystal = crystal;
            Deuterium = deuterium;
            DarkMatter = darkmatter;
            Energy = energy;
        }

        public int Count()
        {
            return Metal + Crystal + Deuterium + DarkMatter + Energy;
        }

        public override string ToString()
        {
            return new StringBuilder().Append("Metal: ").Append(Metal).Append(", ")
                                    .Append("Crystal: ").Append(Crystal).Append(", ")
                                    .Append("Deuterium: ").Append(Deuterium).Append(", ")
                                    .Append("DarkMatter: ").Append(DarkMatter).Append(", ")
                                    .Append("Energy: ").Append(Energy).ToString();
        }
    }
}
