using MediatR;
using Milestone_4_Mongo.Models;

namespace Milestone_4_Mongo.Queries
{
    public record getAllProductsQuery:IRequest<List<Product>>;
  
}
