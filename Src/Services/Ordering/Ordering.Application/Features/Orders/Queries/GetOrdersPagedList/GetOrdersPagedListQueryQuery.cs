using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersPagedList
{
    class GetOrdersPagedListQueryQuery : IRequestHandler<GetOrdersPagedListQuery, List<OrderPagedListVm>>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrdersPagedListQueryQuery(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OrderPagedListVm>> Handle(GetOrdersPagedListQuery request, CancellationToken cancellationToken)
        {
          var res= await _repository.GetOrdersPagedList(request.searchFilter, request.searchkey, request.page, request.pageSize);
            return _mapper.Map<List<OrderPagedListVm>>(res);
            // return res;
            //throw new NotImplementedException();
        }
    }
}
