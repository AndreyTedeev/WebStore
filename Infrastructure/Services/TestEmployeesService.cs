using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Data;
using WebStore.Interfaces;
using WebStore.Models;

namespace WebStore.Services
{
    public class TestEmployeesService : IEmployeesService
    {

        private readonly List<Employee> _employees;
        private int _currentMaxId;

        public TestEmployeesService()
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
            Action action = employee switch
            {
                null => throw new ArgumentNullException(nameof(employee)),
                _ => _employees.Contains(employee) switch
                {
                    true => null,
                    false => Get(employee.Id) switch
                    {
                        null => null,
                        Employee e => () =>
                        {
                            e.LastName = employee.LastName;
                            e.FirstName = employee.FirstName;
                            e.Patronymic = employee.Patronymic;
                            e.Birthday = employee.Birthday;
                            e.EmploymentStart = employee.EmploymentStart;
                            e.EmploymentEnd = employee.EmploymentEnd;
                        }
                    }
                }
            };
            action?.Invoke();
        }

    }
}
