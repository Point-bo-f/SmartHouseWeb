using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartHouseWeb.Models;
using SmartHouseWeb.ViewModels;

namespace SmartHouseWeb.Controllers
{
    public class ValoController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();

        // GET: Valo
        public ActionResult Index()
        {
            return View(db.Valot.ToList());
        }

        // GET: Valo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // GET: Valo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Valo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValoId,Huone,ValoOff,ValoOn33,ValoOn66,ValoOn100")] Valot valot)
        {
            if (ModelState.IsValid)
            {
                db.Valot.Add(valot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valot);
        }

        // GET: Valo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // POST: Valo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValoId,Huone,ValoOff,ValoOn33,ValoOn66,ValoOn100")] Valot valot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valot);
        }

        // GET: TaloValo/LightsOff/5
        public ActionResult LightsOff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot Valot = db.Valot.Find(id);
            if (Valot == null)
            {
                return HttpNotFound();
            }

            ValoViewModel valo = new ValoViewModel();
            valo.ValoId = Valot.ValoId;
            valo.Huone = Valot.Huone;            
            valo.Valo33 = false;
            valo.Valo66 = false;
            valo.Valo100 = false;
            valo.ValoTilaOff = true;
            

            return View(valo);
        }

        // POST: TaloValo/LightsOff/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LightsOff(ValoViewModel model)
        {
            Valot valo = db.Valot.Find(model.ValoId);
            valo.Huone = model.Huone;            
            valo.Valo33 = false;
            valo.Valo66 = false;
            valo.Valo100 = false;
            valo.ValoTilaOff = true;
            

            ViewBag.Huone = new SelectList((from tv in db.Valot select new { Valo_ID = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
            //ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//

        // GET: TaloValo/Light33/5
        public ActionResult Light33(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot talovalo = db.Valot.Find(id);
            if (talovalo == null)
            {
                return HttpNotFound();
            }

            ValoViewModel valo = new ValoViewModel();
            valo.ValoId = talovalo.ValoId;
            valo.Huone = talovalo.Huone;            
            valo.Valo33 = true;
            valo.Valo66 = false;
            valo.Valo100 = false;
            valo.ValoTilaOff = false;
            

            ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
           

            return View(valo);
        }

        // POST: TaloValo/Light33/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Light33(ValoViewModel model)
        {
            Valot valo = db.Valot.Find(model.ValoId);
            valo.Huone = model.Huone;            
            valo.Valo33 = true;
            valo.Valo66 = false;
            valo.Valo100 = false;
            valo.ValoTilaOff = false;
            

            ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
            //ViewBag.ValaisinType = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//

        // GET: TaloValo/Light66/5
        public ActionResult Light66(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot talovalo = db.Valot.Find(id);
            if (talovalo == null)
            {
                return HttpNotFound();
            }

            ValoViewModel valo = new ValoViewModel();
            valo.ValoId = talovalo.ValoId;
            valo.Huone = talovalo.Huone;            
            valo.Valo33 = false;
            valo.Valo66 = true;
            valo.Valo100 = false;
            valo.ValoTilaOff = false;
            

            ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
            

            return View(valo);
        }

        // POST: TaloValo/Light66/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Light66(ValoViewModel model)
        {
            Valot valo = db.Valot.Find(model.ValoId);
            valo.Huone = model.Huone;            
            valo.Valo33 = false;
            valo.Valo66 = true;
            valo.Valo100 = false;
            valo.ValoTilaOff = false;
            

            ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
            
            db.SaveChanges();

            return RedirectToAction("Index");
        }//

        // GET: TaloValo/Light100/5
        public ActionResult Light100(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot talovalo = db.Valot.Find(id);
            if (talovalo == null)
            {
                return HttpNotFound();
            }

            ValoViewModel valo = new ValoViewModel();
            valo.ValoId = talovalo.ValoId;
            valo.Huone = talovalo.Huone;            
            valo.Valo33 = false;
            valo.Valo66 = false;
            valo.Valo100 = true;
            valo.ValoTilaOff = false;
            

            ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
           // ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            return View(valo);
        }

        // POST: TaloValo/Light100/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Light100(ValoViewModel model)
        {
            Valot valo = db.Valot.Find(model.ValoId);
            valo.Huone = model.Huone;            
            valo.Valo33 = false;
            valo.Valo66 = false;
            valo.Valo100 = true;
            valo.ValoTilaOff = false;
            

            ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
            

            db.SaveChanges();

            return RedirectToAction("Index");
        }//
        // GET: Valo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // POST: Valo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valot valot = db.Valot.Find(id);
            db.Valot.Remove(valot);
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
