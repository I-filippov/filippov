using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Filippov.Models;

namespace Filippov.Controllers
{
    public class Strah_typeController : Controller
    {
        private Entities db = new Entities();

        // GET: Strah_type
        public ActionResult Index()
        {
            return View(db.Strah_type.ToList());
        }

        // GET: Strah_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strah_type strah_type = db.Strah_type.Find(id);
            if (strah_type == null)
            {
                return HttpNotFound();
            }
            return View(strah_type);
        }

        // GET: Strah_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Strah_type/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Strah_type strah_type)
        {
            if (ModelState.IsValid)
            {
                db.Strah_type.Add(strah_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(strah_type);
        }

        // GET: Strah_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strah_type strah_type = db.Strah_type.Find(id);
            if (strah_type == null)
            {
                return HttpNotFound();
            }
            return View(strah_type);
        }

        // POST: Strah_type/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Strah_type strah_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strah_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(strah_type);
        }

        // GET: Strah_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strah_type strah_type = db.Strah_type.Find(id);
            if (strah_type == null)
            {
                return HttpNotFound();
            }
            return View(strah_type);
        }

        // POST: Strah_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Strah_type strah_type = db.Strah_type.Find(id);
            db.Strah_type.Remove(strah_type);
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
