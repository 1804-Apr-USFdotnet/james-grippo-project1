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
            Review model = new Review()
            {
                RestaurantId = id
            };
            return View(model);
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create(Review review)
        {
            try
            {
                applicationServices.AddReview(review);
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
                applicationServices.RemoveReview(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
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
                applicationServices.UpdateReview(review);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
