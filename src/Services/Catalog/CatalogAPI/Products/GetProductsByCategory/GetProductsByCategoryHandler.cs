
namespace CatalogAPI.Products.GetProductsByCategory
{
    public record GetProductByCategoryQuery(string Category):IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    public class GetProdductByCategoryQueryValidator : AbstractValidator<GetProductByCategoryQuery> 
    {
        public GetProdductByCategoryQueryValidator()
        {
            RuleFor(query => query.Category).NotEmpty().WithMessage("Category Canot be Empty");
        }
    }
    internal class GetProductsByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {

            var products = await session.Query<Product>().Where(p => p.Category.Contains(query.Category)).ToListAsync(cancellationToken);

            return new GetProductByCategoryResult(products); ;
        }
    }
}
