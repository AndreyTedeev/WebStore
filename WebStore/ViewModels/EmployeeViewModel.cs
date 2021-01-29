using System;
using WebStore.Models;

namespace WebStore.ViewModels
{
    public record EmployeeViewModel
    {

        private readonly Employee _employee;

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee ?? new();
        }

        public EmployeeViewModel() : this((Employee)null) { }

        public int Id { get => _employee.Id; init => _employee.Id = value; }

        public string FirstName { get => _employee.FirstName; init => _employee.FirstName = value; }

        public string LastName { get => _employee.LastName; init => _employee.LastName = value; }

        public string Patronymic { get => _employee.Patronymic; init => _employee.Patronymic = value; }

        public DateTime Birthday { get => _employee.Birthday; init => _employee.Birthday = value; }

        public DateTime EmploymentStart { get => _employee.EmploymentStart; init => _employee.EmploymentStart = value; }

        public DateTime? EmploymentEnd { get => _employee.EmploymentEnd; init => _employee.EmploymentEnd = value; }

        public bool IsActive => _employee.IsActive;

        public int Age => _employee.Age;

        public int Seniority => _employee.Seniority;

        public string FullName => _employee.FullName;

        public Employee Employee => _employee;

    }
}
