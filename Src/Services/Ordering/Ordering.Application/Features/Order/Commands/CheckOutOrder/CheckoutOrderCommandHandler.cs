using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Ordering.Application.Features.Order.Commands.CheckOutOrder
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

        public Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var request = _mapper.Map<Order>(request);
            _orderRepository.AddAsync(request)
            throw new NotImplementedException();
        }
    }
}
