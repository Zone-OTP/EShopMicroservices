
using CatalogAPI.Products.GetProducts;

namespace CatalogAPI.Products.GetProductById
{
    public record GetRecordByIdResponse(Product Product);
    public class GetProductByIdEndPointEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {

                var result = await sender.Send(new GetProductByIdQuery(id));

                var response = result.Adapt<GetRecordByIdResponse>();


                return Results.Ok(response);
            })
              .WithName("GetProductsById")
              .Produces<GetProductsResponse>(StatusCodes.Status201Created)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Get Product By Id")
              .WithDescription("Get Product By Id"); ;
        }
    }
}
