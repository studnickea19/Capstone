using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BestFriendFinder2.Models;

namespace BestFriendFinder2.Controllers
{
    public class HumaneSocietiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HumaneSocieties
        public ActionResult Index()
        {
            return View(db.HumaneSocieties.ToList());
        }

        // GET: HumaneSocieties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HumaneSociety humaneSociety = db.HumaneSocieties.Find(id);
            if (humaneSociety == null)
            {
                return HttpNotFound();
            }
            return View(humaneSociety);
        }

        // GET: HumaneSocieties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HumaneSocieties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StreetAddress,City,State,Zipcode")] HumaneSociety humaneSociety)
        {
            if (ModelState.IsValid)
            {
                db.HumaneSocieties.Add(humaneSociety);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(humaneSociety);
        }

        // GET: HumaneSocieties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HumaneSociety humaneSociety = db.HumaneSocieties.Find(id);
            if (humaneSociety == null)
            {
                return HttpNotFound();
            }
            return View(humaneSociety);
        }

        // POST: HumaneSocieties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StreetAddress,City,State,Zipcode")] HumaneSociety humaneSociety)
        {
            if (ModelState.IsValid)
            {
                db.Entry(humaneSociety).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(humaneSociety);
        }

        // GET: HumaneSocieties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HumaneSociety humaneSociety = db.HumaneSocieties.Find(id);
            if (humaneSociety == null)
            {
                return HttpNotFound();
            }
            return View(humaneSociety);
        }

        // POST: HumaneSocieties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HumaneSociety humaneSociety = db.HumaneSocieties.Find(id);
            db.HumaneSocieties.Remove(humaneSociety);
            db.SaveChanges();
            return RedirectToAction("Index");
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
