using System;
using System.Collections.Generic;
using PZModels;

namespace PZRepositories
{
    public interface IRestaurantRepo
    {
        Restaurant GetById(int id);
        Restaurant GetByName(string restaurant);
        IEnumerable<Restaurant> GetAll();
        void Add(Restaurant restaurant);
        void Remove(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Update();
    }
}
