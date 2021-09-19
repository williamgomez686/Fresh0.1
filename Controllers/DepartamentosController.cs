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
    public class DepartamentosController : Controller
    {
        private dbfreshEntities db = new dbfreshEntities();

        // GET: Departamentos
        public ActionResult Index()
        {
            return View(db.cl_geo_departamentos.ToList());
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cl_geo_departamentos cl_geo_departamentos = db.cl_geo_departamentos.Find(id);
            if (cl_geo_departamentos == null)
            {
                return HttpNotFound();
            }
            return View(cl_geo_departamentos);
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "depcod,depnom,depest,depusualt")] cl_geo_departamentos cl_geo_departamentos)
        {
            if (ModelState.IsValid)
            {
                db.cl_geo_departamentos.Add(cl_geo_departamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cl_geo_departamentos);
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cl_geo_departamentos cl_geo_departamentos = db.cl_geo_departamentos.Find(id);
            if (cl_geo_departamentos == null)
            {
                return HttpNotFound();
            }
            return View(cl_geo_departamentos);
        }

        // POST: Departamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "depcod,depnom,depest,depusualt")] cl_geo_departamentos cl_geo_departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cl_geo_departamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cl_geo_departamentos);
        }

        // GET: Departamentos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cl_geo_departamentos cl_geo_departamentos = db.cl_geo_departamentos.Find(id);
            if (cl_geo_departamentos == null)
            {
                return HttpNotFound();
            }
            return View(cl_geo_departamentos);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            cl_geo_departamentos cl_geo_departamentos = db.cl_geo_departamentos.Find(id);
            db.cl_geo_departamentos.Remove(cl_geo_departamentos);
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
