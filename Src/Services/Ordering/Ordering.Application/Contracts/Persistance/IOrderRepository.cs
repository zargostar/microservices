using Ordering.Application.Features.Orders.Queries.GetOrdersPagedList;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistance
{
    public interface IOrderRepository: IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
        Task<IEnumerable<OrderPagedListVm>> GetOrdersPagedList(int? searchFilter, string searchkey, int page, int pageSize);
    }

   
}
