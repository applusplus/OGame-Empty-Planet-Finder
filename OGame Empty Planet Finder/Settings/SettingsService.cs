using System.IO;
using Newtonsoft.Json;

namespace OGameEmptyPlanetFinder.Settings
{
    public class SettingsService
    {
        public static string FILE = "OGEPF.cfg";

        private static SettingsService _instance;
        public static SettingsService Instance => _instance ?? (_instance = new SettingsService());

        public SettingsEntity Settings { get; private set; }

        private SettingsService()
        {
            Settings = new SettingsEntity();
            Load();
        }

        private void Load()
        {
            if (File.Exists(FILE))
            {
                Settings = FileToObject(FILE);
            }
            else
            {
                Save();
            }
        }

        public void Save()
        {
            if (Settings != null)
            {
                ObjectToFile(Settings, FILE);
            }
        }

        public void ObjectToFile(SettingsEntity settings, string file)
        {
            using (StreamWriter streamWriter = File.CreateText(file))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(streamWriter, settings);
            }
        }

        public SettingsEntity FileToObject(string file)
        {
            using (StreamReader streamReader = File.OpenText(file))
            {
                var serializer = new JsonSerializer();
                return (SettingsEntity) serializer.Deserialize(streamReader, typeof(SettingsEntity));
            }
        }
    }
}
