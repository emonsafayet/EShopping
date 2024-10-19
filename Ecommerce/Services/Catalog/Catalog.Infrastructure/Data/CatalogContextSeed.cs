using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool checkProduct = productCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "products.json");
            if (!checkProduct)
            {
                var typeData = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(typeData);
                if (products != null)
                {
                    foreach (var item in products)
                    {
                        productCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}
