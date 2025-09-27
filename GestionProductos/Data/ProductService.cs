using MongoDB.Driver;

namespace GestionProductos.Data
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("GestionProductosDb");
            _products = database.GetCollection<Product>("Products");
        }

        public async Task<List<Product>> GetProductsAsync() =>
            await _products.Find(_ => true).ToListAsync();

        public async Task AddProductAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("El nombre no puede estar vacío.");
            if (product.Price <= 0)
                throw new ArgumentException("El precio debe ser mayor que 0.");
            await _products.InsertOneAsync(product);
        }
    }
}
