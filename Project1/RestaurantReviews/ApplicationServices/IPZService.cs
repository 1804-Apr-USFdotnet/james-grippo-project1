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
        Restaurant GetRestaurantById(int id);
        Restaurant GetRestaurantByName(string name);
        List<Review> GetAllReviewsForRestaurant(string restaurant);
        void UpdateAverageRating();
        List<Restaurant> GetTopThreeRestaurants();
        List<Restaurant> GetRestaurantsByOrder(string order);
        List<Restaurant> GetRestaurantBySearch(string search);
        void AddRestaurant(Restaurant restaurant);
    }
}
