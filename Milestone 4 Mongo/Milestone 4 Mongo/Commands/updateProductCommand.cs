using MediatR;
using Milestone_4_Mongo.Models;

namespace Milestone_4_Mongo.Commands
{
    public record updateProductCommand(Product product):IRequest<string>;
   
}
