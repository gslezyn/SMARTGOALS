using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartGoals.Models;

namespace SmartGoals.Controllers
{
    [Autorizar]
    public class ClienteController : Controller
    {
        private SmartGoalsEntities db = new SmartGoalsEntities();

        //
        // GET: /Cliente/

        public ViewResult Index()
        {
            return View(db.Cliente.ToList());
        }

        //
        // GET: /Cliente/Details/5

        public ViewResult Details(int id)
        {
            Cliente cliente = db.Cliente.Single(c => c.Id == id);
            return View(cliente);
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Cliente/Create

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.AddObject(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(cliente);
        }
        
        //
        // GET: /Cliente/Edit/5
 
        public ActionResult Edit(int id)
        {
            Cliente cliente = db.Cliente.Single(c => c.Id == id);
            return View(cliente);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Attach(cliente);
                db.ObjectStateManager.ChangeObjectState(cliente, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Delete/5
 
        public ActionResult Delete(int id)
        {
            Cliente cliente = db.Cliente.Single(c => c.Id == id);
            return View(cliente);
        }


        // POST: /Cliente/Delete/5

        [HttpPost]
        public ActionResult DeleteConfirmed()
        {
            int id = int.Parse(Request.Form["Id"]);
            Cliente cliente = db.Cliente.Single(c => c.Id == id);
            db.Cliente.DeleteObject(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult Get()
        {
            var retorno = from c in db.Cliente
                          select new 
                          {
                              Id = c.Id,
                              Nome = c.Nome
                          };
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}