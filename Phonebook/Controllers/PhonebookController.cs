using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phonebook.Models;

namespace Phonebook.Controllers
{
   
    public class PhonebookController : Controller
    {
        private static List<PhonebookModel> _Phonebook;
        public static List<PhonebookModel> Phonebook
        {
            get
            {
                if (_Phonebook == null)
                {
                    _Phonebook = new List<PhonebookModel>();
                    _Phonebook.Add(new PhonebookModel
                                       {
                                           FirstName = "Gerry",
                                           LastName = "Branch",
                                           PhoneNumber = "405-777-9311",
                                           Email = "gerry.branch@gmail.com"
                                       });

                }
                return _Phonebook;
            }
            set { _Phonebook = value; }
        }

        public ActionResult Index()
        {
           return View(Phonebook);
        }

        public ActionResult Details(string phoneNum)
        {
            return View(_Phonebook.Where(entry => entry.PhoneNumber == phoneNum).FirstOrDefault());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PhonebookModel model)
        {
            try
            {
                _Phonebook.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string phoneNum)
        {
            return View(_Phonebook.Where(entry => entry.PhoneNumber == phoneNum).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(string phoneNum, PhonebookModel model)
        {
            try
            {
                _Phonebook.Where(entry => entry.PhoneNumber == phoneNum).ToList().ForEach(result =>
                                                                                              {
                                                                                                  result.FirstName = model.FirstName;
                                                                                                  result.LastName = model.LastName;
                                                                                                  result.Email = model.Email;
                                                                                                  result.PhoneNumber = model.PhoneNumber;
                                                                                              });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string phoneNum)
        {
            try
            {
                _Phonebook.RemoveAll(entry => entry.PhoneNumber == phoneNum);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
