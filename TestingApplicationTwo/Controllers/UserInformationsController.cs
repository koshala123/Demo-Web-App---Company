using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuisnessLogic;
using DataLayer;

namespace TestingApplicationTwo.Controllers
{
    public class UserInformationsController : Controller
    {
         
        private IEmployeeRepo _employeeRepo;
        public UserInformationsController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        // GET: UserInformations
        public ActionResult Index()
        {
            return View(_employeeRepo.GetUserInformations());
        }

        // GET: UserInformations/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View(_employeeRepo.GetUserInformation(id));
        }

        // GET: UserInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountName,DisplayName,Email,Designation,Department,Active,Modefied,Created")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                _employeeRepo.CreateUser(userInformation);
                return RedirectToAction("Index");
            }

            return View(userInformation);
        }

        // GET: UserInformations/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(_employeeRepo.GetUserInformation(id));
        }

        // POST: UserInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountName,DisplayName,Email,Designation,Department,Active,Modefied,Created")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                _employeeRepo.UpdateUser(userInformation);
                return RedirectToAction("Index");
            }
            return View(userInformation);
        }

        // GET: UserInformations/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(_employeeRepo.GetUserInformation(id));
        }

        // POST: UserInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _employeeRepo.DeleteUser(id);
            return RedirectToAction("Index");
        }

        
    }
}
