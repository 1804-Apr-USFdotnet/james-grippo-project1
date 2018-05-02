using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices;
using PZModels;

namespace ApplicationClient
{
    public class PZClient
    {
        private readonly PZServices _pzServices;

        public PZClient()
        {
            _pzServices = new PZServices();
        }

        public void PrintAllRestaurants()
        {
            List<Restaurant> restaurants = _pzServices.GetAllRestaurants();
            Print(restaurants);
        }

        public void PrintTopThree()
        {
            List<Restaurant> restaurants = _pzServices.GetTopThreeRestaurants();
            Print(restaurants);
        }

        public void PrintByOrder(string order)
        {
            List<Restaurant> restaurants = _pzServices.GetRestaurantsByOrder(order);
            if (restaurants.Count == 0)
            {
                Console.WriteLine("Invalid order argument.");
            }
            else
                Print(restaurants);
        }

        public void PrintReviewsForRestaurant(string restaurant)
        {
            List<Review> reviews = _pzServices.GetAllReviewsForRestaurant(restaurant);
            Print(reviews);
        }

        public void PrintRestaurantSearch(string search)
        {
            List<Restaurant> restaurants = _pzServices.GetRestaurantBySearch(search);
            if (restaurants.Count == 0)
            {
                Console.WriteLine("Search returned no values.");
            }
            else 
                Print(restaurants);
        }

        public void Print<T>(List<T> data)
        {
            foreach(var r in data)
            {
                Console.WriteLine(r.ToString());
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine("\nPlease Select your option:\n");
            Console.WriteLine("0: quit");
            Console.WriteLine("1: Get Restaurants.");
            Console.WriteLine("2: Get the top three rated Restaurants.");
            Console.WriteLine("3: Get the reviews for a Restaurant.");
            Console.WriteLine("4: Search for Restaurants.");
            Console.WriteLine("5: Sort the current Restaurants.");
        }
    }
}
