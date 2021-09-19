using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fresh0._1.Models;

namespace Fresh0._1.Controllers
{
    public class MunicipiosController : Controller
    {
        private dbfreshEntities db = new dbfreshEntities();

        // GET: Municipios
        public ActionResult Index()
        {
            var cl_geo_municipios = db.cl_geo_municipios.Include(c => c.cl_geo_departamentos);
            return View(cl_geo_municipios.ToList());
        }

        // GET: Municipios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cl_geo_municipios cl_geo_municipios = db.cl_geo_municipios.Find(id);
            if (cl_geo_municipios == null)
            {
                return HttpNotFound();
            }
            return View(cl_geo_municipios);
        }

        // GET: Municipios/Create
        public ActionResult Create()
        {
            ViewBag.depcod = new SelectList(db.cl_geo_departamentos, "depcod", "depnom");
            return View();
        }

        // POST: Municipios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "depcod,muncod,mundescripcion,munest,munusualt")] cl_geo_municipios cl_geo_municipios)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.cl_geo_municipios.Add(cl_geo_municipios);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }catch(Exception e)
                {
                    return Content("Ocurrio un Error" + e.Message);
                }
            }

            ViewBag.depcod = new SelectList(db.cl_geo_departamentos, "depcod", "depnom", cl_geo_municipios.depcod);
            return View(cl_geo_municipios);
        }

        // GET: Municipios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cl_geo_municipios cl_geo_municipios = db.cl_geo_municipios.Find(id);
            if (cl_geo_municipios == null)
            {
                return HttpNotFound();
            }
            ViewBag.depcod = new SelectList(db.cl_geo_departamentos, "depcod", "depnom", cl_geo_municipios.depcod);
            return View(cl_geo_municipios);
        }

        // POST: Municipios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "depcod,muncod,mundescripcion,munest,munusualt")] cl_geo_municipios cl_geo_municipios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cl_geo_municipios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depcod = new SelectList(db.cl_geo_departamentos, "depcod", "depnom", cl_geo_municipios.depcod);
            return View(cl_geo_municipios);
        }

        // GET: Municipios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cl_geo_municipios cl_geo_municipios = db.cl_geo_municipios.Find(id);
            if (cl_geo_municipios == null)
            {
                return HttpNotFound();
            }
            return View(cl_geo_municipios);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            cl_geo_municipios cl_geo_municipios = db.cl_geo_municipios.Find(id);
            db.cl_geo_municipios.Remove(cl_geo_municipios);
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
