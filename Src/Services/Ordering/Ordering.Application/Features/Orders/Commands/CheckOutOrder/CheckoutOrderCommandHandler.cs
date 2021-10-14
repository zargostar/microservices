using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistance;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CheckOutOrder
{
    class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            //  _orderRepository.AddAsync(request)
            var orderentity = _mapper.Map<Order>(request);
           var res=await _orderRepository.AddAsync(orderentity);
            return res.Id;
           // throw new NotImplementedException();
        }
    }
}
