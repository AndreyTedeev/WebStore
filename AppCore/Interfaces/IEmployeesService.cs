using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Interfaces
{
    public interface IEmployeesService
    {
        IEnumerable<Employee> Get();

        Employee Get(int id);

        void Add(Employee employee);

        void Update(Employee employee);

        bool Delete(int id);
    }
}
