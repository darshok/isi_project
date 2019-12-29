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
    public class EstadisticasController : Controller
    {
        private VideoclubContext db = new VideoclubContext();

        // GET: Estadisticas
        public ActionResult Index()
        {
            return View(db.Estadisticas.ToList());
        }

        // GET: Estadisticas/Details/5
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

        // GET: Estadisticas/Create
        public ActionResult Create()
        {
            ViewBag.SocioId = new SelectList(db.Socios, "SocioId", "Nombre");
            return View();
        }

        // POST: Estadisticas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadisticaId,FechaCreacion")] Estadistica estadistica, [Bind(Include = "SocioId")] Socio socio)
        {
            ViewBag.SocioId = new SelectList(db.Socios, "SocioId", "Nombre");
            if (ModelState.IsValid)
            {
                var añoEstadistica = estadistica.FechaCreacion.Year;
                var mesEstadistica = estadistica.FechaCreacion.Month;
                var numEstadisticasSocio = db.Socios.FirstOrDefault(s => s.SocioId == socio.SocioId)
                   .Estadisticas.Where(e => e.FechaCreacion.Year == añoEstadistica &&
                   e.FechaCreacion.Month == mesEstadistica).ToList().Count;
                //Cuando ya existe una estadistica de un socio en un mes (de un año) determinado
                if(numEstadisticasSocio == 0)
                {
                    TempData["msg"] = "<script>alert('Ya existe una estadística para el mes introducido en este usuario');</script>";
                    return View();
                }
                var socioAux = db.Socios.FirstOrDefault(s => s.SocioId == socio.SocioId);
                estadistica.Socio = socioAux;
                estadistica.Videoclub = socioAux.Videoclub;
                estadistica.TotalGastado =
                    socioAux.Alquileres.Where
                    (a => a.FechaRecogida.Month == mesEstadistica && a.FechaRecogida.Year == añoEstadistica).Sum(a => a.TotalAPagar);
                db.Estadisticas.Add(estadistica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadistica);
        }

        // GET: Estadisticas/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.SocioId = new SelectList(db.Socios, "SocioId", "Nombre");
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

        // POST: Estadisticas/Edit/5
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

        // GET: Estadisticas/Delete/5
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

        // POST: Estadisticas/Delete/5
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
