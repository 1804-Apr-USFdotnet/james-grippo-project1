using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using PZModels;

namespace PZRepositoryInterface
{
    public interface IPZRepoContext
    {
        DbSet<Restaurant> Restaurants { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Franchise> Franchises { get; set; }

        int SaveChanges();
    }
}
