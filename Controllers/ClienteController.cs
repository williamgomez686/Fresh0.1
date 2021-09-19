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
    public class ClienteController : Controller
    {
        private dbfreshEntities db = new dbfreshEntities();

        // GET: Cliente
        public ActionResult Index()
        {
            var cl_cliente = db.cl_cliente.Include(c => c.cl_empresa).Include(c => c.cl_estado).Include(c => c.cl_geo_departamentos).Include(c => c.cl_geo_municipios);
            return View(cl_cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cl_cliente cl_cliente = db.cl_cliente.Find(id);
            if (cl_cliente == null)
            {
                return HttpNotFound();
            }
            return View(cl_cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.clicod = new SelectList(db.cl_cliente, "clicod", "empcod");
            ViewBag.clicod = new SelectList(db.cl_cliente, "clicod", "empcod");
            ViewBag.empcod = new SelectList(db.cl_empresa, "empcod", "enpnom");
            ViewBag.cliest = new SelectList(db.cl_estado, "estcod", "estdescripcion");
            ViewBag.id_depcod = new SelectList(db.cl_geo_departamentos, "depcod", "depnom");
            ViewBag.id_muncod = new SelectList(db.cl_geo_municipios, "muncod", "depcod");
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empcod,clicod,clinom,cliapellido,clidir,cliemail,clitel,clicel1,clicel2,clidpi,clinit,clifchalt,cliusualt,id_depcod,id_muncod,cliest")] cl_cliente cl_cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    db.cl_cliente.Add(cl_cliente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }catch(Exception e)
                {
                    return Content("Ocurrio un Error" + e.Message);
                }
            }

            ViewBag.clicod = new SelectList(db.cl_cliente, "clicod", "empcod", cl_cliente.clicod);
            ViewBag.clicod = new SelectList(db.cl_cliente, "clicod", "empcod", cl_cliente.clicod);
            ViewBag.empcod = new SelectList(db.cl_empresa, "empcod", "enpnom", cl_cliente.empcod);
            ViewBag.cliest = new SelectList(db.cl_estado, "estcod", "estdescripcion", cl_cliente.cliest);
            ViewBag.id_depcod = new SelectList(db.cl_geo_departamentos, "depcod", "depnom", cl_cliente.id_depcod);
            ViewBag.id_muncod = new SelectList(db.cl_geo_municipios, "muncod", "depcod", cl_cliente.id_muncod);
            return View(cl_cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cl_cliente cl_cliente = db.cl_cliente.Find(id);
            if (cl_cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.clicod = new SelectList(db.cl_cliente, "clicod", "empcod", cl_cliente.clicod);
            ViewBag.clicod = new SelectList(db.cl_cliente, "clicod", "empcod", cl_cliente.clicod);
            ViewBag.empcod = new SelectList(db.cl_empresa, "empcod", "enpnom", cl_cliente.empcod);
            ViewBag.cliest = new SelectList(db.cl_estado, "estcod", "estdescripcion", cl_cliente.cliest);
            ViewBag.id_depcod = new SelectList(db.cl_geo_departamentos, "depcod", "depnom", cl_cliente.id_depcod);
            ViewBag.id_muncod = new SelectList(db.cl_geo_municipios, "muncod", "depcod", cl_cliente.id_muncod);
            return View(cl_cliente);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empcod,clicod,clinom,cliapellido,clidir,cliemail,clitel,clicel1,clicel2,clidpi,clinit,clifchalt,cliusualt,id_depcod,id_muncod,cliest")] cl_cliente cl_cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cl_cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clicod = new SelectList(db.cl_cliente, "clicod", "empcod", cl_cliente.clicod);
            ViewBag.clicod = new SelectList(db.cl_cliente, "clicod", "empcod", cl_cliente.clicod);
            ViewBag.empcod = new SelectList(db.cl_empresa, "empcod", "enpnom", cl_cliente.empcod);
            ViewBag.cliest = new SelectList(db.cl_estado, "estcod", "estdescripcion", cl_cliente.cliest);
            ViewBag.id_depcod = new SelectList(db.cl_geo_departamentos, "depcod", "depnom", cl_cliente.id_depcod);
            ViewBag.id_muncod = new SelectList(db.cl_geo_municipios, "muncod", "depcod", cl_cliente.id_muncod);
            return View(cl_cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cl_cliente cl_cliente = db.cl_cliente.Find(id);
            if (cl_cliente == null)
            {
                return HttpNotFound();
            }
            return View(cl_cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            cl_cliente cl_cliente = db.cl_cliente.Find(id);
            db.cl_cliente.Remove(cl_cliente);
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
