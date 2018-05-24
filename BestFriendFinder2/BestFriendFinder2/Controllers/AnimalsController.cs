using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BestFriendFinder2.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace BestFriendFinder2.Controllers
{
    public class AnimalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Animals
        public ActionResult Index()
        {
            var animals = db.Animals.Include(a => a.HumaneSociety);
            return View(animals.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            ViewBag.HumaneSocietyID = new SelectList(db.HumaneSocieties, "Id", "Name");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Breed,Neutered,Age,HumaneSocietyID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HumaneSocietyID = new SelectList(db.HumaneSocieties, "Id", "Name", animal.HumaneSocietyID);
            return View(animal);
        }

        [HttpPost]
        public ActionResult CreateFromCSV([Bind(Include = "Id,Name,Breed,Neutered,Age,HumaneSocietyID")]HttpPostedFileBase postedFile)
        {
            List<Animal> animals = new List<Animal>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                //Read the contents of CSV file.
                string csvData = System.IO.File.ReadAllText(filePath);
                
                //Execute a loop over the rows.
                string userID = User.Identity.GetUserId();  //get current userID
                var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();    //get user 
                var hs  = db.HumaneSocieties.Where(h => h.UserID == user.Id).FirstOrDefault();
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        db.Animals.Add(new Animal
                        {
                            Name = row.Split(',')[1],
                            Breed = row.Split(',')[2],
                            Neutered = Convert.ToBoolean(row.Split(',')[3]),
                            Age = Convert.ToInt32(row.Split(',')[4]),
                            HumaneSocietyID = hs.Id                            
                        });
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Index","Animals");
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.HumaneSocietyID = new SelectList(db.HumaneSocieties, "Id", "Name", animal.HumaneSocietyID);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Breed,Neutered,Age,HumaneSocietyID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HumaneSocietyID = new SelectList(db.HumaneSocieties, "Id", "Name", animal.HumaneSocietyID);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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
