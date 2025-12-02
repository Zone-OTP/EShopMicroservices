
namespace BasketAPI.Basket.DeleteBasket
{
    public record DeleteBasketRespone(bool IsSuccess);
    public class DeleteBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("products/{userName}", async (string userName, ISender sender) =>
            {
                var request = sender.Send(new DeleteBasketCommand(userName));

                var response = request.Adapt<DeleteBasketRespone>();

                return Results.Ok(response);
            }).WithName("DeleteBasket")
            .Produces<DeleteBasketRespone>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Basket")
            .WithDescription("Delete Basket");

        }
    }
}
