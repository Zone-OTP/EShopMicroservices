
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CatalogAPI.Products.GetProductsByCategory
{
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductsByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/Products/Category/{Category}", async (string Category, ISender sender) =>
            {
                var result = sender.Send(new GetProductByCategoryQuery(Category));

                var response = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);
            }).WithName("GetProductsByCategory")
              .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Get Product By Category")
              .WithDescription("Get Product By Category");
        }
    }
}
