using System.Collections.Generic;
using System.Linq;
using PZModels;

namespace PZRepositories
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly PZRepoContext _pzRepoContext;

        public ReviewRepo(PZRepoContext context)
        {
            _pzRepoContext = context;
        }
        public Review GetById(int id)
        {
            return _pzRepoContext.Reviews.First(x => x.ReviewId == id);
        }

        public IEnumerable<Review> GetAll()
        {
            return _pzRepoContext.Reviews;
        }

        public void Add(Review review)
        {
            _pzRepoContext.Reviews.Add(review);
            _pzRepoContext.SaveChanges();
        }

        public void Remove(Review review)
        {
            _pzRepoContext.Reviews.Remove(review);
            _pzRepoContext.SaveChanges();
        }

        public void Update(Review review)
        {
            var r = _pzRepoContext.Reviews.Find(review.ReviewId);
            _pzRepoContext.Entry(r).CurrentValues.SetValues(review);
            _pzRepoContext.SaveChanges();
        }
    }
}
