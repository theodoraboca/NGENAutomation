using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGEN
{
    public static class CustomNGENConfiguration
    {
        public static IConfiguration DefaultConfiguration => GetConfiguration();

        private static IConfiguration GetConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(@"C:\Users\Theodora\source\repos\NGENAutomation\NGEN\")
                .AddJsonFile("configuration.json")
                .Build();
            return config;
        }

    }
}
