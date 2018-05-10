using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PZModels;
using PZRepositories;
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

            Restaurant r1 = new Restaurant()
            {
                RestaurantId = 1,
                Name = "TestRestaurant4",
                City = "city4",
                Zipcode = "10804",
                State = "NY",
                Street = " 4 a",
                AvgRating = 9.9
            };

            Restaurant r2 = new Restaurant()
            {
                RestaurantId = 2,
                Name = "TestRestaurant4",
                City = "city4",
                Zipcode = "10804",
                State = "NY",
                Street = " 4 a",
                AvgRating = 9.9
            };
            Restaurant r3 = new Restaurant()
            {
                RestaurantId = 3,
                Name = "TestRestaurant4",
                City = "city4",
                Zipcode = "10804",
                State = "NY",
                Street = " 4 a",
                AvgRating = 9.9
            };
            Restaurant r4 = new Restaurant()
            {
                RestaurantId = 4,
                Name = "TestRestaurant4",
                City = "city4",
                Zipcode = "10804",
                State = "NY",
                Street = " 4 a",
                AvgRating = 9.9
            };

            reviews = new List<Review>()
            {
                new Review
                {
                    ReviewId = 1,
                    Restaurant = r1,
                    Reviewer = "ZestReview",
                    Description = "Zcity",
                    Rating = 5
                },
                new Review
                {
                    ReviewId = 2,
                    Restaurant = r2,
                    Reviewer = "ZestReview",
                    Description = "Zcity",
                    Rating = 4
                },
                new Review
                {
                    ReviewId = 3,
                    Restaurant = r3,
                    Reviewer = "ZestReview",
                    Description = "Zcity",
                    Rating = 3
                },
                new Review
                {
                    ReviewId = 4,
                    Restaurant = r4,
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
            Restaurant r1 = new Restaurant()
            {
                RestaurantId = 1,
                Name = "TestRestaurant4",
                City = "city4",
                Zipcode = "10804",
                State = "NY",
                Street = " 4 a",
                AvgRating = 9.9
            };

            var service = new ReviewService(_moqRepo.Object);
            var r = new Review
            {
                ReviewId = 5,
                Restaurant = r1,
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

            CollectionAssert.AreEqual(reviews, _moqRepo.Object.GetAll().Where(x => x.Restaurant.RestaurantId == 1).ToList());
        }
    }
}
