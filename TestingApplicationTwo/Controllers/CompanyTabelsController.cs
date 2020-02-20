using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuisnessLogic;
using BuisnessLogic.DTO;
using DataLayer;

namespace TestingApplicationTwo.Controllers
{
    public class CompanyTabelsController : Controller
    {
        private TechOneSanjSecondEntities db = new TechOneSanjSecondEntities();
        private ICompanyTable _companyTablesRepo;
        public CompanyTabelsController(ICompanyTable companyTablesRepo)
        {
            _companyTablesRepo = companyTablesRepo;
        }
        // GET: CompanyTabels
        public ActionResult Index()
        {
            List<CompanyTableDTO> viewData = _companyTablesRepo.GetCompanyTables();
            return View(viewData);
        }

        // GET: CompanyTabels/Details/5
        public ActionResult Details(int? id)
        {
            CompanyTableDTO viewData = _companyTablesRepo.GetCompanyTabel(id.GetValueOrDefault());
            return View(viewData);
        }

        // GET: CompanyTabels/Create
        public ActionResult Create()
        {
            ViewBag.Status = new SelectList(db.Status, "Id", "Name");
            ViewBag.RequestName = new SelectList(db.UserInformations, "Id", "AccountName");
            return View();
        }

        // POST: CompanyTabels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyName,SystemName,IssueType,className,MethodName,DateTime,RequestNumber,RequestName,Status,Comment,error,Active")] CompanyTabel companyTabel)
        {
            _companyTablesRepo.CreateCompany(companyTabel);
            return RedirectToAction("Index");
        }

        // GET: CompanyTabels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTableDTO viewData = _companyTablesRepo.GetCompanyTabel(id.GetValueOrDefault());
            
            ViewBag.Status = new SelectList(db.Status, "Id", "Name", viewData.Status);
            ViewBag.RequestName = new SelectList(db.UserInformations, "Id", "AccountName", viewData.RequestName);
            return View(viewData);
        }

        // POST: CompanyTabels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,SystemName,IssueType,className,MethodName,DateTime,RequestNumber,RequestName,Status,Comment,error,Active")] CompanyTabel companyTabel)
        {
            _companyTablesRepo.UpdateCompany(companyTabel);
            return RedirectToAction("Index");
        }

        // GET: CompanyTabels/Delete/5
        public ActionResult Delete(int? id)
        {
            CompanyTableDTO viewData = _companyTablesRepo.GetCompanyTabel(id.GetValueOrDefault());
            return View(viewData);
        }

        // POST: CompanyTabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleteUser = _companyTablesRepo.DeleteCompany(id);
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
