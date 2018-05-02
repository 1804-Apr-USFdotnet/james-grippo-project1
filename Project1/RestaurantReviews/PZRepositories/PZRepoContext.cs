using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PZModels;
using PZRepositoryInterface;

namespace PZRepositories
{
    public class PZRepoContext : DbContext, IPZRepoContext
    {
        public PZRepoContext() : base("name=PZRestaurantConnectionString")
        {
            Database.SetInitializer<PZRepoContext>(new DBInit());
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
    }
}
