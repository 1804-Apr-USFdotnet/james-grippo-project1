﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using PZModels;

namespace PZRepositories
{
    class DBInit : CreateDatabaseIfNotExists<PZRepoContext>
    {
        protected override void Seed(PZRepoContext context)
        {
            //string FranchisePath = @"C:\Users\jgrip\Documents\GitHub\GrippoJ_ProjectZero_RestaurantReviews\ProjectZero\RestaurantReviews\ConsoleApp1\franchise.xml";
            //string RestaurantPath = @"C:\Users\jgrip\Documents\GitHub\GrippoJ_ProjectZero_RestaurantReviews\ProjectZero\RestaurantReviews\ConsoleApp1\Restaurant.xml";
            //string ReviewPath = @"C:\Users\jgrip\Documents\GitHub\GrippoJ_ProjectZero_RestaurantReviews\ProjectZero\RestaurantReviews\ConsoleApp1\Review.xml";

            //FranchiseSerialization fs = new FranchiseSerialization(FranchisePath);
            //RestaurantSerialization rts = new RestaurantSerialization(RestaurantPath);
            //ReviewSerialization rvs = new ReviewSerialization(ReviewPath);

            //List<Franchise> franchises = fs.GetFranchisesXML();
            //List<Restaurant> restaurants = rts.GetRestaurantsXML();
            //List<Review> reviews = rvs.GetReviewsXML();

            //foreach (Franchise f in franchises)
            //    context.Franchises.Add(f);
            //foreach (Restaurant r in restaurants)
            //    context.Restaurants.Add(r);
            //foreach (Review r in reviews)
            //    context.Reviews.Add(r);

            Review review = new Review()
            {
                Rating = 5,
                Description = "Schwiftyyyyy!",
                Reviewer = "Lil' Bobby",
            };

            Restaurant restaurant = new Restaurant
            {
                City = "City1",
                Name = "Bobby Big Burgers",
                State = "NY",
                Zipcode = "10801",
                Street = "1 Bobby place",
                Reviews = new List<Review>
                {
                    review
                }
            };
            review.Restaurant = restaurant;
            context.Restaurants.Add(restaurant);
            context.Reviews.Add(review);

            base.Seed(context);
            context.SaveChanges();
        }
    }
}
