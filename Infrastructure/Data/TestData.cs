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

    }
}