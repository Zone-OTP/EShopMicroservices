
namespace BasketAPI.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName):ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand> 
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }

    internal class DeleteBasketCommandHandler(IBasketRepositroy repositroy) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            await repositroy.DeleteBasket(command.UserName, cancellationToken);

            return new DeleteBasketResult(true);
        }
    }
}
