using System.Text.Json.Serialization;
using Catalog.API.Product.CreateProduct;

// This is where we define what types we want to be serialized using source generation
[JsonSerializable(typeof(CreateProductRequest))]
[JsonSerializable(typeof(CreateProductResponse))]
internal partial class AppJsonContext : JsonSerializerContext
{
}