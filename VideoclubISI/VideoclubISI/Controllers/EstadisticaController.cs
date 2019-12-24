using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Videoclub.DAL;
using Videoclub.Models;

namespace Videoclub.Controllers
{
    public class EstadisticaController : Controller
    {
        private VideoclubContext db = new VideoclubContext();

        // GET: Estadistica
        public ActionResult Index()
        {
            return View(db.Estadisticas.ToList());
        }

        // GET: Estadistica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadistica estadistica = db.Estadisticas.Find(id);
            if (estadistica == null)
            {
                return HttpNotFound();
            }
            return View(estadistica);
        }

        // GET: Estadistica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estadistica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadisticaId,FechaCreacion,TotalGastado")] Estadistica estadistica)
        {
            if (ModelState.IsValid)
            {
                db.Estadisticas.Add(estadistica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadistica);
        }

        // GET: Estadistica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadistica estadistica = db.Estadisticas.Find(id);
            if (estadistica == null)
            {
                return HttpNotFound();
            }
            return View(estadistica);
        }

        // POST: Estadistica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadisticaId,FechaCreacion,TotalGastado")] Estadistica estadistica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadistica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadistica);
        }

        // GET: Estadistica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadistica estadistica = db.Estadisticas.Find(id);
            if (estadistica == null)
            {
                return HttpNotFound();
            }
            return View(estadistica);
        }

        // POST: Estadistica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estadistica estadistica = db.Estadisticas.Find(id);
            db.Estadisticas.Remove(estadistica);
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
