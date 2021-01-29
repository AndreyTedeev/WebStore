using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Data;
using WebStore.Interfaces;
using WebStore.Models;

namespace WebStore.Services
{
    public class EmployeesService : IEmployeesService
    {

        private readonly List<Employee> _employees;
        private int _currentMaxId;

        public EmployeesService()
        {
            _employees = TestData.Employees;
            _currentMaxId = _employees.DefaultIfEmpty().Max(employee => employee.Id);
        }

        public void Add(Employee employee)
        {
            Action action = employee switch
            {
                null => throw new ArgumentNullException(nameof(employee)),
                _ => _employees.Contains(employee) switch
                {
                    true => null,
                    false => () =>
                    {
                        employee.Id = ++_currentMaxId;
                        _employees.Add(employee);
                    }
                }
            };
            action?.Invoke();
        }

        public bool Delete(int id) => Get(id) switch
        {
            null => false,
            Employee e => _employees.Remove(e)
        };

        public IEnumerable<Employee> Get() => _employees;

        public Employee Get(int id) => _employees.SingleOrDefault(employee => employee.Id == id);

        public void Update(Employee employee)
        {
            // SAME RESULT AS BELOW BUT LESS READABLE
            //Action action = (employee, _employees.Contains(employee), Get(employee.Id)) switch
            //{
            //    (null, _, _) => throw new ArgumentNullException(nameof(employee)),
            //    (Employee source, true, _) => null,
            //    (Employee source, false, null) => null,
            //    (Employee source, false, Employee target) => () =>
            //       {
            //           target.LastName = source.LastName;
            //           target.FirstName = source.FirstName;
            //           target.Patronymic = source.Patronymic;
            //           target.Birthday = source.Birthday;
            //           target.EmploymentStart = source.EmploymentStart;
            //           target.EmploymentEnd = source.EmploymentEnd;
            //       }
            //};
            Action action = employee switch
            {
                null => throw new ArgumentNullException(nameof(employee)),
                Employee source => _employees.Contains(source) switch
                {
                    true => null,
                    false => Get(source.Id) switch
                    {
                        null => null,
                        Employee target => () =>
                        {
                            target.LastName = source.LastName;
                            target.FirstName = source.FirstName;
                            target.Patronymic = source.Patronymic;
                            target.Birthday = source.Birthday;
                            target.EmploymentStart = source.EmploymentStart;
                            target.EmploymentEnd = source.EmploymentEnd;
                        }
                    }
                }
            };
            action?.Invoke();
        }

    }
}
