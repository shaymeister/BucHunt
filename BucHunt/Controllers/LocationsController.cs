using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BucHunt.Models;
using DataLibrary.DBLogic;

namespace BucHunt.Controllers
{
    public class LocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LocationModels        
        /// <summary>
        /// displays the list of locations.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = LocationProcessor.LoadLocations();
            List<LocationModel> locations = new List<LocationModel>();
            foreach (var row in data)
            {
                locations.Add(new LocationModel
                {
                    Id = row.Id,
                    LocationName = row.LocationName,
                    DecodedQR = row.DecodedQR,
                    Completion = row.Completion,
                    UserEntry = row.UserEntry
                });
            }

            return View(locations);
        }

        // GET: LocationModels/Details/5        
        /// <summary>
        /// displays details for a location.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            var locId = id ?? default(int);
            var data = LocationProcessor.LoadSingleLocation(locId);
            List<LocationModel> locations = new List<LocationModel>();
            foreach (var row in data)
            {
                locations.Add(new LocationModel
                {
                    Id = row.Id,
                    LocationName = row.LocationName,
                    DecodedQR = row.DecodedQR,
                    Completion = row.Completion,
                    UserEntry = row.UserEntry
                });
            }
            var locationModel = locations[0];

            return View(locationModel);
        }






        // GET: LocationModels/Create        
        /// <summary>
        /// Creates a new location.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocationName,Completion,DecodedQR,UserEntry")] LocationModel locationModel)
        {
            if (ModelState.IsValid)
            {
                LocationProcessor.CreateLocation(locationModel.LocationName, locationModel.Completion,
                                                 locationModel.DecodedQR, locationModel.UserEntry);
                return RedirectToAction("Index");
            }

            return View(locationModel);
        }







        // GET: LocationModels/Edit/5        
        /// <summary>
        /// Edits a location.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var locId = id ?? default(int);
            var data = LocationProcessor.LoadSingleLocation(locId);
            List<LocationModel> locations = new List<LocationModel>();
            foreach (var row in data)
            {
                locations.Add(new LocationModel
                {
                    Id = row.Id,
                    LocationName = row.LocationName,
                    DecodedQR = row.DecodedQR,
                    Completion = row.Completion,
                    UserEntry = row.UserEntry
                });
            }
            var locationModel = locations[0];

            if (locationModel == null)
            {
                return HttpNotFound();
            }
            return View(locationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LocationName,Completion,DecodedQR,UserEntry")] LocationModel locationModel)
        {
            if (ModelState.IsValid)
            {
                LocationProcessor.UpdateLocation(locationModel.Id, locationModel.LocationName, locationModel.Completion,
                                                 locationModel.DecodedQR, locationModel.UserEntry);
                return RedirectToAction("Index");
            }

            return View(locationModel);
        }






        // GET: LocationModels/Delete/5        
        /// <summary>
        /// Deletes a location.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var locId = id ?? default(int);
            var data = LocationProcessor.LoadSingleLocation(locId);
            List<LocationModel> locations = new List<LocationModel>();
            foreach (var row in data)
            {
                locations.Add(new LocationModel
                {
                    Id = row.Id,
                    LocationName = row.LocationName,
                    DecodedQR = row.DecodedQR,
                    Completion = row.Completion,
                    UserEntry = row.UserEntry
                });
            }
            var locationModel = locations[0];

            if (locationModel == null)
            {
                return HttpNotFound();
            }
            return View(locationModel);
        }

        // POST: LocationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            LocationProcessor.DeleteLocation(id);
            return RedirectToAction("Index");
        }

        











                
        /// <summary>
        /// checks if user QR code matches stored value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult QRCodeEntry(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var locId = id ?? default(int);
            var data = LocationProcessor.LoadSingleLocation(locId);
            List<LocationModel> locations = new List<LocationModel>();
            foreach (var row in data)
            {
                locations.Add(new LocationModel
                {
                    Id = row.Id,
                    LocationName = row.LocationName,
                    DecodedQR = row.DecodedQR,
                    Completion = row.Completion,
                    UserEntry = row.UserEntry
                });
            }
            var locationModel = locations[0];

            if (locationModel == null)
            {
                return HttpNotFound();
            }
            return View(locationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QRCodeEntry([Bind(Include = "Id,LocationName,Completion,DecodedQR,UserEntry")] LocationModel locationModel)
        {
            LocationModel location = new LocationModel()
            {
                Id = locationModel.Id,
                LocationName = locationModel.LocationName,
                Completion = locationModel.Completion,
                DecodedQR = locationModel.DecodedQR,
                UserEntry = locationModel.UserEntry
            };

            if (ModelState.IsValid)
            {
                if (location.DecodedQR == location.UserEntry)
                {
                    location.Completion = "Complete";
                }
                else
                {
                    location.Completion = "Incomplete";
                }
                LocationProcessor.UpdateLocation(location.Id, location.LocationName, location.Completion,
                                                 location.DecodedQR, location.UserEntry);
                return RedirectToAction("Index");
            }
            return View(location);
        }





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

