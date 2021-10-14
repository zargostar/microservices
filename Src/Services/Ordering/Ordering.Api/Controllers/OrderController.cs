using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CheckOutOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrderList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{username}")]
        public async Task<ActionResult< IEnumerable<OrdersVM>>> GetOrdersByUserName(string username)
        {
            var query = new GetOrdersListQuery(username);
            var res=await _mediator.Send(query);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CkechOutOrder([FromBody]CheckoutOrderCommand command)
        {
            int orderid = await _mediator.Send(command);
            return Ok(orderid);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder ([FromBody]UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{orderid}")]
        public async Task<ActionResult> DeleteOrder(int orderid)
        {
            var command = new OrderDeleteCommand(orderid);
            // var orderid = new OrderDeleteCommand(orderid);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
