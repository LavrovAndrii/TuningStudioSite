using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TuningStudioSite.Models;
using TuningStudioSite.Models.DbEntities;

namespace TuningStudioSite.Controllers
{
    public class DetailTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DetailTasks
        public ActionResult Index()
        {
            var detailTasks = db.DetailTasks.Include(d => d.Detail).Include(d => d.Task);
            return View(detailTasks.ToList());
        }

        // GET: DetailTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailTask detailTask = db.DetailTasks.Find(id);
            if (detailTask == null)
            {
                return HttpNotFound();
            }
            return View(detailTask);
        }

        // GET: DetailTasks/Create
        public ActionResult Create()
        {
            ViewBag.IdDetail = new SelectList(db.Details, "Id", "NameDetail");
            ViewBag.IdTask = new SelectList(db.Tasks, "Id", "Title");
            return View();
        }

        // POST: DetailTasks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdDetail,IdTask")] DetailTask detailTask)
        {
            if (ModelState.IsValid)
            {
                db.DetailTasks.Add(detailTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDetail = new SelectList(db.Details, "Id", "NameDetail", detailTask.IdDetail);
            ViewBag.IdTask = new SelectList(db.Tasks, "Id", "Title", detailTask.IdTask);
            return View(detailTask);
        }

        // GET: DetailTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailTask detailTask = db.DetailTasks.Find(id);
            if (detailTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDetail = new SelectList(db.Details, "Id", "NameDetail", detailTask.IdDetail);
            ViewBag.IdTask = new SelectList(db.Tasks, "Id", "Title", detailTask.IdTask);
            return View(detailTask);
        }

        // POST: DetailTasks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdDetail,IdTask")] DetailTask detailTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDetail = new SelectList(db.Details, "Id", "NameDetail", detailTask.IdDetail);
            ViewBag.IdTask = new SelectList(db.Tasks, "Id", "Title", detailTask.IdTask);
            return View(detailTask);
        }

        // GET: DetailTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailTask detailTask = db.DetailTasks.Find(id);
            if (detailTask == null)
            {
                return HttpNotFound();
            }
            return View(detailTask);
        }

        // POST: DetailTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailTask detailTask = db.DetailTasks.Find(id);
            db.DetailTasks.Remove(detailTask);
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
