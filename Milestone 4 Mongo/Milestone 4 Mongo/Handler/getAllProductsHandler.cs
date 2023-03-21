using MediatR;
using Milestone_4_Mongo.Data_Access;
using Milestone_4_Mongo.Models;
using Milestone_4_Mongo.Queries;

namespace Milestone_4_Mongo.Handler
{
    public class getAllProductsHandler : IRequestHandler<getAllProductsQuery, List<Product>>
    {
        private readonly Iproduct _product;

        public getAllProductsHandler(Iproduct product)
        {
            _product = product;
        }
        public async Task<List<Product>> Handle(getAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult( _product.getProductsAsync());
        }
    }
}
