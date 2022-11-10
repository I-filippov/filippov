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
    public class Strah_sluchaiController : Controller
    {
        private Entities db = new Entities();

        // GET: Strah_sluchai
        public ActionResult Index()
        {
            var strah_sluchai = db.Strah_sluchai.Include(s => s.Strah_type);
            return View(strah_sluchai.ToList());
        }

        // GET: Strah_sluchai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strah_sluchai strah_sluchai = db.Strah_sluchai.Find(id);
            if (strah_sluchai == null)
            {
                return HttpNotFound();
            }
            return View(strah_sluchai);
        }

        // GET: Strah_sluchai/Create
        public ActionResult Create()
        {
            ViewBag.Id_strah_type = new SelectList(db.Strah_type, "Id", "Name");
            return View();
        }

        // POST: Strah_sluchai/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_strah_type,Name")] Strah_sluchai strah_sluchai)
        {
            if (ModelState.IsValid)
            {
                db.Strah_sluchai.Add(strah_sluchai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_strah_type = new SelectList(db.Strah_type, "Id", "Name", strah_sluchai.Id_strah_type);
            return View(strah_sluchai);
        }

        // GET: Strah_sluchai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strah_sluchai strah_sluchai = db.Strah_sluchai.Find(id);
            if (strah_sluchai == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_strah_type = new SelectList(db.Strah_type, "Id", "Name", strah_sluchai.Id_strah_type);
            return View(strah_sluchai);
        }

        // POST: Strah_sluchai/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_strah_type,Name")] Strah_sluchai strah_sluchai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strah_sluchai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_strah_type = new SelectList(db.Strah_type, "Id", "Name", strah_sluchai.Id_strah_type);
            return View(strah_sluchai);
        }

        // GET: Strah_sluchai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strah_sluchai strah_sluchai = db.Strah_sluchai.Find(id);
            if (strah_sluchai == null)
            {
                return HttpNotFound();
            }
            return View(strah_sluchai);
        }

        // POST: Strah_sluchai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Strah_sluchai strah_sluchai = db.Strah_sluchai.Find(id);
            db.Strah_sluchai.Remove(strah_sluchai);
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
