using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Controllers
{

    public class EmployeesController : Controller
    {

        private readonly List<Employee> _employees;

        public EmployeesController()
        {
            _employees = TestData.Employees;
        }

        public IActionResult Index() =>
            View(_employees);

        public IActionResult Details(int id)
        {
            var result = _employees.SingleOrDefault((e) => e.Id == id);
            return result is null ? NotFound() : View(result);
        }

    }
}