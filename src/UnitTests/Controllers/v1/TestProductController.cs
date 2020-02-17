using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PF.PfCoreHelloWorld.v1.Controllers;
using PF.PfCoreHelloWorld.v1.Models;

namespace PF.PfCoreHelloWorld.UnitTests.Controllers.v1
{
    [TestClass]
    public class TestProductController
    {
        [TestMethod]
        public void ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductController(testProducts);

            var result = controller.GetAllProducts() as List<Product>;
            result.Count.Should().Be(testProducts.Count);
        }

        //[TestMethod]
        //public void ShouldReturnCorrectProduct()
        //{
        //    var testProducts = GetTestProducts();
        //    var controller = new ProductController(testProducts);

        //    var result = controller.GetProduct(4) as ActionResult<Product>;
        //    result.Should().NotBeNull();
        //    testProducts[3].Name.Should().Be(((Product)((OkObjectResult)result.Result).Value).Name);
        //}

        [TestMethod]
        public void ShouldNotFindProduct()
        {
            var controller = new ProductController(GetTestProducts());

            var result = controller.GetProduct(999);
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void ShouldAddProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductController(testProducts);

            var product = new Product
            {
                Id = 101,
                Name = "Demo5",
                Price = 5.6M
            };

            controller.AddProduct(product);

            var result = controller.GetAllProducts() as List<Product>;
            result.Count.Should().Be(testProducts.Count + 1);
            result[4].Should().BeEquivalentTo(product);
        }

        [TestMethod]
        public void ShouldNotAddProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductController(testProducts);

            controller.AddProduct(null);

            var result = controller.GetAllProducts() as List<Product>;
            result.Count.Should().Be(testProducts.Count);
        }

        [TestMethod]
        public void ShouldUpdateProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductController(testProducts);

            var product = new Product
            {
                Id = 1,
                Name = "Demo5",
                Price = 5.6M
            };

            controller.UpdateProduct(product.Id, product);

            var result = controller.GetAllProducts() as List<Product>;
            result.Count.Should().Be(testProducts.Count);
            result[0].Should().BeEquivalentTo(product);
        }

        [TestMethod]
        public void ShouldNotUpdateProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductController(testProducts);

            controller.UpdateProduct(999, null);

            var result = controller.GetAllProducts() as List<Product>;
            result.Count.Should().Be(testProducts.Count);
            result[0].Should().BeEquivalentTo(testProducts[0]);
        }

        [TestMethod]
        public void ShouldNotUpdateProductWhenNotFound()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductController(testProducts);

            var product = new Product
            {
                Id = 1,
                Name = "Demo5",
                Price = 5.6M
            };

            controller.UpdateProduct(999, product);

            var result = controller.GetAllProducts() as List<Product>;
            result.Count.Should().Be(testProducts.Count);
            result[0].Should().BeEquivalentTo(testProducts[0]);
        }

        [TestMethod]
        public void ShouldRemoveProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductController(testProducts);

            controller.RemoveProduct(1);

            var result = controller.GetAllProducts() as List<Product>;
            result.Count.Should().Be(testProducts.Count - 1);
        }

        [TestMethod]
        public void ShouldNotRemoveProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductController(testProducts);

            controller.RemoveProduct(999);

            var result = controller.GetAllProducts() as List<Product>;
            result.Count.Should().Be(testProducts.Count);
        }

        private List<Product> GetTestProducts()
        {
            var testProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Demo1", Price = 1 },
                new Product { Id = 2, Name = "Demo2", Price = 3.75M },
                new Product { Id = 3, Name = "Demo3", Price = 16.99M },
                new Product { Id = 4, Name = "Demo4", Price = 11.00M }
            };

            return testProducts;
        }
    }
}
