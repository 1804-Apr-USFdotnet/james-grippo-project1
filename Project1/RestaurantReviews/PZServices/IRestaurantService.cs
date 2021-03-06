﻿using System;
using System.Collections.Generic;
using PZModels;

namespace PZServices
{
    public interface IRestaurantService
    {
        List<Restaurant> AllRestaurants();
        Restaurant RestaurantById(int id);
        Restaurant RestaurantByName(string restaurant);
        List<Restaurant> GetTopThreeRestaurants();
        List<Restaurant> GetRestaurantsByOrder(string order);
        List<Restaurant> SearchRestaurants(string search);
        void AddRestaurant(Restaurant restaurant);
        void RemoveRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        void UpdateContext();
    }
}
