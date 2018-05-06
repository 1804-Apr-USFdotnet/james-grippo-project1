using System;
using System.Collections.Generic;
using System.Text;
using PZModels;

namespace IPZServices
{
    public interface IReviewService
    {
        List<Review> AllReviews();
        Review ReviewById(int id);
        List<Review> ReviewsByRestaurantId(int id);
        void AddReview(Review review);
    }
}
