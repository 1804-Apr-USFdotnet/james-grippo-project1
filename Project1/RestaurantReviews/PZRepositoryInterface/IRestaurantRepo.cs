using System;
using System.Collections.Generic;
using PZModels;

namespace PZRepositoryInterface
{
    public interface IRestaurantRepo
    {
        Restaurant GetById(int id);
        Restaurant GetByName(string restaurant);
        IEnumerable<Restaurant> GetAll();
        void Add(Restaurant restaurant);
        void UpdateRestaurants();
    }
}
