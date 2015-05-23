using System;

namespace ConfigurationByJson.DAL
{
    public class Preference
    {
        public Guid PreferenceID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
}