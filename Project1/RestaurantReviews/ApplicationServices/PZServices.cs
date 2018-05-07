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
    public class PZServices : IPZService
    {
        private readonly PZRepoContext _db;
        private readonly RestaurantService _restaurantService;
        private readonly ReviewService _reviewService;

        public PZServices()
        {
            _db = new PZRepoContext();
            _restaurantService = new RestaurantService(new RestaurantRepo(_db));
            _reviewService = new ReviewService(new ReviewRepo(_db));
            //UpdateAverageRating();
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _restaurantService.AllRestaurants();
        }

        public List<Review> GetAllReviews()
        {
            return _reviewService.AllReviews();
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _restaurantService.RestaurantById(id);
        }

        public Review GetReviewByID(int id)
        {
            return _reviewService.ReviewById(id);
        }

        public Restaurant GetRestaurantByName(string name)
        {
            return _restaurantService.RestaurantByName(name);
        }

        public List<Review> GetAllReviewsForRestaurant(string restaurant)
        {
            var r = _restaurantService.RestaurantByName(restaurant);
            return _reviewService.ReviewsByRestaurantId(r.RestaurantId);
        }

        public void UpdateAverageRating(Restaurant restaurant)
        {
            restaurant.CalcAvgRating();
            _restaurantService.UpdateContext();
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

        public void AddRestaurant(Restaurant restaurant)
        {
            _restaurantService.AddRestaurant(restaurant);
        }

        public void RemoveRestaurant(int id)
        {
            Restaurant r = GetRestaurantById(id);
            //RemoveAllReviews(r.Reviews);
            _restaurantService.RemoveRestaurant(r);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _restaurantService.UpdateRestaurant(restaurant);
        }

        public void AddReview(Review review)
        {
            Restaurant restaurant = GetRestaurantById(review.Restaurant.RestaurantId);
            review.Restaurant = restaurant;
            _reviewService.AddReview(review);

            restaurant.Reviews.Add(review);
            restaurant.CalcAvgRating();
            _restaurantService.UpdateContext();
        }

        public void RemoveReview(int id)
        {
            Review r = GetReviewByID(id);
            _reviewService.RemoveReview(r);
        }

        public void RemoveAllReviews(ICollection<Review> reviews)
        {
            foreach( Review review in reviews)
                RemoveReview(review.ReviewId);
        }

        public void UpdateReview(Review review)
        {
            _reviewService.UpdateReview(review);
            review.Restaurant.CalcAvgRating();
            _restaurantService.UpdateContext();
        }
    }
}
