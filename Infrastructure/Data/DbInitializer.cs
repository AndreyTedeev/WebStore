using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.Entities;
using WebStore.Entities.Identity;

namespace WebStore.Data
{
    public class DbInitializer
    {
        private readonly Db _db;
        private readonly ILogger<DbInitializer> _logger;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public DbInitializer(Db db, ILogger<DbInitializer> logger, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            _logger.LogInformation("Initializing database");

            ProcessMigrations();

            SeedIdentityAsync().Wait();

            if (!_db.Products.Any())
                SeedInitialData();

            _logger.LogInformation("Success : Initialize database");
        }

        private async Task SeedIdentityAsync()
        {
            async Task CheckRole(string name)
            {
                if (!await _roleManager.RoleExistsAsync(name))
                    await _roleManager.CreateAsync(new Role { Name = name });
            }

            await CheckRole(Role.Administrator);
            await CheckRole(Role.User);

            await SeedUser(User.Administrator, User.AdminPassword, Role.Administrator);

        }

        private async Task SeedUser(string userName, string password, string role)
        {
            if (await _userManager.FindByNameAsync(userName) is null)
            {
                var user = new User { UserName = userName };
                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                    ThrowErrors(result, $"Error creating {userName}");

                result = await _userManager.AddToRoleAsync(user, role);
                if (!result.Succeeded)
                    ThrowErrors(result, $"Error adding {userName} to role {role}");
            }

            static void ThrowErrors(IdentityResult result, string message)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new InvalidOperationException($"{message} : {String.Join(',', errors)}");
            }
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
                SeedBrands();
                SeedCategories();
                SeedProducts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error seeding data");
                throw;
            }
            _logger.LogInformation("Success : Seed inital data");
        }

        private void SeedBrands()
        {
            _logger.LogInformation("Seeding Brands");
            var data = new List<Brand>() {
               new() { Name = "Acne", OrderNumber = 1 },
               new() { Name = "Grüne Erde", OrderNumber = 2 },
               new() { Name = "Albiro", OrderNumber = 3 },
               new() { Name = "Ronhill", OrderNumber = 4 },
               new() { Name = "Oddmolly", OrderNumber = 5 },
               new() { Name = "Boudestijn", OrderNumber = 6 },
               new() { Name = "Rösch creative culture", OrderNumber = 7 }
            };
            using (_db.Database.BeginTransaction())
            {
                _db.Brands.AddRange(data);
                _db.SaveChanges();
                _db.Database.CommitTransaction();
                _logger.LogInformation("Success: Brands");
            }
        }

        private void SeedCategories()
        {
            _logger.LogInformation("Seeding Categories");
            var data = GenerateCategories();
            using (_db.Database.BeginTransaction())
            {
                _db.Categories.AddRange(data);
                _db.SaveChanges();
                _db.Database.CommitTransaction();
                _logger.LogInformation("Success: Categories");
            }
        }

        private void SeedProducts()
        {
            _logger.LogInformation("Seeding Products");
            var data = GenerateProducts();
            using (_db.Database.BeginTransaction())
            {
                _db.Products.AddRange(data);
                _db.SaveChanges();
                _db.Database.CommitTransaction();
                _logger.LogInformation("Success: Products");
            }
        }

        private static List<Category> GenerateCategories()
        {
            var result = new List<Category>();

            var parent = new Category { OrderNumber = 1, Name = "Sportswear" };
            result.Add(parent);
            result.AddRange(new Category[] {
                new() { Parent = parent, OrderNumber = 1, Name = "Nike"},
                new() { Parent = parent, OrderNumber = 2, Name = "Under Armour"},
                new() { Parent = parent, OrderNumber = 3, Name = "Adidas"},
                new() { Parent = parent, OrderNumber = 4, Name = "Puma"},
                new() { Parent = parent, OrderNumber = 5, Name = "ASICS"}
            });

            parent = new Category { OrderNumber = 2, Name = "Mens" };
            result.Add(parent);
            result.AddRange(new Category[] {
                new() { Parent = parent, OrderNumber = 1, Name = "Fendi"},
                new() { Parent = parent, OrderNumber = 2, Name = "Guess"},
                new() { Parent = parent, OrderNumber = 3, Name = "Valentino"},
                new() { Parent = parent, OrderNumber = 4, Name = "Dior"},
                new() { Parent = parent, OrderNumber = 5, Name = "Versace"},
                new() { Parent = parent, OrderNumber = 6, Name = "Armani"},
                new() { Parent = parent, OrderNumber = 7, Name = "Prada"},
                new() { Parent = parent, OrderNumber = 8, Name = "Dolce and Gabbana"},
                new() { Parent = parent, OrderNumber = 9, Name = "Chanel"},
                new() { Parent = parent, OrderNumber = 10, Name = "Gucci"}
            });

            parent = new Category { OrderNumber = 3, Name = "Womens" };
            result.Add(parent);
            result.AddRange(new Category[] {
                new() { Parent = parent, OrderNumber = 1, Name = "Fendi"},
                new() { Parent = parent, OrderNumber = 2, Name = "Guess"},
                new() { Parent = parent, OrderNumber = 3, Name = "Valentino"},
                new() { Parent = parent, OrderNumber = 4, Name = "Dior"},
                new() { Parent = parent, OrderNumber = 5, Name = "Versace"}
            });

            result.Add(new Category { OrderNumber = 4, Name = "Kids" });
            result.Add(new Category { OrderNumber = 5, Name = "Fashion" });
            result.Add(new Category { OrderNumber = 6, Name = "Households" });
            result.Add(new Category { OrderNumber = 7, Name = "Interiors" });
            result.Add(new Category { OrderNumber = 8, Name = "Clothing" });
            result.Add(new Category { OrderNumber = 9, Name = "Bags" });
            result.Add(new Category { OrderNumber = 10, Name = "Shoes" });

            return result;
        }

        private static Category FindCategory(string parentName, string name, List<Category> categories) => FindCategory(parentName, categories) switch
        {
            Category parent => categories.Where((c) => c.Name.Equals(name) && c.Parent == parent).Single() switch
            {
                Category result => result,
                _ => throw new ArgumentException("category not found")
            },
            _ => throw new ArgumentException("parent category not found")
        };

        private static Category FindCategory(string parentName, List<Category> categories) => categories switch
        {
            null => throw new ArgumentException("categories cannot be null"),
            _ => categories.Where((c) => c.Name.Equals(parentName) && c.Parent is null).Single() switch
            {
                Category result => result,
                _ => throw new ArgumentException("category not found")
            }
        };

        private static Brand FindBrand(string name, List<Brand> brands) => brands switch
        {
            null => throw new ArgumentException("brands cannot be null"),
            _ => brands.Where((b) => b.Name.Equals(name)).Single() switch
            {
                Brand result => result,
                _ => throw new ArgumentException("brand not found")
            }
        };

        private List<Product> GenerateProducts()
        {
            var brands = _db.Brands.ToList();
            var categories = _db.Categories.ToList();
            var result = new List<Product>()
            {
               new Product() { Name = "Product 1", ImageUrl = "product1.jpg", Price = 101,
                   Brand = FindBrand("Acne", brands),
                   Category = FindCategory("Sportswear", "Nike", categories)},
               new Product() { Name = "Product 2", ImageUrl = "product2.jpg", Price = 102,
                   Brand = FindBrand("Acne", brands),
                   Category = FindCategory("Mens", "Fendi", categories)},
               new Product() { Name = "Product 3", ImageUrl = "product3.jpg", Price = 103,
                   Brand = FindBrand("Grüne Erde", brands),
                   Category = FindCategory("Womens", "Fendi", categories)},
               new Product() { Name = "Product 4", ImageUrl = "product4.jpg", Price = 104,
                   Brand = FindBrand("Grüne Erde", brands),
                   Category = FindCategory("Kids", categories)},
               new Product() { Name = "Product 5", ImageUrl = "product5.jpg", Price = 105,
                   Brand = FindBrand("Albiro", brands),
                   Category = FindCategory("Fashion", categories)},
               new Product() { Name = "Product 6", ImageUrl = "product6.jpg", Price = 106,
                   Brand = FindBrand("Albiro", brands),
                   Category = FindCategory("Households", categories)},
               new Product() { Name = "Product 7", ImageUrl = "product7.jpg", Price = 107,
                   Brand = FindBrand("Ronhill", brands),
                   Category = FindCategory("Interiors", categories)},
               new Product() { Name = "Product 8", ImageUrl = "product8.jpg", Price = 108,
                   Brand = FindBrand("Oddmolly", brands),
                   Category = FindCategory("Clothing", categories)},
               new Product() { Name = "Product 9", ImageUrl = "product9.jpg", Price = 109,
                   Brand = FindBrand("Oddmolly", brands),
                   Category = FindCategory("Bags", categories)},
               new Product() { Name = "Product 10", ImageUrl = "product10.jpg", Price = 110,
                   Brand = FindBrand("Boudestijn", brands),
                   Category = FindCategory("Shoes", categories)},
               new Product() { Name = "Product 11", ImageUrl = "product11.jpg", Price = 111,
                   Brand = FindBrand("Rösch creative culture", brands),
                   Category = FindCategory("Sportswear", categories)},
               new Product() { Name = "Product 12", ImageUrl = "product12.jpg", Price = 112,
                   Brand = FindBrand("Rösch creative culture", brands),
                   Category = FindCategory("Sportswear", categories)}
            };
            return result;
        }

    }
}
