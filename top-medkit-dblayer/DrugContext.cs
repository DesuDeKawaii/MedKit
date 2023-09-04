global using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using top_medkit_models;
using top_medkit_models.Models;

namespace top_medkit_dblayer
{
    public class DrugContext : DbContext
    {
        public DbSet<AcceptanceMethod> AcceptanceMethods { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DrugInfo> DrugInfos { get; set; }
        public DbSet<MedKit> MedKits { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        private const string configPath = "db_config.json";
        private const string connectionStringKey = "drug_connectionString";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!File.Exists(configPath))
                throw new Exception($"not found file for \"{configPath}\"path!");
            var json = JObject.Parse(File.ReadAllText(configPath));
            if (!json.ContainsKey(connectionStringKey))
                throw new Exception($"Inconsistent {configPath} file!");
            optionsBuilder
                .UseSqlServer((string?)json[connectionStringKey])
                .UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in ModelController.GetModelTypes())
                modelBuilder.Entity(entityType)
                    .Property(nameof(IEntity.Id))
                    .HasDefaultValue("NEWSEQUENTIALID()");

            modelBuilder.Entity<MedKit>().HasMany(x => x.DrugInfos).WithMany(x => x.MedKits).UsingEntity(typeof(Drug));
            modelBuilder.Entity<Client>().HasMany(x => x.Drugs).WithMany(x => x.Clients).UsingEntity(typeof(Transaction));

        }
    }
}