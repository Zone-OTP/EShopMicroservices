using BasketAPI.Models;

namespace BasketAPI.Basket.GetBasket
{
    public record GetBasketQuery(string UserName):IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    internal class GetBasketQueryHandler(IDocumentSession session) : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}
