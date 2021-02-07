using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.Identity;
using WebStore.Interfaces;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    [Authorize]
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

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Create() => View("Edit", new EmployeeViewModel());

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(int id) => ViewById(id);

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int id) => ViewById(id);

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(EmployeeViewModel model)
        {
            Action<Employee> action = model switch
            {
                null => throw new ArgumentNullException(nameof(model)),
                _ => ModelState.IsValid switch
                {
                    false => null,
                    true => model.Id switch
                    {
                        0 => _employeesService.Add,
                        _ => _employeesService.Update
                    }
                }
            };
            if (action is null)
                return View(model);
            else
            {
                action.Invoke(model.Employee);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
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