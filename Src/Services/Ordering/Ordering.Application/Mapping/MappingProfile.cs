using AutoMapper;
using Ordering.Application.Features.Order.Queries.GetOrderList;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Mapping
{
    class MappingProfile : Profile
    {

        // CreateMap<>
        public MappingProfile()
        {
            CreateMap<Order, OrdersVM>().ReverseMap();
        }
    }
}
