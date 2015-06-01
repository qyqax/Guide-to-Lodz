using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuideToLodz.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Trip> Trips { get; set; }
        public PagingInfo PagingInfo { get; set; }


    }
}