using System;
using System.Collections.Generic;
using System.Text;
using PZModels;

namespace PZRepositories
{
    public interface IReviewRepo
    {
        Review GetById(int id);
        IEnumerable<Review> GetAll();
        void Add(Review review);
        void Remove(Review review);
        void Update(Review review);
    }
}
