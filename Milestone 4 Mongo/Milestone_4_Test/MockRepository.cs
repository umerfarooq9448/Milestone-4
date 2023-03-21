using Milestone_4_Mongo.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Milestone_4_Mongo.Models;

namespace Milestone_4_Test
{
    internal class MockRepository
    {
        public static Mock<Iproduct> ProductMockRepository()
        {
            var products = new List<Product>
            {
                new Product {
                    id =  "",
                    name = "string",
                    category = "string",
                    image= "string",
                    price =0,
                    countInStock= 0,
                    brand="string",
                    rating=0,
                    reviews= 0,
                    description = "string"

                    },
                new Product {
                    id =  "",
                    name = "string2",
                    category = "string2",
                    image= "string2",
                    price =0,
                    countInStock= 0,
                    brand="string2",
                    rating=0,
                    reviews= 0,
                    description = "string2"

                    }

            };



            var mockRepo = new Mock<Iproduct>();

            mockRepo.Setup(r => r.getProductsAsync()).Returns(products);

            return mockRepo;



        }
    }
}
