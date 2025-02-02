namespace Catalog.API.Product.DeleteProductById;

public record DeleteProductByResponse(bool Success, string Message);

public class DeleteProductByIdEndPoint:ICarterModule
{
     public void AddRoutes(IEndpointRouteBuilder app)
     {
         app.MapDelete("/product/{id:guid}",async (Guid id, ISender sender) =>
         {
             // Create and send the delete query
             var query = new DeleteProductByIdCommand(id);
             
             var result = await sender.Send(query);

             var respone = result.Adapt<DeleteProductByResponse>();
             
             // Return a success response
             return Results.Ok(respone);
           })
           .WithName("DeleteProductById") // Assigns a name to the endpoint
           .WithTags("Products")          // Organizes endpoints by tags (useful for Swagger)
           .Produces(204)                 // Indicates a successful no-content response
           .ProducesProblem(404);         // Produces a 404 error if the product isn't found
        }
}