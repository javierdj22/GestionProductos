using Xunit;
using GestionProductos.Data;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

public class ProductServiceTests
{
    private ProductService GetService()
    {
        var config = new ConfigurationBuilder().AddInMemoryCollection(
            new Dictionary<string, string> { { "ConnectionStrings:MongoDb", "mongodb://localhost:27017" } }
        ).Build();

        return new ProductService(config);
    }

    [Fact]
    public async Task AddProduct_PriceIsZero()
    {
        var service = GetService();
        var product = new Product { Name = "TestInvalid", Price = 0, Stock = 10 };

        var exception = await Record.ExceptionAsync(
            async () => await service.AddProductAsync(product)
        );

        Assert.Null(exception);
    }

    [Fact]
    public async Task AddProduct_NameNull()
    {
        var service = GetService();
        var product = new Product { Name = "", Price = 10, Stock = 10 };

        var exception = await Record.ExceptionAsync(
            async () => await service.AddProductAsync(product)
        );

        Assert.Null(exception);
    }

    [Fact]
    public async Task AddProduct_Ok()
    {
        var service = GetService();
        var product = new Product { Name = "TestValid", Price = 10, Stock = 15 };

        var exception = await Record.ExceptionAsync(
            async () => await service.AddProductAsync(product)
        );

        Assert.Null(exception); 
    }
}
