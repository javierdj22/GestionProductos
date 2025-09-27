using Xunit;
using GestionProductos.Data;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

public class ProductServiceTests
{
    [Fact]
    public async Task AddProduct_ShouldThrow_WhenPriceIsZero()
    {
        var config = new ConfigurationBuilder().AddInMemoryCollection(
            new Dictionary<string, string> { { "ConnectionStrings:MongoDb", "mongodb://localhost:27017" } }
        ).Build();

        var service = new ProductService(config);
        var product = new Product { Name = "Test1234", Price = 10, Stock = 15 };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await service.AddProductAsync(product));
    }
}
