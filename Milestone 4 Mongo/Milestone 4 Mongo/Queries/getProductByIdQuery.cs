using MediatR;
using Milestone_4_Mongo.Models;

namespace Milestone_4_Mongo.Queries
{
    public record getProductByIdQuery(string id):IRequest<Product>;
  
}
