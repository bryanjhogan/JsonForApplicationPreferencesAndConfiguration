using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationByJson.DAL;
using Newtonsoft.Json;

namespace ConfigurationByJson.Console
{
    public class PreferenceManager
    {
        private readonly ConfigurationContext _context;

        #region Pulbic Methods

        public PreferenceManager(ConfigurationContext context)
        {
            _context = context;
        }

        public object BadWayToCastToGetPreference<T>(string name)
        {
            var preference = Convert.ChangeType(_context.Preferences.SingleOrDefault(p => p.Name == name).Value, typeof(T));
            return preference;
        }

        public T GetPreference<T>(string name)
        {
            var preference =
                JsonConvert.DeserializeObject<T>(_context.Preferences.SingleOrDefault(p => p.Name == name).Value);
            return preference;
        }

        #endregion
    }
}