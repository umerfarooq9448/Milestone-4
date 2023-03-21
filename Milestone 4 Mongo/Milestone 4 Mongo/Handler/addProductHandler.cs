using MediatR;
using Milestone_4_Mongo.Commands;
using Milestone_4_Mongo.Data_Access;
using Milestone_4_Mongo.Models;

namespace Milestone_4_Mongo.Handler
{
    public class addProductHandler : IRequestHandler<addProductCommand, string>
    {
        private readonly Iproduct _product;

        public addProductHandler(Iproduct product)
        {
            _product = product;
        }
        public async Task<string> Handle(addProductCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult( await _product.addProduct(request.product));
        }

       
    }
}
