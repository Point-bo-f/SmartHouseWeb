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
            List<SaunaViewModel> model = new List<SaunaViewModel>();
            AlytaloEntities entities = new AlytaloEntities();
            try
            {
                List<Saunat> saunat = entities.Saunat.ToList();
                foreach (Saunat talosauna in saunat)
                {
                    SaunaViewModel sauna = new SaunaViewModel();
                    sauna.SaunaId = talosauna.SaunaId;
                    sauna.SaunaNimi = talosauna.SaunaNimi;
                    sauna.SaunanTila = talosauna.SaunanTila;
                    sauna.SaunaNykyLampotila = talosauna.SaunaNykyLampotila;
                    sauna.SaunaTavoiteLampotila = talosauna.SaunaTavoiteLampotila;

                    model.Add(sauna);
                }
            }

            finally
            {
                entities.Dispose();
            }
            
            return View(model);
        }

        // GET: Sauna/Details/5
        public ActionResult Details(int? id)
        {
            SaunaViewModel model = new SaunaViewModel();
            AlytaloEntities entities = new AlytaloEntities();

            try
            {
                Saunat taloSauna = db.Saunat.Find(id);
                if (taloSauna == null)

                {
                    return HttpNotFound();
                }

                Saunat saunadetail = entities.Saunat.Find(taloSauna.SaunaId);

                SaunaViewModel sauna = new SaunaViewModel();
                sauna.SaunaId = saunadetail.SaunaId;                
                sauna.SaunaNimi = saunadetail.SaunaNimi;
                sauna.SaunaTavoiteLampotila = saunadetail.SaunaTavoiteLampotila;
                sauna.SaunaNykyLampotila = saunadetail.SaunaNykyLampotila;                
                sauna.SaunanTila = saunadetail.SaunanTila;

                model = sauna;

            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        // GET: Sauna/Create
        public ActionResult Create()
        {
            AlytaloEntities db = new AlytaloEntities();

            SaunaViewModel model = new SaunaViewModel();

            //ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { SaunaId = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", null);

            return View(model);
        }

        // POST: Sauna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaunaViewModel model)
        {
            AlytaloEntities db = new AlytaloEntities();

            Saunat sauna = new Saunat();                      
            sauna.SaunaNimi = model.SaunaNimi;                           
            sauna.SaunaTavoiteLampotila = model.SaunaTavoiteLampotila;
            sauna.SaunaNykyLampotila = model.SaunaNykyLampotila;
            sauna.SaunanTila = model.SaunanTila;

            db.Saunat.Add(sauna);

            //ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { SaunaId = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", null);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }//create*/;

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
            sauna.SaunaId = model.SaunaId;            
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
            sauna.SaunaId = model.SaunaId;            
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
