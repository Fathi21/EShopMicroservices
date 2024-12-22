namespace Catalog.API.Product.CreateProduct;
using Catalog.API.Models;

public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Business logic to create a product 
        // Create product entity from commmand object
        // Save data to database 
        // return CreateProductResult Result

        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
        
        // Save data to database 
        
        session.Store(product);
        
        await session.SaveChangesAsync(cancellationToken);
        
        // return CreateProductResult Result
        
        return new CreateProductResult(product.Id);
        
        
    }
}