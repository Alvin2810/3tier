﻿using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DAL.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            configurationBuilder.AddJsonFile(path, false);

            IConfigurationRoot root = configurationBuilder.Build();

            IConfigurationSection appSettings = root.GetSection("ConnectionStrings:DefaultConnection");

            SqlConnectionString = appSettings.Value;
        }

        public string SqlConnectionString { get; set; }

    }

}