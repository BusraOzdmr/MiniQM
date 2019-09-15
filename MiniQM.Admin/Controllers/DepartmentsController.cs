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
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IFacilityService facilityService;
        private readonly IDepartmentService departmentService;

        public DepartmentsController(ICompanyService companyService, IFacilityService facilityService, IDepartmentService departmentService)
        {
            this.companyService = companyService;
            this.facilityService = facilityService;
            this.departmentService = departmentService;
        }

        // GET: Departments
        public ActionResult Index()
        {
            var departments = Mapper.Map<IEnumerable<DepartmentViewModel>>(departmentService.GetAll());
            return View(departments);
        }

        // GET: Departments/Details/5
        [HttpPost]
        public ActionResult GetFacilities(int companyId)
        {
            var facilities = Mapper.Map<IEnumerable<FacilityViewModel>>(facilityService.GetAllByCompanyId(companyId));
            return Json(facilities);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentViewModel department = Mapper.Map<DepartmentViewModel>(departmentService.Get(id.Value));
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Departments/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CompanyId,CompanyName,FacilityId,FacilityName,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Department department)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Department>(department);
                departmentService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", department.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", department.FacilityId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentViewModel department = Mapper.Map<DepartmentViewModel>(departmentService.Get(id.Value));
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", department.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", department.FacilityId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CompanyId,CompanyName,FacilityId,FacilityName,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Department department)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Department>(department);
                departmentService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", department.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", department.FacilityId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentViewModel department = Mapper.Map<DepartmentViewModel>(departmentService.Get(id.Value));
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = Mapper.Map<Department>(departmentService.Get(id));
            department.IsDeleted = true;
            departmentService.Update(department);
            return RedirectToAction("Index");
        }

        
    }
}
