using Microsoft.Extensions.Options;
using Milestone_4_Mongo.Data_Access;
using Milestone_4_Mongo.Models;
using MongoDB.Driver;

namespace Milestone_4_Mongo.Repository
{   

    public class ProductRepository : Iproduct
    {

        private readonly IMongoCollection<Product> _productsCollection;

        public ProductRepository(IOptions<ProductStoreSetting> productStoreSetting) {

            var mongoClient = new MongoClient(productStoreSetting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(productStoreSetting.Value.DatabaseName);

            _productsCollection = mongoDatabase.GetCollection<Product>(productStoreSetting.Value.ProductsDatabaseCollectionName);



        }

        //add product 

        public async Task<string> addProduct(Product product)
        {
            await _productsCollection.InsertOneAsync(product);
            return "Added";
        }

        //method to delete product
        public async  Task<string> deleteProduct(string id)
        {
            await _productsCollection.DeleteOneAsync(x => x.id == id);
            return "deleted";
        }

        //method to get product by id
        public async Task<Product> getProductById(string id)
        {
            return await _productsCollection.Find(x => x.id == id).FirstOrDefaultAsync();
        }


        //method to get all products
        public  List<Product> getProductsAsync()
        {
          return  _productsCollection.Find( _ => true).ToList();
       
        }


        // method to update product
        public async Task<string> updateProduct( Product product)
        {
            await _productsCollection.ReplaceOneAsync(x => x.id == product.id, product);
            return "Updated";
        }
    }
}
