using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Interfaces;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{

    public class EmployeesController : Controller
    {

        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public IActionResult Index() => View(_employeesService.Get());

        public IActionResult Details(int id) => id switch
        {
            <= 0 => BadRequest(),
            > 0 => _employeesService.Get(id) switch
            {
                null => NotFound(),
                Employee e => View(e)
            }
        };

        public IActionResult Create() => View("Edit", new EmployeeViewModel());

        public IActionResult Edit(int id) => id switch
        {
            <= 0 => BadRequest(),
            > 0 => _employeesService.Get(id) switch
            {
                null => NotFound(),
                Employee e => View(new EmployeeViewModel(e))
            }
        };

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            Action<Employee> action = model switch
            {
                null => throw new ArgumentNullException(nameof(model)),
                _ => model.Employee.Id switch
                {
                    0 => _employeesService.Add,
                    _ => _employeesService.Update
                }
            };
            action.Invoke(model.Employee);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) => id switch
        {
            <= 0 => BadRequest(),
            > 0 => _employeesService.Get(id) switch
            {
                null => NotFound(),
                Employee e => View(new EmployeeViewModel(e))
            }
        };

        [HttpPost]
        public IActionResult DeleteConfirmed(int id) => id switch
        {
            <= 0 => BadRequest(),
            > 0 => _employeesService.Delete(id) switch
            {
                _ => RedirectToAction("Index")
            }
        };
    }
}