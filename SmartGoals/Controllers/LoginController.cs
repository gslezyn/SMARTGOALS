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

    public class LoginController : Controller
    {
        private SmartGoalsEntities db = new SmartGoalsEntities();

        //
        // GET: /Login/

        public ActionResult Index()
        {
#if DEBUG
            Session[Constantes.Constantes.SESSION_ACESSO] = db.Usuario.Single(u => u.Username == "gslezyn");
            var usr = db.Usuario.Single(o => o.Username == "gslezyn");

            var menu = db.Fucionalidade.Where(o => o.PerfilFuncionalidade.Any(p => p.IdPerfil == usr.IdPerfil)).ToList();

            //var menu = db.PerfilFuncionalidade.Where(u=> u.Perfil.Id == usr.IdPerfil).Include();
            //Usuario.Single(o => o.Username == "gslezyn").Perfil.PerfilFuncionalidade.ToList()

     


            Session["Usr"] = usr;

            Session["Menu"] = menu;

            return RedirectToAction("Index", "Home");

#endif


            Session.RemoveAll();
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult Logon(Usuario usuario)
        {

            bool Teste = db.Usuario.Any(o => o.Username == usuario.Username
                  && o.Senha == usuario.Senha);


            if (Teste)
            {
                Session[Constantes.Constantes.SESSION_ACESSO] = db.Usuario.Single(u => u.Username == usuario.Username);

              

                var usr = db.Usuario.Single(o => o.Username == usuario.Username);

                var menu = db.Fucionalidade.Where(o => o.PerfilFuncionalidade.Any(p => p.IdPerfil == usr.IdPerfil)).ToList();


                Session["Usr"] = usr;

                Session["Menu"] = menu;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        // GET: /Login/Details/5

        public ViewResult Details(int id)
        {
            Usuario usuario = db.Usuario.Single(u => u.Id == id);
            return View(usuario);
        }

        //
        // GET: /Login/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Login/Create

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
        // GET: /Login/Edit/5

        public ActionResult Edit(int id)
        {
            Usuario usuario = db.Usuario.Single(u => u.Id == id);
            return View(usuario);
        }

        //
        // POST: /Login/Edit/5

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
        // GET: /Login/Delete/5

        public ActionResult Delete(int id)
        {
            Usuario usuario = db.Usuario.Single(u => u.Id == id);
            return View(usuario);
        }

        //
        // POST: /Login/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
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