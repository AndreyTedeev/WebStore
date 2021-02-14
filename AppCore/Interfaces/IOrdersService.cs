using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entities;

namespace WebStore.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetOrders(string userName);

        Task<Order> GetOrder(int id);

        Task<int> Add(Order order);
    }
}
