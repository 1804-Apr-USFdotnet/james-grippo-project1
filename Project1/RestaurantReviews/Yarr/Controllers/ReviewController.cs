using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Services.Protocols;
using ApplicationServices;
using PZModels;

namespace Yarr.Controllers
{
    public class ReviewController : Controller
    {
        private readonly PZServices applicationServices = new PZServices();
        public ActionResult Index(int id)
        {
            Restaurant r = applicationServices.GetRestaurantById(id);
            ViewBag.name = r.Name;
            ViewBag.iD = r.RestaurantId;
            return View(r.Reviews);
        }

        public ActionResult Details(int id)
        {
            return View(applicationServices.GetReviewByID(id));
        }

        public ActionResult Create(int id)
        {
            ViewBag.iD = id;
            ViewBag.name = applicationServices.GetRestaurantById(id).Name;
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create(Review review, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    review.Restaurant = applicationServices.GetRestaurantById(id);
                    applicationServices.AddReview(review);
                    // log that it worked
                    return RedirectToAction("Index", new RouteValueDictionary(
                        new {controller = "Review", action = "Index", Id = id}));
                }
                else
                    return HttpNotFound();
            }
            catch
            {
                Debug.WriteLine("Not Working.");
                // log some problem
                return View(review);
            }
        }
        //[Authorize("Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var restaurant = applicationServices.GetReviewByID(id).Restaurant;
                    applicationServices.RemoveReview(id);
                    applicationServices.UpdateAverageRating(restaurant);

                    return RedirectToAction("Index", new RouteValueDictionary(
                        new {controller = "Review", action = "Index", Id = restaurant.RestaurantId}));
                }
                else
                    return HttpNotFound();
            }
            catch
            {
                var index = applicationServices.GetReviewByID(id).Restaurant.RestaurantId;
                return RedirectToAction("Index", new RouteValueDictionary(
                    new { controller = "Review", action = "Index", Id = index }));
            }
        }

        public ActionResult Edit(int id)
        {
            return View(applicationServices.GetReviewByID(id));
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        public ActionResult Edit(Review review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    review.Restaurant = applicationServices.GetReviewByID(review.ReviewId).Restaurant;
                    applicationServices.UpdateReview(review);
                    return RedirectToAction("Index", new RouteValueDictionary(
                        new {controller = "Review", action = "Index", Id = review.Restaurant.RestaurantId}));
                }
                else
                    return HttpNotFound();
            }
            catch
            {
                return View(review);
            }
        }
    }
}
