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

        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Patronymic { get; }

        public DateTime Birthday { get; }

        public DateTime EmploymentStart { get; }

        public DateTime? EmploymentEnd { get; } = null;

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
