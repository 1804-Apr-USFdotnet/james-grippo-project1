using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationServices;
using PZModels;

namespace PZWebApplication.Controllers
{
    public class RestaurantController : Controller
    {
        private PZServices applicationServices = new PZServices();
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
                return View("Index");
            }
        }
    }
}