using Catalog.API.Models;


public record GetProductByResult(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);


// Query for fetching a product by ID
public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByResult>;

// Handler for the query
internal class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByResult>
{
    public async Task<GetProductByResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        // Search product by ID from the database
        var prod = await session.Query<Product>()
            .FirstOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        if (prod == null)
        {
            throw new KeyNotFoundException($"Product with ID {query.Id} not found.");
        }

        // Map product to GetProductByResult and return
        return new GetProductByResult(
            prod.Id,
            prod.Name,
            prod.Category,
            prod.Description,
            prod.ImageFile,
            prod.Price
        );
    }
}