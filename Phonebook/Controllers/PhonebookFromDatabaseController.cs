using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phonebook.Models;

namespace Phonebook.Controllers
{
    public class PhonebookFromDatabaseController : Controller
    {
        private PhonebookEntriesEntities db = new PhonebookEntriesEntities();

        //
        // GET: /Phonebook2/

        public ActionResult Index()
        {
            var entries = db.Phonebook.ToList();
            return View(entries);
        }

        //
        // GET: /Phonebook2/Details/5

        public ActionResult Details(int id = 0)
        {
            PhonebookModel phonebookmodel = db.Phonebook.Find(id);
            if (phonebookmodel == null)
            {
                return HttpNotFound();
            }
            return View(phonebookmodel);
        }

        //
        // GET: /Phonebook2/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Phonebook2/Create

        [HttpPost]
        public ActionResult Create(PhonebookModel phonebookmodel)
        {
            if (ModelState.IsValid)
            {
                db.Phonebook.Add(phonebookmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phonebookmodel);
        }

        //
        // GET: /Phonebook2/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PhonebookModel phonebookmodel = db.Phonebook.Find(id);
            if (phonebookmodel == null)
            {
                return HttpNotFound();
            }
            return View(phonebookmodel);
        }

        //
        // POST: /Phonebook2/Edit/5

        [HttpPost]
        public ActionResult Edit(PhonebookModel phonebookmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phonebookmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phonebookmodel);
        }

        //
        // GET: /Phonebook2/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PhonebookModel phonebookmodel = db.Phonebook.Find(id);
            if (phonebookmodel == null)
            {
                return HttpNotFound();
            }
            return View(phonebookmodel);
        }

        //
        // POST: /Phonebook2/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PhonebookModel phonebookmodel = db.Phonebook.Find(id);
            db.Phonebook.Remove(phonebookmodel);
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