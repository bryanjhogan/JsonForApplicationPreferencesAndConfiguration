using System.Data.Entity;

namespace ConfigurationByJson.DAL
{
    public class ConfigurationContext : DbContext 
    {
        #region Constructors

        public ConfigurationContext(string connectionString):base(connectionString)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ConfigurationContext>());
        }

        #endregion

        #region Public Properties

        public DbSet<Preference> Preferences { get; set; }

        #endregion
    }
}