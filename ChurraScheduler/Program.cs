using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ChurraScheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var key = "DatabasePath";
            var value = Directory.GetCurrentDirectory()+"\\database.db";

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
