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
    public class PerfilController : Controller
    {
        private SmartGoalsEntities db = new SmartGoalsEntities();

        //
        // GET: /Perfil/

        public ViewResult Index()
        {
            return View(db.Perfil.ToList());
        }

        //
        // GET: /Perfil/Details/5

        public ViewResult Details(int id)
        {
            Perfil perfil = db.Perfil.Single(p => p.Id == id);
            return View(perfil);
        }

        //
        // GET: /Perfil/Create

        public ActionResult Create()
        {

            ViewBag.Funcionalidades = db.Fucionalidade;
            return View();
        }

        //
        // POST: /Perfil/Create

        [HttpPost]
        public ActionResult Create(Perfil perfil)
        {
            if (ModelState.IsValid)
            {

                string[] ids = Request.Form.AllKeys.Skip(1).ToArray();
                foreach (var item in ids)
                {
                    int id = int.Parse(Request.Form[item]);

                    db.ExecuteStoreCommand("Insert into PerfilFuncionalidade values({0}, {1})", new object[] { perfil.Id, id });
                }

                db.Perfil.AddObject(perfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfil);
        }

        //
        // GET: /Perfil/Edit/5

        public ActionResult Edit(int id)
        {

            ViewBag.Funcionalidades = db.Fucionalidade;

            Perfil perfil = db.Perfil.Single(p => p.Id == id);
            return View(perfil);
        }

        //
        // POST: /Perfil/Edit/5

        [HttpPost]
        public ActionResult Edit(Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                string[] ids = Request.Form.AllKeys.Skip(1).ToArray();

                db.ExecuteStoreCommand("Delete from PerfilFuncionalidade where IdPerfil = {0}", new object[] { perfil.Id });

                foreach (var item in ids)
                {
                    int id = int.Parse(Request.Form[item]);

                    db.ExecuteStoreCommand("Insert into PerfilFuncionalidade values({0}, {1})", new object[] { perfil.Id, id });
                }



                db.Perfil.Attach(perfil);
                db.ObjectStateManager.ChangeObjectState(perfil, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfil);
        }

        //
        // GET: /Perfil/Delete/5

        public ActionResult Delete(int id)
        {
            Perfil perfil = db.Perfil.Single(p => p.Id == id);
            return View(perfil);
        }

        //
        // POST: /Perfil/Delete/5

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfil perfil = db.Perfil.Single(p => p.Id == id);
            db.Perfil.DeleteObject(perfil);
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