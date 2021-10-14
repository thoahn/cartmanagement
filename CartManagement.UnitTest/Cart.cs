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
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.UnitTest
{
    [TestClass]
    public class Cart
    {
        readonly IServiceProvider _services = Program.CreateHostBuilder(new string[] { }).Build().Services;

        [TestMethod]
        public void Save()
        {
            CartController controller = GenerateController();

            var result = controller.Save(new CartDto { PersonId = 1, ProductId = 1 }).Result as CreatedResult;
            var value = result.Value as CartDto;

            Assert.IsTrue(value.PersonId == 1);
            Assert.IsTrue(value.ProductId == 1);
            Assert.IsTrue(value.Quantity == 1);
        }

        [TestMethod]
        public void GetAll()
        {
            CartController controller = GenerateController();

            var result = controller.GetAll().Result as OkObjectResult;
            var value = result.Value as IEnumerable<CartDto>;

            Assert.IsTrue(value.Count() > 0);
        }


        [TestMethod]
        public void GetById()
        {
            CartController controller = GenerateController();

            var result = controller.GetById(1).Result as OkObjectResult;
            var value = result.Value as CartDto;

            Assert.IsTrue(value.Id == 1);
        }

        [TestMethod]
        public void GetProductsByPersonIdAsync()
        {
            CartController controller = GenerateController();

            var result = controller.GetProductsByPersonIdAsync(1).Result as OkObjectResult;
            var value = result.Value as IEnumerable<CartDto>;

            Assert.IsTrue(value.Count() > 0);
            Assert.IsTrue(value.All(x => x.PersonId == 1));
        }

        CartController GenerateController()
        {
            return new CartController((ICartService)_services.GetService(typeof(ICartService)), (IMapper)_services.GetService(typeof(IMapper)));
        }
    }
}
