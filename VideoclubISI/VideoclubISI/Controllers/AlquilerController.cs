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
    public class AlquilerController : Controller
    {
        private VideoclubContext db = new VideoclubContext();

        // GET: Alquiler
        public ActionResult Index()
        {
            return View(db.Alquileres.ToList());
        }

        // GET: Alquiler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler alquiler = db.Alquileres.FirstOrDefault(a => a.AlquilerId == id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            return View(alquiler);
        }

        // GET: Alquiler/Create
        public ActionResult Create()
        {

            ViewBag.SocioId = new SelectList(db.Socios, "SocioId", "Nombre");
            var peliculas = db.Peliculas.ToList();
            ViewBag.PeliculasView = new MultiSelectList(peliculas, "PeliculaId", "Nombre");
            return View();
        }

        // POST: Alquiler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlquilerId,FechaRecogida,FechaDevolucion")] Alquiler alquiler, [Bind(Include = "SocioId")] Socio socio, [Bind(Include = "PeliculaId")] int[] peliculaId)
        {
            ViewBag.SocioId = new SelectList(db.Socios, "SocioId", "Nombre");
            var peliculas = db.Peliculas.ToList();
            ViewBag.PeliculasView = new MultiSelectList(peliculas, "PeliculaId", "Nombre");
            if (ModelState.IsValid)
            {
                alquiler.Socio = db.Socios.Find(socio.SocioId);
                foreach(var pelicula in peliculaId)
                {
                    var pAux = db.Peliculas.FirstOrDefault(p => p.PeliculaId == pelicula);
                    db.PeliculaAlquiler.Add(new PeliculaAlquiler { Pelicula = pAux , Alquiler = alquiler });
                    alquiler.TotalAPagar += pAux.PrecioAlquiler;
                }

                db.Alquileres.Add(alquiler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alquiler);
        }

        // GET: Alquiler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler alquiler = db.Alquileres.Find(id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            return View(alquiler);
        }

        // POST: Alquiler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlquilerId,FechaRecogida,FechaDevolucion,TotalAPagar")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                var alquilerAux = db.Alquileres.FirstOrDefault(a => a.AlquilerId == alquiler.AlquilerId);
                alquilerAux.FechaDevolucion = alquiler.FechaDevolucion;
                db.Entry(alquilerAux).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alquiler);
        }
        //WIP
        [HttpPost]
        public ActionResult Multiple(int[] peliculaId)
        {
            return View();
        }

        // GET: Alquiler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler alquiler = db.Alquileres.Find(id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            return View(alquiler);
        }

        // POST: Alquiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alquiler alquiler = db.Alquileres.Find(id);
            db.PeliculaAlquiler.RemoveRange(db.PeliculaAlquiler.Where(a => a.Alquiler.AlquilerId == id));
            db.SaveChanges();
            db.Alquileres.Remove(alquiler);
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
