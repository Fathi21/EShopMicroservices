using Catalog.API.Product.GetProduct;

namespace Catalog.API.Product.GetProductById;
using Catalog.API.Models;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductResult>;

internal class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductResult>
{
    
    public async Task<GetProductResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        // search product by Id from the database
        var prod = await session.Query<Product>()
            .FirstOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        if (prod == null)
        {
            throw new KeyNotFoundException($"Product with ID {query.Id} not found.");
        }
        // Map product to GetProductResult and return one product
        return new GetProductResult(
            prod.Id,
            prod.Name,
            prod.Category,
            prod.Description,
            prod.ImageFile,
            prod.Price
        );
    }
}