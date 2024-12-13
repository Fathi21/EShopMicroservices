namespace Catalog.API.Product.CreateProduct;

public record CreateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);

public record CreateProductResponse(Guid Id);

public class CreateProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateProductRequest request, ISender sender) =>
            {
                // Map request to command using Mapster
                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                // Map result to response

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);
            }) 
            .WithName("CreateProduct")                   // Assigns a name to the endpoint for better routing control
            .WithTags("Products")                        // Organizes endpoints by tags (useful for Swagger documentation)
            .Produces<CreateProductResponse>(201)        // Specifies that the endpoint returns a 201 status with a CreateProductResponse
            .ProducesProblem(400)                        // Adds a 400 response for validation errors
            .ProducesProblem(500);   
    }
}