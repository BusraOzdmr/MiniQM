using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MiniQM.Admin.Models;
using MiniQM.Data;
using MiniQM.Model;
using MiniQM.Service;

namespace MiniQM.Admin.Controllers
{
    public class PurchasingDepartmentsController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IPurchasingDepartmentService purchasingDepartmentService;

        public PurchasingDepartmentsController(ICompanyService companyService, IPurchasingDepartmentService purchasingDepartmentService)
        {
            this.companyService = companyService;
            this.purchasingDepartmentService = purchasingDepartmentService;
        }

        // GET: PurchasingDepartments
        public ActionResult Index()
        {
            var purchasingDepartments = Mapper.Map<IEnumerable<PurchasingDepartmentViewModel>>(purchasingDepartmentService.GetAll());
            return View(purchasingDepartments);
        }

        // GET: PurchasingDepartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchasingDepartmentViewModel purchasingDepartment = Mapper.Map<PurchasingDepartmentViewModel>(purchasingDepartmentService.Get(id.Value));
            if (purchasingDepartment == null)
            {
                return HttpNotFound();
            }
            return View(purchasingDepartment);
        }

        // GET: PurchasingDepartments/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: PurchasingDepartments/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] PurchasingDepartment purchasingDepartment)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<PurchasingDepartment>(purchasingDepartment);
                purchasingDepartmentService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", purchasingDepartment.CompanyId);
            return View(purchasingDepartment);
        }

        // GET: PurchasingDepartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchasingDepartmentViewModel purchasingDepartment = Mapper.Map<PurchasingDepartmentViewModel>(purchasingDepartmentService.Get(id.Value));
            if (purchasingDepartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", purchasingDepartment.CompanyId);
            return View(purchasingDepartment);
        }

        // POST: PurchasingDepartments/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyId,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] PurchasingDepartment purchasingDepartment)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<PurchasingDepartment>(purchasingDepartment);
                purchasingDepartmentService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", purchasingDepartment.CompanyId);
            return View(purchasingDepartment);
        }

        // GET: PurchasingDepartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchasingDepartmentViewModel purchasingDepartment = Mapper.Map<PurchasingDepartmentViewModel>(purchasingDepartmentService.Get(id.Value));
            if (purchasingDepartment == null)
            {
                return HttpNotFound();
            }
            return View(purchasingDepartment);
        }

        // POST: PurchasingDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            purchasingDepartmentService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
