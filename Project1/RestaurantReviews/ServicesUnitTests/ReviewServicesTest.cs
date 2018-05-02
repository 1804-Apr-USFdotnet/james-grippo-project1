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
    public class ReviewServiceTest
    {
        private readonly Mock<IReviewRepo> _moqRepo;
        private readonly List<Review> reviews;

        public ReviewServiceTest()
        {
            _moqRepo = new Mock<IReviewRepo>();
            _moqRepo.Setup(m => m.Add(It.IsAny<Review>()));

            reviews = new List<Review>()
            {
                new Review
                {
                    revIndex = 1,
                    RestaurantID = 1,
                    Reviewer = "ZestReview",
                    Description = "Zcity",
                    Rating = 5
                },
                new Review
                {
                    revIndex = 2,
                    RestaurantID = 2,
                    Reviewer = "ZestReview",
                    Description = "Zcity",
                    Rating = 4
                },
                new Review
                {
                    revIndex = 3,
                    RestaurantID = 3,
                    Reviewer = "ZestReview",
                    Description = "Zcity",
                    Rating = 3
                },
                new Review
                {
                    revIndex = 4,
                    RestaurantID = 4,
                    Reviewer = "ZestReview",
                    Description = "Zcity",
                    Rating = 9
                }
            };
            _moqRepo.Setup(r => r.GetAll()).Returns(reviews);
        }

        [TestMethod]
        public void AllReviews_CallsGetAllOnce()
        {
            var service = new ReviewService(_moqRepo.Object);
            service.AllReviews();

            _moqRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void ReviewById_PassAInt_CallsGetByIdOnce()
        {
            var service = new ReviewService(_moqRepo.Object);
            service.ReviewById(It.IsAny<int>());

            _moqRepo.Verify(m => m.GetById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void Add_PassedAReview_CallsAdd()
        {
            var service = new ReviewService(_moqRepo.Object);
            var r = new Review
            {
                revIndex = 5,
                RestaurantID = 1,
                Reviewer = "ZestReview",
                Description = "Zcity",
                Rating = 5
            };

            service.AddReview(r);
            _moqRepo.Verify(m => m.Add(It.IsAny<Review>()), Times.Once);
        }

        [TestMethod]
        public void ReviewsByRestaurant_PassedAnId_AssertCollection()
        {
            var service = new ReviewService(_moqRepo.Object);
            var reviews = service.ReviewsByRestaurantId(1);

            CollectionAssert.AreEqual(reviews, _moqRepo.Object.GetAll().Where(x => x.RestaurantID == 1).ToList());
        }
    }
}
