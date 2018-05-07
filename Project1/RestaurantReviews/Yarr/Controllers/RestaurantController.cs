using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationServices;
using PZModels;

namespace Yarr.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly PZServices applicationServices = new PZServices();

        public ActionResult Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
                return View(applicationServices.GetRestaurantBySearch(search));

            if (TempData["restaurants"] == null)
                return View(applicationServices.GetAllRestaurants());

            return View(TempData["restaurants"]);


        }

        public ActionResult TopThree()
        {
            TempData["restaurants"] = applicationServices.GetTopThreeRestaurants();
            return RedirectToAction("Index");
        }

        public ActionResult SearchBy(string search)
        {
            var restaurants = applicationServices.GetRestaurantBySearch(search);
            TempData["restaurants"] = restaurants;
            return RedirectToAction("Index");
        }

        public ActionResult OrderBy(string order)
        {
            var restaurants = applicationServices.GetRestaurantsByOrder(order);
            TempData["restaurants"] = restaurants;
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(applicationServices.GetRestaurantById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            try
            {
                applicationServices.AddRestaurant(restaurant);
                // log that it worked
                return RedirectToAction("Index");
            }
            catch
            {
                Debug.WriteLine("Not Working.");
                // log some problem
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                applicationServices.RemoveRestaurant(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            return View(applicationServices.GetRestaurantById(id));
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            try
            {
                restaurant.Reviews = applicationServices.GetRestaurantById(restaurant.RestaurantId).Reviews;
                applicationServices.UpdateAverageRating(restaurant);
                applicationServices.UpdateRestaurant(restaurant);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(restaurant);
            }
        }
    }
}
