using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GuideToLodz.Models
{
    public class Trip
    {
        public int Id { get; set; }
      
        public string Name { get; set; }
        public string Localisation { get; set; }
        public int Price { get; set; }
     
        public bool IsForKids { get; set; }
       
        public bool IsInCentre { get; set; }

        public bool IsHistorical { get; set; }

        public bool IsRecreational { get; set; }

        public bool IsSport { get; set; }

        public bool IsGourmet { get; set; }

        public bool IsCultural { get; set; }
        public bool IsWinterish { get; set; }

        public bool IsSummerish { get; set; }  //if IsSeasonal 

        public int SuggestedTime { get; set; }



    }
}