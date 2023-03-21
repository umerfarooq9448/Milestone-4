using MediatR;
using Milestone_4_Mongo.Data_Access;
using Milestone_4_Mongo.Models;
using Milestone_4_Mongo.Queries;

namespace Milestone_4_Mongo.Handler
{
    public class getProductByIdhandler : IRequestHandler<getProductByIdQuery, Product>
    {
        private readonly Iproduct _product;
        public getProductByIdhandler(Iproduct product)
        {
                _product = product;
        }
        public async Task<Product> Handle(getProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _product.getProductById(request.id));
        }
    }
}
