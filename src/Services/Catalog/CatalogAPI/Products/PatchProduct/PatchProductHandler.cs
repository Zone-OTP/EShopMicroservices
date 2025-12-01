


namespace CatalogAPI.Products.PatchProduct
{
    public record PatchProductCommand(Guid Id, string Name, List<string> Categiry, string Description, string ImageFile, decimal Price) 
        : ICommand<PatchProductResult>;
    public record PatchProductResult(bool IsSuccsess);
    internal class PatchProductCommandHandler(IDocumentSession session, ILogger logger) : ICommandHandler<PatchProductCommand, PatchProductResult>
    {
        public async Task<PatchProductResult> Handle(PatchProductCommand Command, CancellationToken cancellationToken)
        {
            logger.LogInformation("We Have Started Patching a Product {@Command}", Command);
            var product = await session.LoadAsync<Product>(Command.Id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException();
            }

            product.Name = Command.Name;
            product.Category = Command.Categiry;
            product.Description = Command.Description;
            product.ImageFile = Command.ImageFile;
            product.Price = Command.Price;

            session.Update(product);
            await session.SaveChangesAsync();

            return new PatchProductResult(true);
        }
    }
}
