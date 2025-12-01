
namespace CatalogAPI.Products.GetProductsByCategory
{
    public record GetProductByCategoryQuery(string Category):IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    internal class GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger logger) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting All Products In Category @Category");

            var products = await session.Query<Product>().Where(p => p.Category.Contains(query.Category)).ToListAsync(cancellationToken);

            return new GetProductByCategoryResult(products); ;
        }
    }
}
