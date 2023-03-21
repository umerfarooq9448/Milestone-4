using Milestone_4_Mongo.Models;

namespace Milestone_4_Mongo.Data_Access
{
    //contains the definitions of all the methods
    public interface Iproduct
    {   

        
        public  List<Product> getProductsAsync();

        public  Task<Product> getProductById(string id);

        public Task<string> addProduct(Product product);

        public Task<string> updateProduct(Product product);
        public Task<string> deleteProduct(string id);





    }
}
