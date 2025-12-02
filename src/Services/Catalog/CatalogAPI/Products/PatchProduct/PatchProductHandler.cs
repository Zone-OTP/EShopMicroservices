
namespace CatalogAPI.Products.PatchProduct
{
    public record PatchProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) 
        : ICommand<PatchProductResult>;
    public record PatchProductResult(bool IsSuccsess);
    public class PatchProductCommandValidator : AbstractValidator<PatchProductCommand> 
    {
        public PatchProductCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id Can't Be Empty");
         
            RuleFor(command => command.Name).NotEmpty().WithMessage("Name Can't be empty").Length(2, 150).WithMessage("Name Has to be between 2 and 150 charecters");

            RuleFor(command => command.Price).GreaterThan(0).WithMessage("Price has to be greater than 0");
        }
    }
    internal class PatchProductCommandHandler(IDocumentSession session) : ICommandHandler<PatchProductCommand, PatchProductResult>
    {
        public async Task<PatchProductResult> Handle(PatchProductCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException(command.Id);
            }

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            session.Update(product);
            await session.SaveChangesAsync();

            return new PatchProductResult(true);
        }
    }
}
