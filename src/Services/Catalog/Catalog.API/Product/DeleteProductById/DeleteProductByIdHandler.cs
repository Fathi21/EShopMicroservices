namespace Catalog.API.Product.DeleteProductById;
using Catalog.API.Models;

public record DeleteProductByIdCommand(Guid Id) : ICommand<DeleteProductResult>;

public record DeleteProductResult (bool Success, string Message);

public class DeleteProductByIdHandler (IDocumentSession session) : ICommandHandler<DeleteProductByIdCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
    {
        // Search for the product by ID
        var product = await session.LoadAsync<Models.Product>(command.Id, cancellationToken);

        if (product == null)
        {
            return new DeleteProductResult(false, $"Product with ID: {command.Id} has not been found.");
        }

        // Remove the product
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true, $"Product with ID: {command.Id} has been deleted.");
    }
}