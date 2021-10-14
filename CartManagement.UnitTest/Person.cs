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
    public class Person
    {
        readonly IServiceProvider _services = Program.CreateHostBuilder(new string[] { }).Build().Services;


        [TestMethod]
        public void GetAll()
        {
            PersonsController controller = GenerateController();

            var result = controller.GetAll().Result as OkObjectResult;
            var value = result.Value as IEnumerable<PersonDto>;

            Assert.IsTrue(value.Count() == 2);
        }


        [TestMethod]
        public void GetById()
        {
            PersonsController controller = GenerateController();

            var result = controller.GetById(1).Result as OkObjectResult;
            var value = result.Value as PersonDto;

            Assert.IsTrue(value.ID == 1);

            result = controller.GetById(2).Result as OkObjectResult;
            value = result.Value as PersonDto;

            Assert.IsTrue(value.ID == 2);
        }

        PersonsController GenerateController()
        {
            return new PersonsController((IService<Core.Models.Person>)_services.GetService(typeof(IService<Core.Models.Person>)), (IMapper)_services.GetService(typeof(IMapper)));
        }
    }
}
