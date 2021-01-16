using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {

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

        public IActionResult Index() {
            return View();
        }

        public IActionResult Employees() {
            return View(_employees);
        }

        public IActionResult EmployeeCard(int id) {
            //return View(_employees.Where((e) => e.Id == employeeId).Single());
            Employee employee = (
                from e in _employees
                where e.Id == id
                select e)
                .Single();
            return View(employee);
        }

    }
}
