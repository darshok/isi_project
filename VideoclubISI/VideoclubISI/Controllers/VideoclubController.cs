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
    public class VideoclubController : Controller
    {
        private VideoclubContext db = new VideoclubContext();

        // GET: Videoclub
        public ActionResult Index()
        {
            return View(db.Videoclubs.ToList());
        }

        // GET: Videoclub/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Videoclub videoclub = db.Videoclubs.Find(id);
            if (videoclub == null)
            {
                return HttpNotFound();
            }
            return View(videoclub);
        }

        // GET: Videoclub/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Videoclub/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoclubId,NombreDelGerente,Ciudad,Calle,CodPostal")] Models.Videoclub videoclub)
        {
            if (ModelState.IsValid)
            {
                db.Videoclubs.Add(videoclub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //var videoclubs = new SelectList(db.Videoclubs, "VideoclubId", "Calle");
            //ViewBag.VideoclubId = videoclubs;
            return View(videoclub);
        }

        // GET: Videoclub/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Videoclub videoclub = db.Videoclubs.Find(id);
            if (videoclub == null)
            {
                return HttpNotFound();
            }
            return View(videoclub);
        }

        // POST: Videoclub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoclubId,NombreDelGerente,Ciudad,Calle,CodPostal")] Models.Videoclub videoclub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoclub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoclub);
        }

        // GET: Videoclub/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Videoclub videoclub = db.Videoclubs.Find(id);
            if (videoclub == null)
            {
                return HttpNotFound();
            }
            return View(videoclub);
        }

        // POST: Videoclub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Videoclub videoclub = db.Videoclubs.Find(id);
            db.Videoclubs.Remove(videoclub);
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
