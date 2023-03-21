using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milestone_4_Mongo.Commands;
using Milestone_4_Mongo.Models;
using Milestone_4_Mongo.Queries;

namespace Milestone_4_Mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //endpoint api to get  all the products
        [HttpGet]
        [Route("/getAllProducts")]
        public async Task<IActionResult> getAllProduct()
        {
            var products = await _mediator.Send(new getAllProductsQuery());
            return Ok(products);
        }

        //endpoint api to get product by id
        [HttpGet]
        [Route("/getProductById/{id}")]
        public async Task<IActionResult> getProductById(string id)
        {
            var product = await _mediator.Send(new getProductByIdQuery(id));
            return Ok(product);
        }

        //endpoint api to add product

        [HttpPost]
        [Route("/addProduct")]
        public async Task<IActionResult> addProduct([FromBody]Product product)
        {
            await _mediator.Send(new addProductCommand(product));
            return StatusCode(200);
        }

        //endpoint api to delete product

        [HttpDelete]
        [Route("/deleteProduct")]
        public async Task<IActionResult> deleteProduct(string id)
        {
            await _mediator.Send(new deleteProductCommand(id));
            return StatusCode(200);
        }


        //endpoint api to update product

        [HttpPut]
        [Route("/updateProduct")]
        public async Task<IActionResult> updateProduct(string id, Product product)
        {
            var findproduct = await _mediator.Send(new getProductByIdQuery(id));
            if (findproduct is null)
            {
                return NotFound();
            }

            product.id = id;
            await _mediator.Send(new updateProductCommand(product));
            
            return StatusCode(200);
        }
    }
}
