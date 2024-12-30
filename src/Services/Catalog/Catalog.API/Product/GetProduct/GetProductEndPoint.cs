namespace Catalog.API.Product.GetProduct;
using Catalog.API.Models;

public class GetProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products",
                async (ISender sender) =>
                {
                    // Create the query (no request body is needed)
                    // Send the query to the handler
                    // Map results to responses
                    // Return the result
                    
                    // Send the query
                    var query = new GetAllProductsQuery();
                        
                    var result = await sender.Send(query);

                    var response = result.Adapt<List<GetProductResult>>();
                    
                    // Return the result directly
                    return Results.Ok(response);
              

                }) 
            .WithName("GetProducts")                  // Assigns a name to the endpoint for better routing control
            .WithTags("Products")                     // Organizes endpoints by tags (useful for Swagger documentation)
            .Produces<List<GetProductResult>>(200)  // Specifies a 200 status with the response
            .ProducesProblem(500);    
    }
}