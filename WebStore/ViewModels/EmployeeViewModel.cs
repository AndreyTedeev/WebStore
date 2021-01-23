using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.ViewModels
{
    public record EmployeeViewModel
    {

        private readonly Employee _employee;

        public EmployeeViewModel()
        {
            _employee = new Employee();
        }

        public EmployeeViewModel(Employee employee)
        {
            if (employee is not null)
            {
                _employee.Id = employee.Id;
                _employee.FirstName = employee.FirstName;
                _employee.LastName = employee.LastName;
                _employee.Patronymic = employee.Patronymic;
                _employee.Birthday = employee.Birthday;
                _employee.EmploymentStart = employee.EmploymentStart;
                _employee.EmploymentEnd = employee.EmploymentEnd;
            }
        }

        public Employee Employee { get; }

    }
}
