


namespace CatalogAPI.Products.PatchProduct
{
    public record PatchProductCommand(Guid Id) : ICommand<PatchProductResult>;
    public record PatchProductResult(Guid Id,string Name);
    internal class PatchProductCommandHandler(IDocumentSession session) : ICommandHandler<PatchProductCommand, PatchProductResult>
    {
        public async Task<PatchProductResult> Handle(PatchProductCommand Command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(Command.Id, cancellationToken);

            product.Name = "KEKW IT WORKED";

            session.Store(product);
            await session.SaveChangesAsync();

            return new PatchProductResult(product.Id,product.Name);
        }
    }
}
