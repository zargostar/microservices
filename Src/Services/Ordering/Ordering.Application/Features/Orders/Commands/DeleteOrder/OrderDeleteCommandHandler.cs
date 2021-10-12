using MediatR;
using Ordering.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand>
    {
        private readonly IOrderRepository __repository;

        public OrderDeleteCommandHandler(IOrderRepository repository)
        {
            __repository = repository;
        }

        public async Task<Unit> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
          var OrderToDelet=await  __repository.GetByIdAsync(request.Id);
            await __repository.DeleteAsync(OrderToDelet);
            return Unit.Value;
        }
    }
}
