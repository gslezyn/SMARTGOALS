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
    public class FuncionalidadeController : Controller
    {
        private SmartGoalsEntities db = new SmartGoalsEntities();

        //
        // GET: /Funcionalidade/

        public ViewResult Index()
        {
            return View(db.Fucionalidade.ToList());
        }

        //
        // GET: /Funcionalidade/Details/5

        public ViewResult Details(int id)
        {
            Fucionalidade fucionalidade = db.Fucionalidade.Single(f => f.Id == id);
            return View(fucionalidade);
        }

        //
        // GET: /Funcionalidade/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Funcionalidade/Create

        [HttpPost]
        public ActionResult Create(Fucionalidade fucionalidade)
        {
            if (ModelState.IsValid)
            {
                db.Fucionalidade.AddObject(fucionalidade);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(fucionalidade);
        }
        
        //
        // GET: /Funcionalidade/Edit/5
 
        public ActionResult Edit(int id)
        {
            Fucionalidade fucionalidade = db.Fucionalidade.Single(f => f.Id == id);
            return View(fucionalidade);
        }

        //
        // POST: /Funcionalidade/Edit/5

        [HttpPost]
        public ActionResult Edit(Fucionalidade fucionalidade)
        {
            if (ModelState.IsValid)
            {
                db.Fucionalidade.Attach(fucionalidade);
                db.ObjectStateManager.ChangeObjectState(fucionalidade, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fucionalidade);
        }

        //
        // GET: /Funcionalidade/Delete/5
 
        public ActionResult Delete(int id)
        {
            Fucionalidade fucionalidade = db.Fucionalidade.Single(f => f.Id == id);
            return View(fucionalidade);
        }

        //
        // POST: /Funcionalidade/Delete/5

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {            
            Fucionalidade fucionalidade = db.Fucionalidade.Single(f => f.Id == id);
            db.Fucionalidade.DeleteObject(fucionalidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}