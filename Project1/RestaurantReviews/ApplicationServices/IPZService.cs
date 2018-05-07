using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZModels;

namespace ApplicationServices
{
    interface IPZService
    {
        List<Restaurant> GetAllRestaurants();
        List<Review> GetAllReviews();
        Restaurant GetRestaurantById(int id);
        Restaurant GetRestaurantByName(string name);
        List<Review> GetAllReviewsForRestaurant(string restaurant);
        void UpdateAverageRating(Restaurant restaurant);
        List<Restaurant> GetTopThreeRestaurants();
        List<Restaurant> GetRestaurantsByOrder(string order);
        List<Restaurant> GetRestaurantBySearch(string search);
        void AddRestaurant(Restaurant restaurant);
        void RemoveRestaurant(int id);
        void UpdateRestaurant(Restaurant restaurant);
        void AddReview(Review review);
        void RemoveReview(int id);
        void RemoveAllReviews(ICollection<Review> reviews);
        void UpdateReview(Review review);
    }
}
