namespace Catalog.API.Product.GetProduct;

using Catalog.API.Models;

public record GetAllProductsQuery() : IQuery<List<GetProductResult>>;
//public record GetProductResult(IEnumerable<Product> Products);
public record GetProductResult(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);

internal class GetAllProductsHandler(IDocumentSession session) : IQueryHandler<GetAllProductsQuery, List<GetProductResult>>
{
    public async Task<List<GetProductResult>> Handle(GetAllProductsQuery command, CancellationToken cancellationToken)
    {
        // Fetch all products from the database
        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        // Map products to GetProductResult and return as a list
        return products.Select(product => new GetProductResult(
            product.Id,
            product.Name,
            product.Category,
            product.Description,
            product.ImageFile,
            product.Price
        )).ToList();
    }
}