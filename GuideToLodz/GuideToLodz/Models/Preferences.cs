using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GuideToLodz.Models
{
    public class Preferences
    {
        [DisplayName("What is your budget ?")]
        public int? Price { get; set; }
        [DisplayName("Are you planning to go out with children ?")]
        public bool? IsForKids { get; set; }
        [DisplayName("Do you prefer stay close to the center ?")]
        public bool? IsInCentre { get; set; }
        [DisplayName("Do you wish to visit some landmarked builidng ?")]
        public bool? IsHistorical { get; set; }
        [DisplayName("May be some recreation ?")]
        public bool? IsRecreational { get; set; }
        [DisplayName("Sport ?")]
        public bool? IsSport { get; set; }
        [DisplayName("Do you want to eat something ?")]
        public bool? IsGourmet { get; set; }
        [DisplayName("Do you wish some cultural experiences?")]
        public bool? IsCultural { get; set; }

        public bool? IsWinterish { get; set; }

        public bool? IsSummerish { get; set; }  //if IsSeasonal 
        [DisplayName("How much time do you want to spent ?")]
        public int? SuggestedTime { get; set; }

        public Preferences() {
            this.IsWinterish = null;
            this.IsSummerish = null;
            this.IsHistorical = null;
            this.IsGourmet = null;
            this.IsForKids = null;
            this.IsCultural = null;
            this.IsInCentre = null;
            this.IsRecreational = null;
            this.IsSport = null;
            this.Price = null;
            this.SuggestedTime = null;
           
        }
    }
}