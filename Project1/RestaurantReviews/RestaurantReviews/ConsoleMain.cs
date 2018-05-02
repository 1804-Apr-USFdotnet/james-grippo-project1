using System;
using ApplicationClient;
using System.IO;
using System.Runtime.Remoting.Services;

namespace RestaurantReviews
{
    class ConsoleMain
    {
        static void Main(string[] args)
        {
            var application = new PZClient();
            application.PrintMenu();
            var input = Console.ReadLine();

            while (input != "0")
            {
                switch (input)
                {
                    case "0":
                        break;
                    case "1":
                        application.PrintAllRestaurants();
                        break;
                    case "2":
                        application.PrintTopThree();
                        break;
                    case "3":
                        Console.WriteLine("Please Enter a Restaurant Name:\n");
                        var r = Console.ReadLine();
                        application.PrintReviewsForRestaurant(r);
                        break;
                    case "4":
                        Console.WriteLine("Please Enter a search parameter:\n");
                        var search = Console.ReadLine();
                        application.PrintRestaurantSearch(search);
                        break;
                    case "5":
                        Console.WriteLine("Please enter how you want to search:\nOptions are:\nName\nRating\nZipcode\nState\nAddress\nCity:\n");
                        var order = Console.ReadLine();
                        application.PrintByOrder(order);
                        break;
                    default:
                        Console.WriteLine("Invalid input please try again:\n");
                        break;

                }
                application.PrintMenu();
                input = Console.ReadLine();

                if (input == "0")
                {
                    break;
                }
                    
            }

            // application.PrintAllRestaurants();
            // application.PrintTopThree();
            // application.PrintByOrder(order);
            // application.PrintReviewsForRestaurant(2);
            // application.PrintRestaurantSearch("Mur");

        }
    }
}
