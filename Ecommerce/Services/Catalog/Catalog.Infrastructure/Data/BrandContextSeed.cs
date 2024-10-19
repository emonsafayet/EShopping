using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            bool checkBrands = brandCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "brands.json");
            if (!checkBrands)
            {
                var brandData = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                if (brands != null)
                {
                    foreach (var brand in brands)
                    {
                        brandCollection.InsertOneAsync(brand);
                    }
                }
            }
        }
    }
}
