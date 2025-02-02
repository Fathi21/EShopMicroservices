using System.Text.Json.Serialization;
using Catalog.API.Product.CreateProduct;
using Catalog.API.Product.DeleteProductById;
using Catalog.API.Product.GetProduct;
using Catalog.API.Product.GetProductById;
using Microsoft.AspNetCore.Mvc;

// This is where we define what types we want to be serialized using source generation
// Annotate types for source generation
[JsonSerializable(typeof(CreateProductRequest))]
[JsonSerializable(typeof(CreateProductResponse))]
[JsonSerializable(typeof(List<GetProductResult>))]  // Include list of results
[JsonSerializable(typeof(GetProductByIdResponse))]
[JsonSerializable(typeof(DeleteProductResult))]
[JsonSerializable(typeof(DeleteProductByResponse))]


internal partial class AppJsonContext : JsonSerializerContext
{
}