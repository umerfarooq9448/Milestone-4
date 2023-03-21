using AutoFixture;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Milestone_4_Mongo.Controllers;
using Milestone_4_Mongo.Models;
using Milestone_4_Mongo.Queries;
using Moq;
using Milestone_4_Mongo.Commands;


namespace Milestone_4_Test
{
    [TestClass]

    public class UnitTest1
    {
        private Mock<IMediator> _mediatorMock;
        private ProductsController _controller;
        private Fixture _fixture;


        [TestInitialize]
        public void Initialize()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ProductsController(_mediatorMock.Object);
            _fixture = new Fixture();


        }



        //method to test the getAllProducts api
        [TestMethod]
        public async Task GetAllProducts_ShouldReturnOkWithProductsList()
        {
            // Arrange
            var newproducts = _fixture.CreateMany<Product>().ToList();

            _mediatorMock.Setup(x => x.Send(It.IsAny<getAllProductsQuery>(), default)).ReturnsAsync(newproducts);

            // Act
            var result = await _controller.getAllProduct();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            var resultValue = okResult.Value as List<Product>;
            Assert.IsNotNull(resultValue);
            CollectionAssert.AreEqual(newproducts, resultValue);
        }



        //method to test the delete product api
        [TestMethod]
        public async Task DeleteProduct_ShouldReturnStatusCode200()
        {
            // Arrange
            var id = "";

            // Act
            var result = await _controller.deleteProduct(id);

            // Assert
            var statusCodeResult = result as StatusCodeResult;
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(200, statusCodeResult.StatusCode);
            _mediatorMock.Verify(x => x.Send(It.IsAny<deleteProductCommand>(), default), Times.Once);
        }

        //method to test the update product api
        [TestMethod]
        public async Task UpdateProduct_ShouldReturnStatusCode200()
        {
            
            // Arrange
            var newproducts = _fixture.Create<Product>();
            // Act

            //here we are setting up the getproductbyidquery so the it returns newproduct
            _mediatorMock.Setup(x=>x.Send(It.IsAny<getProductByIdQuery>(), default)).ReturnsAsync(newproducts); 
           

            var result = await _controller.updateProduct(newproducts.id, newproducts);

            // Assert
            var statusCodeResult = result as StatusCodeResult;
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(200, statusCodeResult.StatusCode);
            _mediatorMock.Verify(x => x.Send(It.IsAny<updateProductCommand>(), default), Times.Once);
        }

        //method to test the add product api
        [TestMethod]
        public async Task Addproduct_ShouldReturnStatusCode200()
        {
            // Arrange
            var newproduct = _fixture.Create<Product>();

            

            // Act
            var result = await _controller.addProduct(newproduct);

            var statusCodeResult = result as StatusCodeResult;
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(200,statusCodeResult.StatusCode);
            _mediatorMock.Verify(x => x.Send(It.IsAny<addProductCommand>(), default), Times.Once);



        }





    }

    }
