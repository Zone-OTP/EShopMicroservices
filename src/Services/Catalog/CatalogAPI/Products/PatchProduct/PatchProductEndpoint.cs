
using CatalogAPI.Products.CreateProduct;

namespace CatalogAPI.Products.PatchProduct
{
    public record PatchProductResponse(Guid Id, string Name);
    public record PatchProductRequest(string id);

    public class PatchProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPatch("/products/{Id}", async (Guid Id,ISender sender) =>
            {
                
                var command = new PatchProductCommand(Id);

                var result = await sender.Send(command);

                var response = result.Adapt<PatchProductResponse>();

                return Results.Ok($"Patched {response.Id} Name is now {response.Name}");
            })
            .WithName("PatchProduct")
            .Produces<PatchProductResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Patch Product")
            .WithDescription("Patch Product");
        }
    }
}
