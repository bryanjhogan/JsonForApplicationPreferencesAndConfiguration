using System;
using System.Linq;
using ConfigurationByJson.DAL;
using Newtonsoft.Json;

namespace ConfigurationByJson.Console
{
    public class Seeder
    {
        private readonly ConfigurationContext _context;
        
        #region Constructors 
        
        public Seeder(ConfigurationContext context)
        {
            _context = context;
        }
        
        #endregion
        
        #region Public Methods

        public void Seed()
        {
            // This not a good way to seed a database, but I don't want to go do the route of migrations right now.
            if (_context.Preferences.Any())
            {
                return;
            }

            string defaultEmail = "admin@example.com";
            Preference preference1 = CreatePreference("DefaultEmail", JsonConvert.SerializeObject(defaultEmail), defaultEmail.GetType().ToString());

            bool displayWidget = true;
            Preference preference2 = CreatePreference("DisplayWidget", JsonConvert.SerializeObject(displayWidget), displayWidget.GetType().ToString());

            int resultsPerPage = 25;
            Preference preference3 = CreatePreference("ResultsPerPage", JsonConvert.SerializeObject(resultsPerPage), resultsPerPage.GetType().ToString());

            string[] cities = new[] {"Boston", "New York", "Seattle"};
            Preference preference4 = CreatePreference("Cities", JsonConvert.SerializeObject(cities), cities.GetType().ToString());


            EmergencyContact emergencyContact = new EmergencyContact() { EmailAddress = "tom@example.com", Priority = 1 };
            Preference preference5 = CreatePreference("PrimaryEmergencyContact",
                JsonConvert.SerializeObject(emergencyContact), emergencyContact.GetType().ToString());

            EmergencyContact[] secondaryEmergencyContacts = new[]
            {
                new EmergencyContact{ EmailAddress = "tom@example.com", Priority = 1},
                new EmergencyContact{ EmailAddress = "dick@example.com", Priority = 2},
                new EmergencyContact{ EmailAddress = "harry@example.com", Priority = 3},
            };
            Preference preference6 = CreatePreference("SecondaryEmergencyContacts",
                JsonConvert.SerializeObject(secondaryEmergencyContacts), secondaryEmergencyContacts.GetType().ToString());

            _context.Preferences.Add(preference1);
            _context.Preferences.Add(preference2);
            _context.Preferences.Add(preference3);
            _context.Preferences.Add(preference4);
            _context.Preferences.Add(preference5);
            _context.Preferences.Add(preference6);
            _context.SaveChanges();
        }
        
        #endregion

        #region Private Methods

        private Preference CreatePreference(string name, string value, string type)
        {
            var preference = new Preference
            {
                Name = name,
                Value = value,
                Type = type,
                PreferenceID = Guid.NewGuid()
            };
            return preference;
        }
        
        #endregion
    }
}