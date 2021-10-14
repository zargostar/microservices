using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersPagedList
{
   public class GetOrdersPagedListQuery:IRequest<List<OrderPagedListVm>>
    {
        //int? searchFilter, string searchkey, int page, int pageSize
        public string searchkey { get; set; }
        public int? searchFilter { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }

    }
}
