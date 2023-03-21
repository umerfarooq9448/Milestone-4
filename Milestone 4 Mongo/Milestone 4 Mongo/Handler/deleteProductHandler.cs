using MediatR;
using Milestone_4_Mongo.Commands;
using Milestone_4_Mongo.Data_Access;

namespace Milestone_4_Mongo.Handler
{
    public class deleteProductHandler : IRequestHandler<deleteProductCommand, string>
    {
        private readonly Iproduct _product;
        public deleteProductHandler(Iproduct product)
        {
            _product = product;
        }
        public async Task<string> Handle(deleteProductCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _product.deleteProduct(request.id));
        }
    }
}
