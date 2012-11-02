using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartGoals.Models;
using System.Data;

namespace SmartGoals.Controllers
{
    public class TarefaGrupoController : Controller
    {
        private SmartGoalsEntities db = new SmartGoalsEntities();
        //
        // GET: /TarefaGrupo/
        public ViewResult Index(int? id)
        {

            if (id.HasValue)
            {
                var tarefa = db.TarefaGrupo.Where(o => o.IdProjeto == id);
                return View(tarefa.ToList());

            }
            else
            {
                
                return View(db.TarefaGrupo.ToList());
            }
        }


        public ActionResult Create(int? id2,  int? id)
        {

            
            ViewBag.IdProjeto = new SelectList(db.Projeto, "Id", "Nome", id2);
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        public ActionResult Create(TarefaGrupo tarefagrupo)
        {
            if (ModelState.IsValid)
            {
                db.TarefaGrupo.AddObject(tarefagrupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarefagrupo);
        }




        public ActionResult Delete(int id)
        {
            TarefaGrupo tarefa = db.TarefaGrupo.Single(t => t.Id == id);
            return View(tarefa);
        }

        //
        // POST: /Tarefa/Delete/5

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            TarefaGrupo tarefa = db.TarefaGrupo.Single(t => t.Id == id);
            db.TarefaGrupo.DeleteObject(tarefa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            TarefaGrupo tarefa = db.TarefaGrupo.Single(t => t.Id == id);

         
            return View(tarefa);
        }

        //
        // POST: /Tarefa/Edit/5

        [HttpPost]
        public ActionResult Edit(TarefaGrupo tarefa)
        {
            if (ModelState.IsValid)
            {
                db.TarefaGrupo.Attach(tarefa);
                db.ObjectStateManager.ChangeObjectState(tarefa, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarefa);
        }
    }
}
