using Basket.Api.Entities;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{UserName}",Name = "GetBasket")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string UserName)
        {
            var basket =await _repository.GetBasket(UserName);
            return Ok(basket ?? new ShoppingCart(UserName));

        }
        [HttpGet("[action]/{UserId}")]
        // we can not post two method without action
        // [HttpGet("GetBaskett")]
        //"[action]/{category}"
        public ActionResult GetBaskett(string UserId)
        {
           var basket = "hello"+UserId;
            return  Ok(basket);

        }

        //

        [HttpPost(Name = "UpdateBasket")]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket( [FromBody]ShoppingCart basket)
        {
            var res = await _repository.UpdateBasket(basket);
               return Ok(res);
        }
        [HttpDelete("{UserName}",Name = "DeletBasket")]
        public async Task DeletBasket(string UserName)
        {
            await _repository.DeleteBasket(UserName);
           // return Ok();
        }
      
            
    }
}
