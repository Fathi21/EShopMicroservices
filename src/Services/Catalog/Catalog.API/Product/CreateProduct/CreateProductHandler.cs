namespace Catalog.API.Product.CreateProduct;
using buildingBlocks.CQRS;
using Catalog.API.Models;


public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
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

        // return CreateProductResult Result
        
        return new CreateProductResult(Guid.NewGuid());
        
        
    }
}