namespace Catalog.API.Product.GetProductById;
using Catalog.API.Product.GetProduct;
using Catalog.API.Models;

public record GetProductByIdResponse(Product Product);

public class GetProductByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/product/{id:guid}",
                async (Guid id, ISender sender) =>
                {
                    // Create the query with the provided ID
                    var query = new GetProductByIdQuery(id);

                    // Send the query to the handler
                    var result = await sender.Send(query);

                    var response = result.Adapt<GetProductByIdResponse>();

                    // Return the result directly
                    return Results.Ok(response);
 
                }) 
            .WithName("GetProductById")                  // Assigns a name to the endpoint for better routing control
            .WithTags("Products")                     // Organizes endpoints by tags (useful for Swagger documentation)
            .Produces<GetProductResult>(200)  // Specifies a 200 status with the response
            .ProducesProblem(500);    
    }
}