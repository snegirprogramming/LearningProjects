using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Infrastructure.Data;

namespace WarehouseManagementSystem.Infrastructure
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(WarehouseContext context)
            : base(context)
        {
        }

        public override IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return context.Orders
                .Include(x => x.LineItems)
                .ThenInclude(x => x.Item)
                .Where(predicate)
                .ToList();
        }

        public override Order Update(Order entity)
        {
            Order toUpdate = context.Orders
                .Include(x => x.LineItems)
                .ThenInclude(x => x.Item)
                .Single(x => x.Id == entity.Id);

            toUpdate.CreatedAt = entity.CreatedAt;
            toUpdate.LineItems = entity.LineItems;

            return base.Update(entity);
        }
    }
}
