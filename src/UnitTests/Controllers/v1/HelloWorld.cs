using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.PfCoreHelloWorld.v1.Controllers;

namespace PF.PfCoreHelloWorld.UnitTests.Controllers.v1
{
    [TestClass]
    public class HelloWorld
    {

        [TestMethod]
        public void ShouldBe_Succeeds_WhenGetReturnsHelloWorld()
        {
            //Arrange
            var controller = new HelloWorldController();

            //Act
            var response = controller.Get().Result as OkObjectResult;

            //Assert
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            response.Value.Should().Be("Hello World");
        }
    }
}
