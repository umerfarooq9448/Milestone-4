using MediatR;
using Milestone_4_Mongo.Commands;
using Milestone_4_Mongo.Data_Access;

namespace Milestone_4_Mongo.Handler
{
    public class updateProductHandler : IRequestHandler<updateProductCommand, string>
    {
        private readonly Iproduct product;

        public updateProductHandler(Iproduct product)
        {
            this.product = product;
        }

        public async Task<string> Handle(updateProductCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await product.updateProduct(request.product));
        }
    }
}
