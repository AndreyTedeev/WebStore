using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebStore.Interfaces;
using WebStore.Models;
using WebStore.Services;

namespace WebStore.ViewModels
{
    public record EmployeeViewModel : IValidatableObject
    {

        private readonly Employee _employee;

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee ?? new();
        }

        public EmployeeViewModel() : this((Employee)null) { }

        [HiddenInput(DisplayValue = false)]
        public int Id { get => _employee.Id; init => _employee.Id = value; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Length of FirstName ishould be from 2 to 15 symbols")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Shuld contain only characters")]
        public string FirstName { get => _employee.FirstName; init => _employee.FirstName = value; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Length of LastName ishould be from 2 to 15 symbols")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Shuld contain only characters starting with a capital")]
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // just an example of using service inside validation
            // var service = (IEmployeesService)validationContext.GetService(typeof(IEmployeesService));
            if (LastName == "Aaa")
                yield return new ValidationResult($"Bad {nameof(LastName)}", new[] { nameof(LastName) });
            yield return ValidationResult.Success;
        }
    }
}
