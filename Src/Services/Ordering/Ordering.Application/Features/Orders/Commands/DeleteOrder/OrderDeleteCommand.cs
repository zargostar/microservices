using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class OrderDeleteCommand:IRequest
    {
        public OrderDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
