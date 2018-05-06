using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZModels;
using PZRepositoryInterface;
using System.Data.Entity;

namespace PZRepositories
{
    public class RestaurantRepo : IRestaurantRepo
    {
        private readonly PZRepoContext _pzRepoContext;

        public RestaurantRepo(PZRepoContext context)
        {
            _pzRepoContext = context;
        }

        public Restaurant GetById(int id)
        {
            return _pzRepoContext.Restaurants.First(x => x.RestaurantId == id);
        }

        public Restaurant GetByName(string restaurant)
        {
            return _pzRepoContext.Restaurants.First(x => x.Name == restaurant);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _pzRepoContext.Restaurants;
        }

        public void Add(Restaurant restaurant)
        {
            _pzRepoContext.Restaurants.Add(restaurant);
            _pzRepoContext.SaveChanges();
        }

        public void Remove(Restaurant restaurant)
        {
            _pzRepoContext.Restaurants.Remove(restaurant);
            _pzRepoContext.SaveChanges();
        }

        public void Update(Restaurant restaurant)
        {
            var r = _pzRepoContext.Restaurants.Find(restaurant.RestaurantId);
            _pzRepoContext.Entry(r).CurrentValues.SetValues(restaurant); 
            _pzRepoContext.SaveChanges();
        }
    }
}
