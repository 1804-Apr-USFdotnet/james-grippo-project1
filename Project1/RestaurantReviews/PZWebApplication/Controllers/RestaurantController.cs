using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationServices;
using PZModels;

namespace PZWebApplication.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly PZServices applicationServices = new PZServices();
        public ActionResult Index()
        {
            return View(applicationServices.GetAllRestaurants());
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
                return RedirectToAction("Index");
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
                return View("Index");
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
                applicationServices.UpdateRestaurant(restaurant);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}