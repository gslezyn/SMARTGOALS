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
    public class ProjetoController : Controller
    {
        private SmartGoalsEntities db = new SmartGoalsEntities();

        public ViewResult Index(int? id)
        {
            var projeto = from p in db.Projeto
                          where p.IdCliente == id || !id.HasValue
                          select p;


            return View(projeto.ToList());
        }

        public ViewResult Details(int id)
        {
            Projeto projeto = db.Projeto.Single(p => p.Id == id);
            return View(projeto);
        }

        public ActionResult Create( int? id)


        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                db.Projeto.AddObject(projeto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", projeto.IdCliente);
            return View(projeto);
        }

        public ActionResult Edit(int id)
        {
            Projeto projeto = db.Projeto.Single(p => p.Id == id);
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", projeto.IdCliente);
            return View(projeto);
        }

        [HttpPost]
        public ActionResult Edit(Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                db.Projeto.Attach(projeto);
                db.ObjectStateManager.ChangeObjectState(projeto, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", projeto.IdCliente);
            return View(projeto);
        }

        public ActionResult Delete(int id)
        {
            Projeto projeto = db.Projeto.Single(p => p.Id == id);
            return View(projeto);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Projeto projeto = db.Projeto.Single(p => p.Id == id);
            db.Projeto.DeleteObject(projeto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        #region [ TAREFAS GRUPOS ]

        [HttpPost]
        public JsonResult NovoGrupo()
        {
            TarefaGrupo tg = new TarefaGrupo();
            tg.Id = int.Parse(Request.Form["Id"]);
            tg.Nome = Request.Form["NomeGrupo"];
            db.TarefaGrupo.AddObject(tg);
            db.ObjectStateManager.ChangeObjectState(tg, EntityState.Added);
            db.SaveChanges();

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Retorna todos os grupos de um determinado Projeto
        /// </summary>
        /// <param name="id">Identificação do Projeto</param>
        /// <returns>Objeto JSON</returns>
        //public JsonResult ObterGrupos(int? id)
        //{
        //    if (!id.HasValue) return Json("{Id} must have a value!", JsonRequestBehavior.AllowGet);

        //    var jResult = from g in db.TarefaGrupo.Include("Tarefa")
        //                  where g.IdProjeto == id
        //                  select new
        //                  {
        //                      id = g.Id,
        //                      pai = g.IdTarefaGrupo,
        //                      tarefa = new { }
        //                  };

        //    return Json(jResult, JsonRequestBehavior.AllowGet);
        //}


        #endregion
    }
}