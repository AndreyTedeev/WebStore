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

        private IActionResult ViewById(int id) => id switch
        {
            <= 0 => BadRequest(),
            > 0 => _employeesService.Get(id) switch
            {
                null => NotFound(),
                Employee e => View(new EmployeeViewModel(e))
            }
        };

        public IActionResult Index() => View(_employeesService.Get());

        public IActionResult Details(int id) => ViewById(id);

        public IActionResult Create() => View("Edit", new EmployeeViewModel());

        public IActionResult Edit(int id) => ViewById(id);

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            Action<Employee> action = model switch
            {
                null => throw new ArgumentNullException(nameof(model)),
                _ => model.Id switch
                {
                    0 => _employeesService.Add,
                    _ => _employeesService.Update
                }
            };
            action.Invoke(model.ToEmployee());
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) => ViewById(id);

        [HttpPost]
        public IActionResult DeleteConfirmed(int id) => id switch
        {
            <= 0 => BadRequest(),
            > 0 => _employeesService.Delete(id) switch
            {
                false => NotFound(),
                true => RedirectToAction("Index")
            }
        };
    }
}