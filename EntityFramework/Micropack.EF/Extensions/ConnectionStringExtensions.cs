using System.IO;
using Microsoft.Extensions.Configuration;

namespace Micropack.EF
{
    public static class ConnectionStringExtensions
    {
        /// <summary>
        /// get the connection string from the app appsettings.json file
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="connectionStringName">name of connection string configuration node</param>
        /// <returns></returns>
        public static string GetConnectionString(this ConfigurationBuilder builder, string connectionStringName, string appSettingFileName = "appsettings.json")
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(appSettingFileName)
                .Build();

            return config.GetConnectionString(connectionStringName);
        }
    }
}
