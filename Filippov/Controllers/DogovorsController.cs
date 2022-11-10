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
    public class DogovorsController : Controller
    {
        private Entities db = new Entities();

        // GET: Dogovors
        public ActionResult Index()
        {
            var dogovor = db.Dogovor.Include(d => d.AspNetUsers).Include(d => d.AspNetUsers1).Include(d => d.Strah_sluchai).Include(d => d.Strah_type);
            return View(dogovor.ToList());
        }

        // GET: Dogovors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogovor dogovor = db.Dogovor.Find(id);
            if (dogovor == null)
            {
                return HttpNotFound();
            }
            return View(dogovor);
        }

        // GET: Dogovors/Create
        public ActionResult Create()
        {
            ViewBag.Id_custumer = new SelectList(db.AspNetUsers, "Id", "FIO");
            ViewBag.Id_employee = new SelectList(db.AspNetUsers, "Id", "FIO");
            ViewBag.Id_strah_sluchai = new SelectList(db.Strah_sluchai, "Id", "Name");
            ViewBag.Id_strah_type = new SelectList(db.Strah_type, "Id", "Name");
            return View();
        }

        // POST: Dogovors/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_custumer,Id_employee,Id_strah_sluchai,Id_strah_type,Tarif,Strah_summa,Strah_platej,Date_start,Date_end")] Dogovor dogovor)
        {
            if (ModelState.IsValid)
            {
                db.Dogovor.Add(dogovor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_custumer = new SelectList(db.AspNetUsers, "Id", "FIO", dogovor.Id_custumer);
            ViewBag.Id_employee = new SelectList(db.AspNetUsers, "Id", "FIO", dogovor.Id_employee);
            ViewBag.Id_strah_sluchai = new SelectList(db.Strah_sluchai, "Id", "Name", dogovor.Id_strah_sluchai);
            ViewBag.Id_strah_type = new SelectList(db.Strah_type, "Id", "Name", dogovor.Id_strah_type);
            return View(dogovor);
        }

        // GET: Dogovors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogovor dogovor = db.Dogovor.Find(id);
            if (dogovor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_custumer = new SelectList(db.AspNetUsers, "Id", "FIO", dogovor.Id_custumer);
            ViewBag.Id_employee = new SelectList(db.AspNetUsers, "Id", "FIO", dogovor.Id_employee);
            ViewBag.Id_strah_sluchai = new SelectList(db.Strah_sluchai, "Id", "Name", dogovor.Id_strah_sluchai);
            ViewBag.Id_strah_type = new SelectList(db.Strah_type, "Id", "Name", dogovor.Id_strah_type);
            return View(dogovor);
        }

        // POST: Dogovors/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_custumer,Id_employee,Id_strah_sluchai,Id_strah_type,Tarif,Strah_summa,Strah_platej,Date_start,Date_end")] Dogovor dogovor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dogovor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_custumer = new SelectList(db.AspNetUsers, "Id", "FIO", dogovor.Id_custumer);
            ViewBag.Id_employee = new SelectList(db.AspNetUsers, "Id", "FIO", dogovor.Id_employee);
            ViewBag.Id_strah_sluchai = new SelectList(db.Strah_sluchai, "Id", "Name", dogovor.Id_strah_sluchai);
            ViewBag.Id_strah_type = new SelectList(db.Strah_type, "Id", "Name", dogovor.Id_strah_type);
            return View(dogovor);
        }

        // GET: Dogovors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogovor dogovor = db.Dogovor.Find(id);
            if (dogovor == null)
            {
                return HttpNotFound();
            }
            return View(dogovor);
        }

        // POST: Dogovors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dogovor dogovor = db.Dogovor.Find(id);
            db.Dogovor.Remove(dogovor);
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
