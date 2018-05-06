using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPZServices;
using PZModels;
using PZRepositoryInterface;

namespace PZServices
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepo _pzReviewRepo;

        public ReviewService(IReviewRepo reviewRepo)
        {
            _pzReviewRepo = reviewRepo;
        }
        public List<Review> AllReviews()
        {
            return _pzReviewRepo.GetAll().ToList();
        }

        public Review ReviewById(int id)
        {
            return _pzReviewRepo.GetById(id);
        }

        public List<Review> ReviewsByRestaurantId(int id)
        {
            IEnumerable<Review> query = _pzReviewRepo.GetAll().Where(x => x.RestaurantID == id);
            return query.ToList();
        }

        public void AddReview(Review review)
        {
            _pzReviewRepo.Add(review);
        }
    }
}
