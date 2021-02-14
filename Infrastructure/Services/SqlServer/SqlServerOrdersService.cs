using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Entities;
using WebStore.Interfaces;

namespace WebStore.Services.SqlServer
{
    public class SqlServerOrdersService : IOrdersService
    {
        private readonly Db _db;

        public SqlServerOrdersService(Db db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<Order>> GetOrders(string userName)
        {
            return await _db.Orders
                .Include((x) => x.User)
                .Include((x) => x.Items)
                .Where(x => x.User.UserName == userName)
                .ToArrayAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _db.Orders
                .Include((x) => x.User)
                .Include((x) => x.Items)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<int> Add(Order order)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            await transaction.CommitAsync();
            return order.Id;
        }
    }
}
