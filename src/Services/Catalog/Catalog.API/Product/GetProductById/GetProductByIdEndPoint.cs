using Catalog.API.Product.GetProduct;

namespace Catalog.API.Product.GetProductById;

public class GetProductByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/product/{id:guid}",
                async (Guid id, ISender sender) =>
                {
                    // Create the query we need the id 
                    // Send the query to the handler
                    // Map results to responses
                    // Return the result
                    
                    // Send the query
                    var query = new GetProductByIdQuery(id);
                        
                    var result = await sender.Send(query);

                    var response = result.Adapt<GetProductByIdQuery>();
                    
                    // Return the result directly
                    return Results.Ok(response);
                    
                }) 
            .WithName("GetProductById")                  // Assigns a name to the endpoint for better routing control
            .WithTags("Products")                     // Organizes endpoints by tags (useful for Swagger documentation)
            .Produces<GetProductResult>(200)  // Specifies a 200 status with the response
            .ProducesProblem(500);    
    }
}