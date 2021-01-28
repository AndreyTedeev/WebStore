using System;
using System.Collections.Generic;
using WebStore.Entities;
using WebStore.Models;

namespace WebStore.Data
{

    public class TestData
    {

        private static readonly List<Employee> _employees = new()
        {
            new()
            {
                Id = 1,
                LastName = "Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович",
                Birthday = new DateTime(1971, 11, 23),
                EmploymentStart = new DateTime(2010, 12, 1)
            },
            new()
            {
                Id = 2,
                LastName = "Петров",
                FirstName = "Пётр",
                Patronymic = "Петрович",
                Birthday = new DateTime(1981, 9, 3),
                EmploymentStart = new DateTime(2014, 2, 16)
            },
            new()
            {
                Id = 3,
                LastName = "Сидоров",
                FirstName = "Сидор",
                Patronymic = "Сидорович",
                Birthday = new DateTime(1991, 7, 30),
                EmploymentStart = new DateTime(2016, 9, 26)
            },
        };

        public static List<Employee> Employees => _employees;

        private static readonly List<Brand> _brands = new()
        {
            new() { Id = 1, Name = "Acne", OrderNumber = 1 },
            new() { Id = 2, Name = "Grüne Erde", OrderNumber = 2 },
            new() { Id = 3, Name = "Albiro", OrderNumber = 3 },
            new() { Id = 4, Name = "Ronhill", OrderNumber = 4 },
            new() { Id = 5, Name = "Oddmolly", OrderNumber = 5 },
            new() { Id = 6, Name = "Boudestijn", OrderNumber = 6 },
            new() { Id = 7, Name = "Rösch creative culture", OrderNumber = 7 }
        };

        public static List<Brand> Brands => _brands;

        private static readonly List<Category> _categories = new()
        {
            new() { Id = 1, Name = "Sportswear", OrderNumber = 1 },
            new() { Id = 2, Name = "Nike", OrderNumber = 1, ParentId = 1 },
            new() { Id = 3, Name = "Under Armour", OrderNumber = 2, ParentId = 1 },
            new() { Id = 4, Name = "Adidas", OrderNumber = 3, ParentId = 1 },
            new() { Id = 5, Name = "Puma", OrderNumber = 4, ParentId = 1 },
            new() { Id = 6, Name = "ASICS", OrderNumber = 5, ParentId = 1 },

            new() { Id = 7, Name = "Mens", OrderNumber = 2 },
            new() { Id = 8, Name = "Fendi", OrderNumber = 1, ParentId = 7 },
            new() { Id = 9, Name = "Guess", OrderNumber = 2, ParentId = 7 },
            new() { Id = 10, Name = "Valentino", OrderNumber = 3, ParentId = 7 },
            new() { Id = 11, Name = "Dior", OrderNumber = 4, ParentId = 7 },
            new() { Id = 12, Name = "Versace", OrderNumber = 5, ParentId = 7 },
            new() { Id = 13, Name = "Armani", OrderNumber = 6, ParentId = 7 },
            new() { Id = 14, Name = "Prada", OrderNumber = 7, ParentId = 7 },
            new() { Id = 15, Name = "Dolce and Gabbana", OrderNumber = 8, ParentId = 7 },
            new() { Id = 16, Name = "Chanel", OrderNumber = 9, ParentId = 7 },
            new() { Id = 17, Name = "Gucci", OrderNumber = 10, ParentId = 7 },

            new() { Id = 18, Name = "Womens", OrderNumber = 3 },
            new() { Id = 19, Name = "Fendi", OrderNumber = 1, ParentId = 18 },
            new() { Id = 20, Name = "Guess", OrderNumber = 2, ParentId = 18 },
            new() { Id = 21, Name = "Valentino", OrderNumber = 3, ParentId = 18 },
            new() { Id = 22, Name = "Dior", OrderNumber = 4, ParentId = 18 },
            new() { Id = 23, Name = "Versace", OrderNumber = 5, ParentId = 18 },

            new() { Id = 24, Name = "Kids", OrderNumber = 4 },

            new() { Id = 25, Name = "Fashion", OrderNumber = 5 },

            new() { Id = 26, Name = "Households", OrderNumber = 6 },

            new() { Id = 27, Name = "Interiors", OrderNumber = 7 },

            new() { Id = 28, Name = "Clothing", OrderNumber = 8 },

            new() { Id = 29, Name = "Bags", OrderNumber = 9 },

            new() { Id = 30, Name = "Shoes", OrderNumber = 10 }

        };

        public static List<Category> Categories => _categories;

        private static List<Product> _products = new()
        {
            new() { Id = 1, Name = "Product 1", ImageUrl = "product1.jpg", Price = 101, CategoryId = 2, BrandId = 1 },
            new() { Id = 2, Name = "Product 2", ImageUrl = "product2.jpg", Price = 102, CategoryId = 8, BrandId = 1 },
            new() { Id = 2, Name = "Product 3", ImageUrl = "product3.jpg", Price = 103, CategoryId = 19, BrandId = 2 },
            new() { Id = 2, Name = "Product 4", ImageUrl = "product4.jpg", Price = 104, CategoryId = 24, BrandId = 2 },
            new() { Id = 2, Name = "Product 5", ImageUrl = "product5.jpg", Price = 105, CategoryId = 25, BrandId = 3 },
            new() { Id = 2, Name = "Product 6", ImageUrl = "product6.jpg", Price = 106, CategoryId = 26, BrandId = 3 },
            new() { Id = 2, Name = "Product 7", ImageUrl = "product7.jpg", Price = 107, CategoryId = 27, BrandId = 4 },
            new() { Id = 2, Name = "Product 8", ImageUrl = "product8.jpg", Price = 108, CategoryId = 28, BrandId = 5 },
            new() { Id = 2, Name = "Product 9", ImageUrl = "product9.jpg", Price = 109, CategoryId = 29, BrandId = 5 },
            new() { Id = 2, Name = "Product 10", ImageUrl = "product10.jpg", Price = 110, CategoryId = 30, BrandId = 6 },
            new() { Id = 2, Name = "Product 11", ImageUrl = "product11.jpg", Price = 111, CategoryId = 1, BrandId = 7 },
            new() { Id = 2, Name = "Product 12", ImageUrl = "product12.jpg", Price = 112, CategoryId = 1, BrandId = 7 }
        };

        public static List<Product> Products => _products;

    }
}