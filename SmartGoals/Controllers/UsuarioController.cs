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
    public class UsuarioController : Controller
    {
        private SmartGoalsEntities db = new SmartGoalsEntities();

        //
        // GET: /Usuario/

        public ViewResult Index()
        {
            return View(db.Usuario.ToList());
        }

        //
        // GET: /Usuario/Details/5

        public ViewResult Details(int id)
        {
            Usuario usuario = db.Usuario.Single(u => u.Id == id);
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.AddObject(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(usuario);
        }
        
        //
        // GET: /Usuario/Edit/5
 
        public ActionResult Edit(int id)
        {

            ViewBag.IdPerfil = new SelectList(db.Perfil, "Id", "Nome");
            Usuario usuario = db.Usuario.Single(u => u.Id == id);
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Attach(usuario);
                db.ObjectStateManager.ChangeObjectState(usuario, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5
 


        //
        // POST: /Usuario/Delete/5

        [HttpPost]
        public ActionResult DeleteConfirmed()
        {
            int id = int.Parse(Request.Form["Id"]);
            Usuario usuario = db.Usuario.Single(u => u.Id == id);
            db.Usuario.DeleteObject(usuario);
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