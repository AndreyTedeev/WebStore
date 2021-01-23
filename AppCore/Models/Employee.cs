using System;

namespace WebStore.Models
{

    public record Employee
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; } = DateTime.Now;

        public DateTime EmploymentStart { get; set; } = DateTime.Now;

        public DateTime? EmploymentEnd { get; set; } = null;

        public bool IsActive => EmploymentEnd is not null;

        public int Age => Helper.DateDiffInYears(DateTime.Today, Birthday);

        public int Seniority => Helper.DateDiffInYears(EmploymentEnd ?? DateTime.Today, EmploymentStart);

        public string FullName => String.Format($"{LastName}, {FirstName} {Patronymic}");

    }
}
