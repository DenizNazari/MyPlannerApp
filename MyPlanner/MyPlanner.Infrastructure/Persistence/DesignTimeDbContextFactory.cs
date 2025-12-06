using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MyPlanner.Infrastructure.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Navigate to the API project
            var infrastructurePath = Directory.GetCurrentDirectory();
            var apiPath = Path.Combine(infrastructurePath, "..", "MyPlanner.Api");

            // Make sure the path exists
            //if (!Directory.Exists(apiPath))
            //{
            //    // Try alternative path
            //    apiPath = Path.GetFullPath(Path.Combine(infrastructurePath, @"..\..\MyPlanner.Api"));
            //}

            var configPath = Path.Combine(apiPath, "appsettings.json");

            //if (!File.Exists(configPath))
            //{
            //    throw new FileNotFoundException($"appsettings.json not found. Searched: {configPath}");
            //}

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(apiPath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("MigrationConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'MigrationConnection' not found.");
            }

            builder.UseNpgsql(connectionString);

            return new AppDbContext(builder.Options);
        }
    }
}