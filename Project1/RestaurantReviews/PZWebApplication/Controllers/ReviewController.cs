﻿using System;
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
                review.Restaurant = applicationServices.GetRestaurantById(id);
                applicationServices.AddReview(review);
                // log that it worked
                return RedirectToAction("Index");
            }
            catch
            {
                Debug.WriteLine("Not Working.");
                // log some problem
                return View(review);
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
            //try
            //{
            review.Restaurant = applicationServices.GetReviewByID(review.ReviewId).Restaurant;
            applicationServices.UpdateReview(review);
            return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View(review);
            //}
        }
    }
}