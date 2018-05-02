using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZModels;
using PZRepositories;
using PZRepositoryInterface;
using PZServices;

namespace ApplicationServices
{
    public class PZServices
    {
        private readonly PZRepoContext _db;
        private readonly RestaurantService _restaurantService;
        private readonly ReviewService _reviewService;

        public PZServices()
        {
            _db = new PZRepoContext();
            _restaurantService = new RestaurantService(new RestaurantRepo(_db));
            _reviewService = new ReviewService(new ReviewRepo(_db));
            UpdateAverageRating();
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _restaurantService.AllRestaurants();
        }

        public List<Review> GetAllReviewsForRestaurant(string restaurant)
        {
            var r = _restaurantService.RestaurantByName(restaurant);
            return _reviewService.ReviewsByRestaurantId(r.rIndex);
        }

        public void UpdateAverageRating()
        {
            List<Restaurant> restList = GetAllRestaurants();
            foreach (Restaurant r in restList)
            {
                List<Review> restReviews = _reviewService.ReviewsByRestaurantId(r.rIndex);
                r.CalcAvgRating(restReviews);
            }
        }

        public List<Restaurant> GetTopThreeRestaurants()
        {
            return _restaurantService.GetTopThreeRestaurants();
        }

        public List<Restaurant> GetRestaurantsByOrder(string order)
        {
            return _restaurantService.GetRestaurantsByOrder(order);
        }

        public List<Restaurant> GetRestaurantBySearch(string search)
        {
            return _restaurantService.SearchRestaurants(search);
        }
    }
}
