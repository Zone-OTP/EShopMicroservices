using BasketAPI.Models;

namespace BasketAPI.Data
{
    public interface IBasketRepositroy
    {
        Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default);

        Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default);

        Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
    }
}
