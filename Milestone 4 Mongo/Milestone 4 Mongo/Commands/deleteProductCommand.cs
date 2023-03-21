using MediatR;

namespace Milestone_4_Mongo.Commands
{
    public record deleteProductCommand(string id):IRequest<string>;
    
}
