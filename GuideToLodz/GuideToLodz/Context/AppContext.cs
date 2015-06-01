using GuideToLodz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GuideToLodz.Context
{
    public class AppContext :DbContext
    {
        public AppContext() : base("TripDB") { }
        public DbSet<Trip> Trips{get;set;}
    }
}