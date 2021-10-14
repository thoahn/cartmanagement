using AutoMapper;
using CartManagement.API;
using CartManagement.API.Controllers;
using CartManagement.API.DTOs;
using CartManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CartManagement.UnitTest
{
    [TestClass]
    public class Product
    {
        readonly IServiceProvider _services = Program.CreateHostBuilder(new string[] { }).Build().Services;


        [TestMethod]
        public void GetAll()
        {
            ProductsController controller = GenerateController();

            var result = controller.GetAll().Result as OkObjectResult;
            var value = result.Value as IEnumerable<ProductDto>;

            Assert.IsTrue(value.Count() == 4);
        }


        [TestMethod]
        public void GetById()
        {
            ProductsController controller = GenerateController();

            var result = controller.GetById(1).Result as OkObjectResult;
            var value = result.Value as ProductDto;

            Assert.IsTrue(value.Id == 1);
        }

        [TestMethod]
        public void GetProductsByCategoryId()
        {
            ProductsController controller = GenerateController();

            var result = controller.GetProductsByCategoryIdAsync(1).Result as OkObjectResult;
            var value = result.Value as IEnumerable<ProductDto>;

            Assert.IsTrue(value.Count() == 2);
            Assert.IsTrue(value.All(x => x.CategoryId == 1));
        }

        ProductsController GenerateController()
        {
            return new ProductsController((IProductService)_services.GetService(typeof(IProductService)), (IMapper)_services.GetService(typeof(IMapper)));
        }
    }
}
