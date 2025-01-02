namespace Catalog.API.Product.GetProductById;

using Catalog.API.Product.GetProduct;

public class GetProductByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/product/{id:guid}",
                async (Guid id, ISender sender) =>
                {
                    try
                    {
                        // Create the query with the provided ID
                        var query = new GetProductByIdQuery(id);

                        // Send the query to the handler
                        var result = await sender.Send(query);

                        var response = result.Adapt<GetProductByIdQuery>();

                        // Return the result directly
                        return Results.Ok(response);
                    }
                    catch (KeyNotFoundException ex)
                    {
                        // Return 404 Not Found if the product does not exist
                        return Results.NotFound(new { Message = ex.Message });
                    }
                    catch (Exception ex)
                    {
                        // Return 500 Internal Server Error for any unexpected errors
                        return Results.Problem(ex.Message);
                    }

                }) 
            .WithName("GetProductById")                  // Assigns a name to the endpoint for better routing control
            .WithTags("Products")                     // Organizes endpoints by tags (useful for Swagger documentation)
            .Produces<GetProductResult>(200)  // Specifies a 200 status with the response
            .ProducesProblem(500);    
    }
}