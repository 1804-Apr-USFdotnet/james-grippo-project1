using System;
using System.Collections.Generic;
using System.Data.Entity;
using IPZServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PZModels;
using PZRepositories;
using PZRepositoryInterface;
using PZServices;

namespace DataTests
{
    [TestClass]
    public class RestaurantRepoTest
    {
        private readonly Mock<IPZRepoContext> _moqContext;
        private readonly Mock<DbSet<Restaurant>> _moqSet;

        private readonly Restaurant r;
        private readonly List<Restaurant> restaurants;

        public RestaurantRepoTest()
        {
            _moqContext = new Mock<IPZRepoContext>();
            _moqSet = new Mock<DbSet<Restaurant>>();

            _moqContext.Setup(m => m.Restaurants).Returns(_moqSet.Object);
        }

        [TestMethod]
        public void Add_PassedARestaurant_CallsRestaurantRepoAdd()
        {
            var service = new RestaurantRepo(_moqContext.Object);
            service.Add(r);

            _moqSet.Verify(m=>m.Add(It.IsAny<Restaurant>()), Times.Once);
        }

        [TestMethod]
        public void Add_PassedARestaurant_CallsContextSaveChanges()
        {
            var service = new RestaurantRepo(_moqContext.Object);
            service.Add(r);

            _moqContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetAll_AssertReturnType()
        {
            var service = new RestaurantRepo(_moqContext.Object);
            var restById = service.GetAll();

            Assert.IsInstanceOfType(restById, typeof(IEnumerable<Restaurant>));
        }
    }
}
