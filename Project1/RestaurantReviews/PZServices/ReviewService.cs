using PZModels;
using PZRepositories;
using System.Collections.Generic;
using System.Linq;

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
            IEnumerable<Review> query = _pzReviewRepo.GetAll().Where(x => x.Restaurant.RestaurantId == id);
            return query.ToList();
        }

        public void AddReview(Review review)
        {
            _pzReviewRepo.Add(review);
        }

        public void RemoveReview(Review review)
        {
            _pzReviewRepo.Remove(review);
        }

        public void UpdateReview(Review review)
        {
            _pzReviewRepo.Update(review);
        }
    }
}
