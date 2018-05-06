using System;
using System.Collections.Generic;
using System.Text;
using PZModels;

namespace PZRepositoryInterface
{
    public interface IReviewRepo
    {
        Review GetById(int id);
        IEnumerable<Review> GetAll();
        void Add(Review review);
        void UpdateReviews();
    }
}
