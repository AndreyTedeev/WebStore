using System;
using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Data {

    public class TestData {

        private static readonly List<Employee> _employees = new() {
            new() {
                Id = 1,
                LastName = "Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович",
                Birthday = new DateTime(1971, 11, 23),
                EmploymentStart = new DateTime(2010, 12, 1)
            },
            new() {
                Id = 2,
                LastName = "Петров",
                FirstName = "Пётр",
                Patronymic = "Петрович",
                Birthday = new DateTime(1981, 9, 3),
                EmploymentStart = new DateTime(2014, 2, 16)
            },
            new() {
                Id = 3,
                LastName = "Сидоров",
                FirstName = "Сидор",
                Patronymic = "Сидорович",
                Birthday = new DateTime(1991, 7, 30),
                EmploymentStart = new DateTime(2016, 9, 26)
            },
        };

        public static List<Employee> Employees => _employees;

    }
}