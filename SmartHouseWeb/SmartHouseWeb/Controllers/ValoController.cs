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
            List<ValoViewModel> model = new List<ValoViewModel>();
            AlytaloEntities entities = new AlytaloEntities();
            try
            {
                List<Valot> valot = entities.Valot.ToList();
                foreach(Valot talovalo in valot)
                {
                    ValoViewModel valo = new ValoViewModel();
                    valo.ValoId = talovalo.ValoId;
                    valo.Huone = talovalo.Huone;
                    valo.ValoOff = talovalo.ValoOff;
                    valo.ValoOn33 = talovalo.ValoOn33;
                    valo.ValoOn66 = talovalo.ValoOn66;
                    valo.ValoOn100 = talovalo.ValoOn100;

                    model.Add(valo);
                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
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
            AlytaloEntities db = new AlytaloEntities();
            ValoViewModel model = new ValoViewModel();

            return View(model);
        }

        // POST: Valo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ValoViewModel model)
        {
            AlytaloEntities db = new AlytaloEntities();
            Valot valo = new Valot();
            valo.Huone = model.Huone;
            valo.ValoOff = model.ValoOff;
            valo.ValoOn33 = model.ValoOn33;
            valo.ValoOn66 = model.ValoOn66;
            valo.ValoOn100 = model.ValoOn100;

            db.Valot.Add(valo);

            try
            {
                db.SaveChanges();
            }



            catch (Exception ex)
            {

            }
                  
            return RedirectToAction("Index");
        }

        // GET: Valo/Edit/5
        public ActionResult Edit(int? id)
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
            

           // ViewBag.Huone = new SelectList((from tv in db.Valot select new { Valo_ID = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
           

            return View(valo);
        }

        // POST: Valo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ValoViewModel model)
        {
            Valot valo = db.Valot.Find(model.ValoId);
            //valo.Valo_ID = model.Valo_ID;
            valo.Huone = model.Huone;
            

           // ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
           

            db.SaveChanges();

            return RedirectToAction("Index");
        }//edit


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
            valo.ValoOn33 = false;
            valo.ValoOn66 = false;
            valo.ValoOn100 = false;
            valo.ValoOff = true;
            

            return View(valo);
        }

        // POST: TaloValo/LightsOff/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LightsOff(ValoViewModel model)
        {
            Valot valo = db.Valot.Find(model.ValoId);
            valo.ValoOff = true;
            valo.ValoOn33 = false;
            valo.ValoOn66 = false;
            valo.ValoOn100 = false;
            
            

           // ViewBag.Huone = new SelectList((from tv in db.Valot select new { Valo_ID = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
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
            valo.ValoOn33 = true;
            valo.ValoOn66 = false;
            valo.ValoOn100 = false;
            valo.ValoOff = false;
            

            //ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
           

            return View(valo);
        }

        // POST: TaloValo/Light33/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Light33(ValoViewModel model)
        {
            Valot valo = db.Valot.Find(model.ValoId);
            valo.ValoOff = false;
            valo.ValoOn33 = true;
            valo.ValoOn66 = false;
            valo.ValoOn100 = false;
            
            

            //ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
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
            valo.ValoOn33 = false;
            valo.ValoOn66 = true;
            valo.ValoOn100 = false;
            valo.ValoOff = false;
            

            //ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
            

            return View(valo);
        }

        // POST: TaloValo/Light66/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Light66(ValoViewModel model)
        {
            Valot valo = db.Valot.Find(model.ValoId);            
            valo.ValoOn33 = false;
            valo.ValoOn66 = true;
            valo.ValoOn100 = false;
            
            

           // ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
            
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
            valo.ValoOn33 = false;
            valo.ValoOn66 = false;
            valo.ValoOn100 = true;
            valo.ValoOff = false;
            

           // ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
           // ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            return View(valo);
        }

        // POST: TaloValo/Light100/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Light100(ValoViewModel model)
        {
            Valot valo = db.Valot.Find(model.ValoId);            
            valo.ValoOn33 = false;
            valo.ValoOn66 = false;
            valo.ValoOn100 = true;
           
            

            //ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
            

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
