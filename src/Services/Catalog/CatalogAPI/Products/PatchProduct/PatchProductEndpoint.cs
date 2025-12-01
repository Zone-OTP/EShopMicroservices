
using CatalogAPI.Products.CreateProduct;

namespace CatalogAPI.Products.PatchProduct
{
    public record PatchProductRequest(Guid Id, string Name, List<string> Categiry, string Description, string ImageFile, decimal Price);
    public record PatchProductResponse(bool IsSuccess);

    public class PatchProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPatch("/products/{Id}", async (PatchProductRequest request,ISender sender) =>
            {

                var command = request.Adapt<PatchProductResponse>();

                var result = await sender.Send(command);

                var response = result.Adapt<PatchProductResponse>();

                return Results.Ok($"Patched {response.IsSuccess} ");
            })
            .WithName("PatchProduct")
            .Produces<PatchProductResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Patch Product")
            .WithDescription("Patch Product");
        }
    }
}
