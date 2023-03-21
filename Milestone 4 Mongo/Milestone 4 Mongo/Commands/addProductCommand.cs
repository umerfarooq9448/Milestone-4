using MediatR;
using Milestone_4_Mongo.Models;

namespace Milestone_4_Mongo.Commands
{
    public record addProductCommand(Product product):IRequest<string>;
   
}
