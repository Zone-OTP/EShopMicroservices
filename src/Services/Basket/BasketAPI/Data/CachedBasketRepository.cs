
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace BasketAPI.Data
{
    public class CachedBasketRepository(IBasketRepositroy repositroy, IDistributedCache cache) 
        : IBasketRepositroy
    {
        public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            await repositroy.DeleteBasket(userName, cancellationToken);

            await cache.RemoveAsync(userName, cancellationToken);

            return true;
        }

        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var cachedBasket = await cache.GetStringAsync(userName, cancellationToken);

            if (!string.IsNullOrEmpty(cachedBasket)) 
            {
                return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;            
            }
            var basket = await repositroy.GetBasket(userName, cancellationToken);
            await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);
            return basket;

        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            await repositroy.StoreBasket(basket, cancellationToken);

            await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));

            return basket;
        }
    }
}
