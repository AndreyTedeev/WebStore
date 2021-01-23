using System;
using WebStore.Models;

namespace WebStore.ViewModels
{
    public record EmployeeViewModel
    {

        public EmployeeViewModel()
        {
        }

        public EmployeeViewModel(Employee employee)
        {
            if (employee is not null)
            {
                this.Id = employee.Id;
                this.FirstName = employee.FirstName;
                this.LastName = employee.LastName;
                this.Patronymic = employee.Patronymic;
                this.Birthday = employee.Birthday;
                this.EmploymentStart = employee.EmploymentStart;
                this.EmploymentEnd = employee.EmploymentEnd;
            }
        }

        public int Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Patronymic { get; init; }

        public DateTime Birthday { get; init; } = DateTime.Now;

        public DateTime EmploymentStart { get; init; } = DateTime.Now;

        public DateTime? EmploymentEnd { get; init; } = null;

        public Employee ToEmployee() => new Employee
        {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName,
            Patronymic = this.Patronymic,
            Birthday = this.Birthday,
            EmploymentStart = this.EmploymentStart,
            EmploymentEnd = this.EmploymentEnd
        };

    }
}
