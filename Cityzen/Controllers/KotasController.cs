using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cityzen;

namespace Cityzen.Controllers
{
    public class KotasController : Controller
    {
        private cityEntities db = new cityEntities();

        // GET: Kotas
        public ActionResult Index()
        {
            return View(db.kotas.ToList());
        }

        // GET: Kotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kota kota = db.kotas.Find(id);
            if (kota == null)
            {
                return HttpNotFound();
            }
            return View(kota);
        }

        // GET: Kotas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,city,address")] kota kota)
        {
            if (ModelState.IsValid)
            {
                db.kotas.Add(kota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kota);
        }

        // GET: Kotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kota kota = db.kotas.Find(id);
            if (kota == null)
            {
                return HttpNotFound();
            }
            return View(kota);
        }

        // POST: Kotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,city,address")] kota kota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kota);
        }

        // GET: Kotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kota kota = db.kotas.Find(id);
            if (kota == null)
            {
                return HttpNotFound();
            }
            return View(kota);
        }

        // POST: Kotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kota kota = db.kotas.Find(id);
            db.kotas.Remove(kota);
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
