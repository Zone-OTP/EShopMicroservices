
namespace CatalogAPI.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id):ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);
    internal class DeleteProductCommandHandler(IDocumentSession session, ILogger logger) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            logger.LogInformation("DELETEING PRODUCT WITH ID {@ID}",request.Id);
            session.Delete<Product>(request.Id);

            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
