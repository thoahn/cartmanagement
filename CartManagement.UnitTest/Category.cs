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
    public class Category
    {
        readonly IServiceProvider _services = Program.CreateHostBuilder(new string[] { }).Build().Services;
        

        [TestMethod]
        public void GetAll() 
        {
            CategoriesController controller = GenerateController();

            var result = controller.GetAll().Result as OkObjectResult;
            var value = result.Value as IEnumerable<CategoryDto>;

            Assert.IsTrue(value.Count() == 2);
        }


        [TestMethod]
        public void GetById()
        {
            CategoriesController controller = GenerateController();

            var result = controller.GetById(1).Result as OkObjectResult;
            var value = result.Value as CategoryDto;

            Assert.IsTrue(value.Id == 1);

            result = controller.GetById(2).Result as OkObjectResult;
            value = result.Value as CategoryDto;

            Assert.IsTrue(value.Id == 2);
        }

        CategoriesController GenerateController() 
        {
            return new CategoriesController((ICategoryService)_services.GetService(typeof(ICategoryService)), (IMapper)_services.GetService(typeof(IMapper)));
        }
    }
}
