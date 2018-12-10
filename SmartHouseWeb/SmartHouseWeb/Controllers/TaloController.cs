using System;
using System.Collections;
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
    public class TaloController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();

        // GET: Talo
        public ActionResult Index()
        {
            List<TaloViewModel> model = new List<TaloViewModel>();
            AlytaloEntities entities = new AlytaloEntities();
            try
            {
                List<Talot> lammot = entities.Talot.ToList();
                foreach(Talot talolampo in lammot)
                {
                    TaloViewModel lampo = new TaloViewModel();
                    lampo.TaloId = talolampo.TaloId;
                    lampo.TaloNimi = talolampo.TaloNimi;
                    lampo.TaloTavoiteLampotila = talolampo.TaloTavoiteLampotila;
                    lampo.TaloNykyLampotila = talolampo.TaloNykyLampotila;
                    lampo.LampoOff = talolampo.LampoOff;
                    lampo.LampoOn = talolampo.LampoOn;

                    model.Add(lampo);
                }

            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        // GET: Talo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talot talot = db.Talot.Find(id);
            if (talot == null)
            {
                return HttpNotFound();
            }
            return View(talot);
        }

        // GET: Talo/Create
        public ActionResult Create()
        {
            AlytaloEntities db = new AlytaloEntities();
            TaloViewModel model = new TaloViewModel();

            return View(model);
        }

        // POST: Talo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaloViewModel model) 
        {
            AlytaloEntities db = new AlytaloEntities();
            Talot lampo = new Talot();
            lampo.TaloNimi = model.TaloNimi;
            lampo.TaloNykyLampotila = lampo.TaloNykyLampotila;
            lampo.TaloTavoiteLampotila = lampo.TaloTavoiteLampotila;
            lampo.LampoOff = lampo.LampoOff;
            lampo.LampoOn = lampo.LampoOn;
            

            db.Talot.Add(lampo);

            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                
            }
            return RedirectToAction("Index");
        }

        // GET: Talo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talot talot = db.Talot.Find(id);
            if (talot == null)
            {
                return HttpNotFound();
            }
            return View(talot);
        }

        // POST: Talo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaloId,TaloNimi,TaloTavoiteLampotila,TaloNykyLampotila,LampoOff,LampoOn")] Talot talot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talot);
        }

        // GET: TaloLampo/LampoON/5
        public ActionResult LampoOn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talot talolampo = db.Talot.Find(id);
            if (talolampo == null)
            {
                return HttpNotFound();
            }

            TaloViewModel lampo = new TaloViewModel();
            lampo.TaloId = talolampo.TaloId;            
            lampo.LampoOn = true;
            lampo.LampoOff = false;
           

            return View(lampo);
        }

        // POST: TaloLampo/LampoON/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LampoON(TaloViewModel model)
        {
            Talot lampo = db.Talot.Find(model.TaloId);
            lampo.TaloId = model.TaloId;            
            lampo.LampoOn = true;
            lampo.LampoOff = false;
            

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TaloLampo/LampoOFF/5
        public ActionResult LampoOFF(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talot talolampo = db.Talot.Find(id);
            if (talolampo == null)
            {
                return HttpNotFound();
            }

            TaloViewModel lampo = new TaloViewModel();
            lampo.TaloId = talolampo.TaloId;           
            lampo.LampoOn = false;
            lampo.LampoOff = true;
            

            return View(lampo);
        }

        // POST: TaloLampo/LampoOFF/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LampoOFF(TaloViewModel model)
        {
            Talot lampo = db.Talot.Find(model.TaloId);
            lampo.TaloId = model.TaloId;           
            lampo.LampoOn = false;
            lampo.LampoOff = true;
           

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Talo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talot talot = db.Talot.Find(id);
            if (talot == null)
            {
                return HttpNotFound();
            }
            return View(talot);
        }

        // POST: Talo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talot talot = db.Talot.Find(id);
            db.Talot.Remove(talot);
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
