using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistance;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandhandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateOrderCommandhandler(IOrderRepository repository, IMapper mapper, ILogger logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var OrderToUpdate = await _repository.GetByIdAsync(request.Id);
             _mapper.Map(request,OrderToUpdate,typeof(UpdateOrderCommand),typeof(Order));
              await _repository.UpdateAsync(OrderToUpdate);
            _logger.LogInformation("Order Update Successfully");
            return Unit.Value;
        }
    }
}
