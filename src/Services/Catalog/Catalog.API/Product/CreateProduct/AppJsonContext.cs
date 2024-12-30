using System.Text.Json.Serialization;
using Catalog.API.Product.CreateProduct;
using Catalog.API.Product.GetProduct;

// This is where we define what types we want to be serialized using source generation
// Annotate types for source generation
[JsonSerializable(typeof(CreateProductRequest))]
[JsonSerializable(typeof(CreateProductResponse))]
[JsonSerializable(typeof(List<GetProductResult>))]  // Include list of results
[JsonSerializable(typeof(GetProductResult))]

internal partial class AppJsonContext : JsonSerializerContext
{
}