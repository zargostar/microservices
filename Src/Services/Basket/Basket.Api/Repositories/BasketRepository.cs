using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Repositories
{
    public class BasketRepository:IBasketRepository
    {
        private readonly IDistributedCache _redisCache;
    public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetBasket(string UserName)
        {
            var basket = await _redisCache.GetStringAsync(UserName);
            if (string.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
           // throw new NotImplementedException();
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            //return _redisCache.SetAsync()
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
          //  _redisCache.SetAsync()

            return await GetBasket(basket.UserName);
        }
    }
}
