using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZModels;
using PZRepositoryInterface;

namespace PZRepositories
{
    public class RestaurantRepo : IRestaurantRepo
    {
        private readonly IPZRepoContext _pzRepoContext;

        public RestaurantRepo(IPZRepoContext context)
        {
            _pzRepoContext = context;
        }

        public Restaurant GetById(int id)
        {
            return _pzRepoContext.Restaurants.First(x => x.rIndex == id);
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

        public void UpdateRestaurants()
        {
            _pzRepoContext.SaveChanges();
        }
    }
}
