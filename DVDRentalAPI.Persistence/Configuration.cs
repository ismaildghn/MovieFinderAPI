using Microsoft.Extensions.Configuration;
using System.IO;

namespace DVDRentalAPI.Persistence
{
    static class Configuration
    {

        static public string ConnectionString
        {

            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DVDRentalAPI"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("PostgreSQL");

            }
        }
    }
}
