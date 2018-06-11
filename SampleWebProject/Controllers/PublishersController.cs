using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleWebProject.Abstractions;
using SampleWebProject.Models;

namespace SampleWebProject.Controllers
{
    public class PublishersController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IRepo<Publisher> db;
        private readonly ApplicationDbContext _context;

        public PublishersController(IRepo<Publisher> repo)
        {
            db = repo;
        }

        public PublishersController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public PublishersController()
        {

        }

        // GET: Publishers
        public ActionResult Index()
        {
            //return View(db.Publishers.ToList());
            var result = db.GetAll();

            return View(result);
        }

        // GET: Publishers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.FindById(id.Value);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // GET: Publishers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PublisherId,PublisherName,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Add(publisher);
                db.Commit();
                return RedirectToAction("Index");
            }

            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.FindById(id.Value);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PublisherId,PublisherName,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Update(publisher);
                db.Commit();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.FindById(id.Value);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publisher publisher = db.FindById(id);
            db.Remove(publisher);
            db.Commit();
            return RedirectToAction("Index");
        }
    }
}
