using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GuideToLodz.Context;
using GuideToLodz.Models;
using Newtonsoft.Json;

namespace GuideToLodz.Controllers
{
    public class TripsController : Controller
    {
        private AppContext db = new AppContext();

        public int PageSize = 8;

      
       
        // GET: Trips
        public ActionResult Index(int page = 1)
        {
            var passing_object = new
            {
                trips = db.Trips.ToList().OrderBy(p => p.Name).Skip((page - 1) * PageSize).Take(PageSize),
                searchtrips = db.Trips.ToList()
            };

            

            ViewBag.JSONData = JsonConvert.SerializeObject(passing_object, Formatting.None, new
              JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
              );

            ProductListViewModel viewModel = new ProductListViewModel
            {
                Trips = db.Trips.ToList().OrderBy(p => p.Name).Skip((page - 1) * PageSize).Take(PageSize) ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = db.Trips.Count()
                }
            };

            return View(viewModel);
        }

        // GET: Trips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // GET: Trips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Localisation,Price,IsForKids,IsInCentre,IsSport,IsHistorical,IsRecreational,IsGourmet,IsCultural,IsWinterish,IsSummerish,SuggestedTime")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(trip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trip);
        }

        // GET: Trips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Localisation,Price,IsForKids,IsInCentre,IsSport,IsHistorical,IsRecreational,IsGourmet,IsCultural,IsWinterish,IsSummerish,SuggestedTime")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trip);
        }

        // GET: Trips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trip trip = db.Trips.Find(id);
            db.Trips.Remove(trip);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ChoicePanel()
        {
            Preferences p = new Preferences();

            return View(p);
        }

        [HttpPost]
        public ActionResult ChoicePanel(Preferences p)
        {
           
                return RedirectToAction("ListOfTrips",p);
           
        }

        public ActionResult ListOfTrips(Preferences p)
        {
            return View(db.Trips.ToList().
                Where(trip=>trip.IsInCentre==p.IsInCentre || p.IsInCentre==null).
                Where(trip => trip.IsCultural == p.IsCultural || p.IsCultural==null).
                Where(trip=>trip.IsForKids==p.IsForKids || p.IsForKids==null).
                Where(trip=>trip.IsGourmet==p.IsGourmet || p.IsGourmet==null).
                Where(trip=>trip.IsHistorical==p.IsHistorical || p.IsHistorical==null).
                Where(trip=>trip.IsRecreational==p.IsRecreational || p.IsRecreational==null).
                Where(trip=>trip.IsSport==p.IsSport || p.IsSport==null).
                Where(trip=>trip.IsSummerish==p.IsSummerish || p.IsSummerish==null).
                Where(trip => trip.IsWinterish == p.IsWinterish || p.IsWinterish == null).
                Where(trip=>trip.SuggestedTime<=p.SuggestedTime || p.SuggestedTime==null).
                Where(trip=>trip.Price<=p.Price || p.Price==null)
                
                );
        }


       /* public ActionResult DetailsClient(int id,Preferences p)
        {
            Trip trip = db.Trips.Find(id);
            ViewBag.preferences = p;
            return View(trip);
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
