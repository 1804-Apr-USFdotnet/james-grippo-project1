using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PZModels;
using PZRepositories;
using PZRepositoryInterface;

namespace DataTests
{
    [TestClass]
    public class ReviewRepoTest
    {
        private readonly Mock<IPZRepoContext> _moqContext;
        private readonly Mock<DbSet<Review>> _moqSet;

        private readonly Review r;
        private readonly List<Review> reviews;
        public ReviewRepoTest()
        {
            _moqContext = new Mock<IPZRepoContext>();
            _moqSet = new Mock<DbSet<Review>>();

            _moqContext.Setup(m => m.Reviews).Returns(_moqSet.Object);
        }

        [TestMethod]
        public void Add_PassedAReview_CallsReviewRepoAdd()
        {
            var service = new ReviewRepo(_moqContext.Object);
            service.Add(r);

            _moqSet.Verify(m => m.Add(It.IsAny<Review>()), Times.Once);
        }

        [TestMethod]
        public void Add_PassedAReview_CallsContextSaveChanges()
        {
            var service = new ReviewRepo(_moqContext.Object);
            service.Add(r);

            _moqContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetAll_AssertReturnType()
        {
            var service = new ReviewRepo(_moqContext.Object);
            var restById = service.GetAll();

            Assert.IsInstanceOfType(restById, typeof(IEnumerable<Review>));
        }
    }
}
