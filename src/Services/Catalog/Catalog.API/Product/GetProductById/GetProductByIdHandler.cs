using Catalog.API.Models;


public record GetProductByIdResult(Product Product);


// Query for fetching a product by ID
public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

// Handler for the query
internal class GetProductByIdHandler(IDocumentSession session, ILogger<GetProductByIdHandler> logger) 
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        // Search product by ID from the database
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with ID {query.Id} not found.");
        }

        return new GetProductByIdResult(product);
    }
}