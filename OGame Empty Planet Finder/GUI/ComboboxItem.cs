using System;

namespace OGameEmptyPlanetFinder.GUI
{
    public class ComboboxItem
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public ComboboxItem()
        {
            Key = "";
            Value = "";
        }

        public ComboboxItem(String key, String value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}
