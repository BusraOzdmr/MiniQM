using System;
using AutoMapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniQM.Admin.Models;
using MiniQM.Data;
using MiniQM.Model;
using MiniQM.Service;

namespace MiniQM.Admin.Controllers
{
    [Authorize]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService companyService;

        public CompaniesController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        public CompaniesController()
        {

        }
        // GET: Companies
        public ActionResult Index()
        {
            var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(companyService.GetAll());
            return View(companies);           

        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompanyViewModel company = Mapper.Map<CompanyViewModel>(companyService.Get(id.Value));

            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Company company)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Company>(company);
                companyService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyViewModel company = Mapper.Map<CompanyViewModel>(companyService.Get(id.Value));
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Company company)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Company>(company);
                companyService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyViewModel company = Mapper.Map<CompanyViewModel>(companyService.Get(id.Value));
            if (company == null)
            {
                return HttpNotFound();
            }
            
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = Mapper.Map<Company>(companyService.Get(id));
            company.IsDeleted = true;
            companyService.Update(company);
            return RedirectToAction("Index");
        }

        
    }
}
