
using CatalogAPI.Products.GetProducts;


namespace CatalogAPI.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id):IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery> 
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty().WithMessage("Id Can't Be Empty");
        }
    }

    internal class GetProductByIdQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if (product is null) 
            {
                throw new ProductNotFoundException(query.Id);
            }

            return new GetProductByIdResult(product);
        }
    }
}
