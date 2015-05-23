using ConfigurationByJson.DAL;

namespace ConfigurationByJson.Console
{
    class Program
    {
        private ConfigurationContext _context;
        private PreferenceManager _preferenceManager;

        static void Main(string[] args)
        {
            var p =  new Program();

            //seed the database with preferences
            p.Initialize();
            
            //try out getting the prefernces
            p.GetPreferences();
        }

        private void GetPreferences()
        {
            string defaultEmail = _preferenceManager.GetPreference<string>("DefaultEmail");
            bool displayWidget = _preferenceManager.GetPreference<bool>("DisplayWidget");
            int resultsPerPage = _preferenceManager.GetPreference<int>("ResultsPerPage");
            string[] cities = _preferenceManager.GetPreference<string[]>("Cities");
            EmergencyContact emergencyContact = _preferenceManager.GetPreference<EmergencyContact>("PrimaryEmergencyContact");
            EmergencyContact[] emergencyContacts = _preferenceManager.GetPreference<EmergencyContact[]>("SecondaryEmergencyContacts");

            //this is the bad way to cast
            //bool x = (bool)_preferenceManager.BadWayToCastToGetPreference<bool>("DisplayWidget");
        }

        private void Initialize()
        {
            _context = new ConfigurationContext(@"Data Source=(LocalDB)\v11.0;Initial Catalog=Configuration;Integrated Security=True");
            _preferenceManager = new PreferenceManager(_context);
            var seeder = new Seeder(_context);
            seeder.Seed();
        }
    }
}