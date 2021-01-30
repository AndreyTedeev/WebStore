using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebStore.Data
{
    public class DbInitializer
    {
        private readonly Db _db;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(Db db, ILogger<DbInitializer> logger)
        {
            _db = db;
            _logger = logger;
        }

        private void ProcessMigrations()
        {
            _logger.LogInformation("Checking pending migrations");
            var db = _db.Database;
            if (db.GetPendingMigrations().Any())
            {
                _logger.LogInformation("Migrating database");
                db.Migrate();
                _logger.LogInformation("Success : migrate database");
            }
            else
            {
                _logger.LogInformation("Database is in actual valid state");
            }
        }

        private void SeedInitialData()
        {
            _logger.LogInformation("Seeding inital data");
            try
            {
                SeedProducts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error seeding data");
                throw;
            }
            _logger.LogInformation("Success : Seed inital data");
        }

        private void SeedProducts()
        {
            _logger.LogInformation("Seeding Brands");
            using (_db.Database.BeginTransaction())
            {
                _db.Brands.AddRange(TestDbData.Brands());
                _db.SaveChanges();
                _db.Database.CommitTransaction();
                _logger.LogInformation("Success: Brands");
            }
            _logger.LogInformation("Seeding Categories");
            using (_db.Database.BeginTransaction())
            {
                _db.Categories.AddRange(TestDbData.Categories());
                _db.SaveChanges();
                _db.Database.CommitTransaction();
                _logger.LogInformation("Success: Categories");
            }
            _logger.LogInformation("Seeding Products");
            using (_db.Database.BeginTransaction())
            {
                _db.Products.AddRange(TestDbData.Products());
                _db.SaveChanges();
                _db.Database.CommitTransaction();
                _logger.LogInformation("Success: Products");
            }
        }

        public void Initialize()
        {
            _logger.LogInformation("Initializing database");

            ProcessMigrations();

            if (!_db.Products.Any())
                SeedInitialData();

            _logger.LogInformation("Success : Initialize database");
        }

    }
}
