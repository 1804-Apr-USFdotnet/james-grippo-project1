using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZModels;
using PZRepositoryInterface;

namespace PZRepositories
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly IPZRepoContext _pzRepoContext;

        public ReviewRepo(IPZRepoContext context)
        {
            _pzRepoContext = context;
        }
        public Review GetById(int id)
        {
            return _pzRepoContext.Reviews.First(x => x.revIndex == id);
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

        public void UpdateReviews()
        {
            _pzRepoContext.SaveChanges();
        }
    }
}
