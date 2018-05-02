using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PZModels;
using PZRepositoryInterface;
using PZServices;

namespace ServicesUnitTests
{
    [TestClass]
    public class RestaurantServiceTest
    {
        private readonly Mock<IRestaurantRepo>_moqRepo;
        private readonly List<Restaurant> restaurants;

        public RestaurantServiceTest()
        {
            _moqRepo = new Mock<IRestaurantRepo>();
            _moqRepo.Setup(m => m.Add(It.IsAny<Restaurant>()));

            restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    rIndex = 1,
                    FranchiseID = 1,
                    Name = "ZestRestaurant",
                    City = "Zcity",
                    Zipcode = "90801",
                    State = "ZNY",
                    Address = "Z 1 a",
                    AvgRating = 6.9
                },
                new Restaurant
                {
                    rIndex = 2,
                    FranchiseID = 2,
                    Name = "TestRestaurant2",
                    City = "city2",
                    Zipcode = "10802",
                    State = "NY",
                    Address = " 2 a",
                    AvgRating = 7.9
                },
                new Restaurant
                {
                    rIndex = 3,
                    FranchiseID = 3,
                    Name = "TestRestaurant3",
                    City = "city3",
                    Zipcode = "10803",
                    State = "NY",
                    Address = " 3 a",
                    AvgRating = 8.9
                },
                new Restaurant
                {
                    rIndex = 4,
                    FranchiseID = 4,
                    Name = "TestRestaurant4",
                    City = "city4",
                    Zipcode = "10804",
                    State = "NY",
                    Address = " 4 a",
                    AvgRating = 9.9
                }
            };
            _moqRepo.Setup(r=>r.GetAll()).Returns(restaurants);
        }

        [TestMethod]
        public void GetTopThree_CallsGetAllOnce()
        {
            var service = new RestaurantService(_moqRepo.Object);
            service.GetTopThreeRestaurants();

            _moqRepo.Verify(m=>m.GetAll(),Times.Once);
        }

        [TestMethod]
        public void GetTopThree_AssertIsEqual()
        {
            var service = new RestaurantService(_moqRepo.Object);
            var rList = service.GetTopThreeRestaurants();

            CollectionAssert.AreEqual(rList, _moqRepo.Object.GetAll().OrderByDescending(x => x.AvgRating).Take(3).ToList());
        }

        [TestMethod]
        public void AllRestuarants_CallsGetAllOnce()
        {
            var service = new RestaurantService(_moqRepo.Object);
            service.AllRestaurants();

            _moqRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void RestuarantById_PassAInt_CallsGetByIdOnce()
        {
            var service = new RestaurantService(_moqRepo.Object);
            service.RestaurantById(It.IsAny<int>());

            _moqRepo.Verify(m => m.GetById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void RestuarantByName_PassAString_CallsGetByNameOnce()
        {
            var service = new RestaurantService(_moqRepo.Object);
            service.RestaurantByName(It.IsAny<string>());

            _moqRepo.Verify(m => m.GetByName(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetRestaurantsByOrder_PassAString_CallsGetAll()
        {
            var service = new RestaurantService(_moqRepo.Object);
            service.GetRestaurantsByOrder("Name");

            _moqRepo.Verify(m => m.GetAll(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void GetRestaurantsByOrder_PassedName_AssertName()
        {
            var service = new RestaurantService(_moqRepo.Object);
            var rList = service.GetRestaurantsByOrder("Name");

            CollectionAssert.AreEqual(rList, _moqRepo.Object.GetAll().OrderBy(x => x.Name).ToList());
        }

        [TestMethod]
        public void GetRestaurantsByOrder_PassedCity_AssertCity()
        {
            var service = new RestaurantService(_moqRepo.Object);
            var rList = service.GetRestaurantsByOrder("City");

            CollectionAssert.AreEqual(rList, _moqRepo.Object.GetAll().OrderBy(x => x.City).ToList());
        }

        [TestMethod]
        public void GetRestaurantsByOrder_PassedZipcode_AssertZipcode()
        {
            var service = new RestaurantService(_moqRepo.Object);
            var rList = service.GetRestaurantsByOrder("ZipCode");

            CollectionAssert.AreEqual(rList, _moqRepo.Object.GetAll().OrderBy(x => x.Zipcode).ToList());
        }

        [TestMethod]
        public void GetRestaurantsByOrder_PassedAddress_AssertAddress()
        {
            var service = new RestaurantService(_moqRepo.Object);
            var rList = service.GetRestaurantsByOrder("AdDress");

            CollectionAssert.AreEqual(rList, _moqRepo.Object.GetAll().OrderBy(x => x.Address).ToList());
        }

        [TestMethod]
        public void GetRestaurantsByOrder_PassedState_AssertState()
        {
            var service = new RestaurantService(_moqRepo.Object);
            var rList = service.GetRestaurantsByOrder("State");

            CollectionAssert.AreEqual(rList, _moqRepo.Object.GetAll().OrderBy(x => x.State).ToList());
        }

        [TestMethod]
        public void GetRestaurantsByOrder_PassedRating_AssertRating()
        {
            var service = new RestaurantService(_moqRepo.Object);
            var rList = service.GetRestaurantsByOrder("Rating");

            CollectionAssert.AreEqual(rList, _moqRepo.Object.GetAll().OrderByDescending(x => x.AvgRating).ToList());
        }

        [TestMethod]
        public void GetRestaurantsByOrder_PassedInvalid_AssertDefault()
        {
            var service = new RestaurantService(_moqRepo.Object);
            var rList = service.GetRestaurantsByOrder("lmao");

            CollectionAssert.AreEqual(rList, new List<Restaurant>());
        }

        [TestMethod]
        public void GetRestaurantsBySearch_PassedAString_AssertCollectionsEqual()
        {
            var service = new RestaurantService(_moqRepo.Object);
            var rList = service.SearchRestaurants("Z");

            CollectionAssert.AreEqual(rList, _moqRepo.Object.GetAll().Where(x => Regex.IsMatch(x.Name, "Z")).ToList());
        }

        [TestMethod]
        public void Add_PassedARestaurant_CallsAdd()
        {
            var service = new RestaurantService(_moqRepo.Object);
            var r = new Restaurant
            {
                rIndex = 5,
                FranchiseID = 5,
                Name = "TestRestaurant5",
                City = "city5",
                Zipcode = "10804",
                State = "NY",
                Address = " 5 a",
                AvgRating = 9.9
            };

            service.AddRestaurant(r);
            _moqRepo.Verify(m => m.Add(It.IsAny<Restaurant>()), Times.Once);
        }
    }
}
