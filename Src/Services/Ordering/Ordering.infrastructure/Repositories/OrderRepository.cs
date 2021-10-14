using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Features.Orders.Queries.GetOrdersPagedList;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext orderContext) : base(orderContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var res = await _dbContext.Orders.Where(p => p.UserName == userName).ToListAsync();
            return res;
        }

        public Task<IEnumerable<OrderPagedListVm>> GetOrdersPagedList(int? searchFilter, string searchkey, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
