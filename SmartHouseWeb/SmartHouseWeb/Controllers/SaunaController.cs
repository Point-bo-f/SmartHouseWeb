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
    public class SaunaController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();

        // GET: Sauna
        public ActionResult Index()
        {
            return View(db.Saunat.ToList());
        }

        // GET: Sauna/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saunat saunat = db.Saunat.Find(id);
            if (saunat == null)
            {
                return HttpNotFound();
            }
            return View(saunat);
        }

        // GET: Sauna/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sauna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaunaId,SaunaNimi,SaunanTila,SaunaTavoiteLampotila,SaunaNykyLampotila")] Saunat saunat)
        {
            if (ModelState.IsValid)
            {
                db.Saunat.Add(saunat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saunat);
        }

        // GET: Sauna/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saunat taloSauna = db.Saunat.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.SaunaId = taloSauna.SaunaId;           
            sauna.SaunaNimi = taloSauna.SaunaNimi;
            sauna.SaunaTavoiteLampotila = taloSauna.SaunaTavoiteLampotila;
            sauna.SaunaNykyLampotila = taloSauna.SaunaNykyLampotila;
            

            ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { SaunaId = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

            return View(sauna);
        }

        // POST: Sauna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaunaViewModel model)
        {
            Saunat sauna = db.Saunat.Find(model.SaunaId);            
            sauna.SaunaNimi = model.SaunaNimi;
            sauna.SaunaTavoiteLampotila = model.SaunaTavoiteLampotila;
            sauna.SaunaNykyLampotila = model.SaunaNykyLampotila;
           

            ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { SaunaId = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//edit

        // GET: TaloSauna/SaunaOn/5
        public ActionResult SaunaOn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saunat taloSauna = db.Saunat.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.SaunaId = taloSauna.SaunaId;            
            sauna.SaunaNimi = taloSauna.SaunaNimi;            
            sauna.SaunanTila = true;

            ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { SaunaId = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

            return View(sauna);
        }

        // POST: TaloSauna/SaunaOn/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaunaOn(SaunaViewModel model)
        {
            Saunat sauna = db.Saunat.Find(model.SaunaId);            
            sauna.SaunaNimi = model.SaunaNimi;            
            sauna.SaunanTila = true;

            ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { SaunaId = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

            db.SaveChanges();
            return RedirectToAction("Index");
        }//

        // GET: TaloSauna/SaunaOff/5
        public ActionResult SaunaOff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saunat taloSauna = db.Saunat.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.SaunaId = taloSauna.SaunaId;            
            sauna.SaunaNimi = taloSauna.SaunaNimi;            
            sauna.SaunanTila = false;

            ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { SaunaId = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

            return View(sauna);
        }

        // POST: TaloSauna/SaunaOff/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaunaOff(SaunaViewModel model)
        {
            Saunat sauna = db.Saunat.Find(model.SaunaId);            
            sauna.SaunaNimi = model.SaunaNimi;            
            sauna.SaunanTila = false;

            ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { SaunaId = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

            db.SaveChanges();
            return RedirectToAction("Index");
        }//


        // GET: TaloSauna/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saunat taloSauna = db.Saunat.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.SaunaId = taloSauna.SaunaId;            
            sauna.SaunaNimi = taloSauna.SaunaNimi;
            sauna.SaunaTavoiteLampotila = taloSauna.SaunaTavoiteLampotila;
            sauna.SaunaNykyLampotila = taloSauna.SaunaNykyLampotila;            
            sauna.SaunanTila = taloSauna.SaunanTila;

            return View(sauna);
        }
        

        // POST: Sauna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Saunat saunat = db.Saunat.Find(id);
            db.Saunat.Remove(saunat);
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
