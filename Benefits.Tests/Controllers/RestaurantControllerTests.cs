using Benefits.Controllers;
using Benefits.Models.DtoModels;
using Benefits.Models.Requests;
using Benefits.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Benefits.Tests.Controllers
{
    [TestClass]
    public class RestaurantControllerTests
    {
        private  IRestaurantService _restaurantService;
        private RestaurantController restaurantController;
        [TestInitialize]
        public void Startup()
        {
            var restaurantServiceMock = new Mock<IRestaurantService>();
            restaurantServiceMock.Setup(m => m.Create(It.IsAny<CreateRestaurantRequest>()));
            restaurantServiceMock.Setup(m => m.Delete(It.IsAny<int>()));
            restaurantServiceMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(new RestaurantDto());
            restaurantServiceMock.Setup(m => m.GetAll()).Returns(new List<RestaurantDto>());
            restaurantServiceMock.Setup(m => m.Update(It.IsAny<UpdateRestaurantRequest>()));

            _restaurantService = restaurantServiceMock.Object;
            restaurantController = new RestaurantController(_restaurantService);
        }
        [TestMethod]
        public void CreateTest()
        {
            var result=restaurantController.Create(new CreateRestaurantRequest { Name = "df", CityId = 1 });
            var contentResult = result as OkResult;
            Assert.IsNotNull(contentResult);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var result = restaurantController.Update(new UpdateRestaurantRequest { Name = "df", CityId = 1,Id=3 });
            var contentResult = result as OkResult;
            Assert.IsNotNull(contentResult);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var result = restaurantController.Delete(1);
            var contentResult = result as OkResult;
            Assert.IsNotNull(contentResult);
        }

        [TestMethod]
        public void GetTest()
        {
            var result = restaurantController.Get(1);
            var contentResult = result as OkNegotiatedContentResult<RestaurantDto>;
            Assert.IsNotNull(contentResult);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var result = restaurantController.GetAll();
            var contentResult = result as OkNegotiatedContentResult<List<RestaurantDto>>;
            Assert.IsNotNull(contentResult);
        }
    }
}
