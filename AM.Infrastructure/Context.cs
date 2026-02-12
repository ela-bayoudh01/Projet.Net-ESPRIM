using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AM.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Chemin absolu vers appsettings.json (adapte si besoin)
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string configPath = Path.Combine(basePath, "appsettings.json");

                if (!File.Exists(configPath))
                {
                    throw new FileNotFoundException($"Fichier de configuration non trouvé : {configPath}");
                }

                var config = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

                string connString = config.GetConnectionString("Default");

                if (string.IsNullOrEmpty(connString))
                    throw new InvalidOperationException("Chaîne 'Default' non trouvée.");

                optionsBuilder.UseSqlServer(connString);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
