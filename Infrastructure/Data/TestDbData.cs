using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Entities;
using WebStore.Models;

namespace WebStore.Data
{

    public static class TestDbData
    {
        private static List<Brand> _brands = null;

        private static List<Category> _categories = null;

        private static List<Product> _products = null;

        private static List<Product> GenerateProducts()
        {
            var brands = Brands();
            var categories = Categories();
            var result = new List<Product>()
            {
               new Product() { Name = "Product 1", ImageUrl = "product1.jpg", Price = 101, Brand = brands[0],
                   Category = FindCategory("Sportswear", "Nike", categories)},
               new Product() { Name = "Product 2", ImageUrl = "product2.jpg", Price = 102, Brand = brands[0],
                   Category = FindCategory("Mens", "Fendi", categories)},
               new Product() { Name = "Product 3", ImageUrl = "product3.jpg", Price = 103, Brand = brands[1],
                   Category = FindCategory("Womens", "Fendi", categories)},
               new Product() { Name = "Product 4", ImageUrl = "product4.jpg", Price = 104, Brand = brands[1],
                   Category = FindCategory("Kids", categories)},
               new Product() { Name = "Product 5", ImageUrl = "product5.jpg", Price = 105, Brand = brands[2],
                   Category = FindCategory("Fashion", categories)},
               new Product() { Name = "Product 6", ImageUrl = "product6.jpg", Price = 106, Brand = brands[2],
                   Category = FindCategory("Households", categories)},
               new Product() { Name = "Product 7", ImageUrl = "product7.jpg", Price = 107, Brand = brands[3],
                   Category = FindCategory("Interiors", categories)},
               new Product() { Name = "Product 8", ImageUrl = "product8.jpg", Price = 108, Brand = brands[4],
                   Category = FindCategory("Clothing", categories)},
               new Product() { Name = "Product 9", ImageUrl = "product9.jpg", Price = 109, Brand = brands[4],
                   Category = FindCategory("Bags", categories)},
               new Product() { Name = "Product 10", ImageUrl = "product10.jpg", Price = 110, Brand = brands[5],
                   Category = FindCategory("Shoes", categories)},
               new Product() { Name = "Product 11", ImageUrl = "product11.jpg", Price = 111, Brand = brands[6],
                   Category = FindCategory("Sportswear", categories)},
               new Product() { Name = "Product 12", ImageUrl = "product12.jpg", Price = 112, Brand = brands[6],
                   Category = FindCategory("Sportswear", categories)}
            };
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

        private static List<Brand> GenerateBrands() => new List<Brand>() {
               new() { Name = "Acne", OrderNumber = 1 },
               new() { Name = "Grüne Erde", OrderNumber = 2 },
               new() { Name = "Albiro", OrderNumber = 3 },
               new() { Name = "Ronhill", OrderNumber = 4 },
               new() { Name = "Oddmolly", OrderNumber = 5 },
               new() { Name = "Boudestijn", OrderNumber = 6 },
               new() { Name = "Rösch creative culture", OrderNumber = 7 }
            };

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

        public static List<Brand> Brands() => _brands ?? GenerateBrands();

        public static List<Category> Categories() => _categories ?? GenerateCategories();

        public static List<Product> Products() => _products ?? GenerateProducts();


    }
}