﻿using System.Collections.Generic;
using System.Linq;
using PZModels;
using System.Text.RegularExpressions;
using PZRepositories;

namespace PZServices
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepo _restaurantRepo;

        public RestaurantService(IRestaurantRepo restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        public List<Restaurant> AllRestaurants()
        {
            return _restaurantRepo.GetAll().ToList();
        }

        public Restaurant RestaurantById(int id)
        {
            return _restaurantRepo.GetById(id);
        }

        public Restaurant RestaurantByName(string restaurant)
        {
            return _restaurantRepo.GetByName(restaurant);
        }

        public List<Restaurant> GetTopThreeRestaurants()
        {
            IEnumerable<Restaurant> query = _restaurantRepo.GetAll();
            return query.OrderByDescending(x => x.AvgRating).Take(3).ToList();
        }

        public List<Restaurant> GetRestaurantsByOrder(string order)
        {
            IEnumerable<Restaurant> query = _restaurantRepo.GetAll();
            switch (order.ToLower())
            {
                case "name":
                    return query.OrderBy(x => x.Name).ToList();
                case "rating":
                    return query.OrderByDescending(x => x.AvgRating).ToList();
                case "zipcode":
                    return query.OrderBy(x => x.Zipcode).ToList();
                case "city":
                    return query.OrderBy(x => x.City).ToList();
                case "state":
                    return query.OrderBy(x => x.State).ToList();
                case "address":
                    return query.OrderBy(x => x.Street).ToList();
                default:
                    return new List<Restaurant>();
            }
        }

        public List<Restaurant> SearchRestaurants(string search)
        {
            IEnumerable<Restaurant> query = _restaurantRepo.GetAll().Where(x => Regex.IsMatch(x.Name,search));
            return query.ToList();
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            _restaurantRepo.Add(restaurant);
        }

        public void RemoveRestaurant(Restaurant restaurant)
        {
            _restaurantRepo.Remove(restaurant);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _restaurantRepo.Update(restaurant);
        }

        public void UpdateContext()
        {
            _restaurantRepo.Update();
        }
    }
}
