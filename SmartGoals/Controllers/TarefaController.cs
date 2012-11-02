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
    public class TarefaController : Controller
    {
        private SmartGoalsEntities db = new SmartGoalsEntities();

        //
        // GET: /Tarefa/

        public ViewResult Index(int? id)
        {
            ViewBag.IdStatus = new SelectList(db.Status, "Id", "Nome");
            if (id.HasValue)
            {
                var tarefa = db.Tarefa.Include("TarefaGrupo").Include("Usuario").Where(o => o.IdUsuario == id);
                return View(tarefa.ToList());
            
            }
            else
            {
                var tarefa = db.Tarefa.Include("TarefaGrupo").Include("Usuario").Include("Status");
                return View(tarefa.ToList());
            }
            }

        //
        // GET: /Tarefa/Details/5

        public ViewResult Details(int id)
        {
            Tarefa tarefa = db.Tarefa.Single(t => t.Id == id);
            return View(tarefa);
        }

        //
        // GET: /Tarefa/Create

        public ActionResult Create(int? id3, int? id2, int? id)
        {
            
            ViewBag.IdTarefaGrupo = new SelectList(db.TarefaGrupo, "Id", "Nome",id3);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Username", id2);
            return View();
        }

        //
        // POST: /Tarefa/Create

        [HttpPost]
        public ActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Tarefa.AddObject(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            
            ViewBag.IdTarefaGrupo = new SelectList(db.TarefaGrupo, "Id", "Nome", tarefa.IdTarefaGrupo);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Username", tarefa.IdUsuario);
            return View(tarefa);
        }
        
        //
        // GET: /Tarefa/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tarefa tarefa = db.Tarefa.Single(t => t.Id == id);
           
            ViewBag.IdTarefaGrupo = new SelectList(db.TarefaGrupo, "Id", "Nome", tarefa.IdTarefaGrupo);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Username", tarefa.IdUsuario);
            return View(tarefa);
        }

        //
        // POST: /Tarefa/Edit/5

        [HttpPost]
        public ActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Tarefa.Attach(tarefa);
                db.ObjectStateManager.ChangeObjectState(tarefa, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.IdTarefaGrupo = new SelectList(db.TarefaGrupo, "Id", "Nome", tarefa.IdTarefaGrupo);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Username", tarefa.IdUsuario);
            return View(tarefa);
        }

        //
        // GET: /Tarefa/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tarefa tarefa = db.Tarefa.Single(t => t.Id == id);
            return View(tarefa);
        }

        //
        // POST: /Tarefa/Delete/5

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tarefa tarefa = db.Tarefa.Single(t => t.Id == id);
            db.Tarefa.DeleteObject(tarefa);
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