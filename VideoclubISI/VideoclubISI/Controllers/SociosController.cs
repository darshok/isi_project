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
    public class SociosController : Controller
    {
        private VideoclubContext db = new VideoclubContext();

        // GET: Socios
        public ActionResult Index()
        {
            return View(db.Socios.ToList());
        }

        // GET: Socios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socios.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // GET: Socios/Create
        public ActionResult Create()
        {
            ViewBag.VideoclubId = new SelectList(db.Videoclubs, "VideoclubId", "Calle");
            ViewBag.SocioId = new SelectList(db.Socios, "SocioId", "Nombre");
            return View();
        }

        // POST: Socios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SocioId,Nombre,Edad")] Socio socio, [Bind(Include = "VideoclubId")] Models.Videoclub videoclub)
        {
            if (ModelState.IsValid)
            {
                socio.Videoclub = db.Videoclubs.FirstOrDefault(v => v.VideoclubId == videoclub.VideoclubId);
                db.Socios.Add(socio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socio);
        }

        // GET: Socios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socios.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            var videoclubs = new SelectList(db.Videoclubs, "VideoclubId", "Calle");
            ViewBag.VideoclubId = videoclubs;
            ViewBag.SocioId = new SelectList(db.Socios, "SocioId", "Nombre");
            return View(socio);
        }

        // POST: Socios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SocioId,Nombre,Edad")] Socio socio, [Bind(Include = "VideoclubId")] Models.Videoclub videoclub)
        {
            if (ModelState.IsValid)
            {
                var socioAux = db.Socios.FirstOrDefault(s => s.SocioId == socio.SocioId);
                socioAux.Videoclub = db.Videoclubs.FirstOrDefault(v => v.VideoclubId == videoclub.VideoclubId);
                db.Entry(socioAux).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socio);
        }

        // GET: Socios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socios.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Socio socio = db.Socios.Find(id);
            db.Socios.Remove(socio);
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
