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
    public class QualityPlansController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IFacilityService facilityService;
        private readonly IMaterialService materialService;
        private readonly IQualityPlanService qualityPlanService;

        public QualityPlansController(ICompanyService companyService, IFacilityService facilityService, IMaterialService materialService, IQualityPlanService qualityPlanService)
        {
            this.companyService = companyService;
            this.facilityService = facilityService;
            this.materialService = materialService;
            this.qualityPlanService = qualityPlanService;
        }
        // GET: QualityPlans
        public ActionResult Index()
        {
            var qualityPlans = Mapper.Map<IEnumerable<QualityPlanViewModel>>(qualityPlanService.GetAll());
            return View(qualityPlans);
        }
        [HttpPost]
        public ActionResult GetFacilities(int companyId)
        {
            var facilities = Mapper.Map<IEnumerable<FacilityViewModel>>(facilityService.GetAllByCompanyId(companyId));
            return Json(facilities);
        }
        // GET: QualityPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityPlanViewModel qualityPlan = Mapper.Map<QualityPlanViewModel>(qualityPlanService.Get(id.Value));
            if (qualityPlan == null)
            {
                return HttpNotFound();
            }
            return View(qualityPlan);
        }

        // GET: QualityPlans/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name");
            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: QualityPlans/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,FacilityId,MaterialId,Description,StartDate,ClosedDate,IsProcess,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] QualityPlan qualityPlan)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<QualityPlan>(qualityPlan);
                qualityPlanService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", qualityPlan.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", qualityPlan.FacilityId);
            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Name", qualityPlan.MaterialId);
            return View(qualityPlan);
        }

        // GET: QualityPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityPlanViewModel qualityPlan = Mapper.Map<QualityPlanViewModel>(qualityPlanService.Get(id.Value));
            if (qualityPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", qualityPlan.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", qualityPlan.FacilityId);
            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Name", qualityPlan.MaterialId);
            return View(qualityPlan);
        }

        // POST: QualityPlans/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyId,FacilityId,MaterialId,Description,StartDate,ClosedDate,IsProcess,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] QualityPlan qualityPlan)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<QualityPlan>(qualityPlan);
                qualityPlanService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", qualityPlan.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", qualityPlan.FacilityId);
            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Name", qualityPlan.MaterialId);
            return View(qualityPlan);
        }

        // GET: QualityPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityPlanViewModel qualityPlan = Mapper.Map<QualityPlanViewModel>(qualityPlanService.Get(id.Value));
            if (qualityPlan == null)
            {
                return HttpNotFound();
            }
            return View(qualityPlan);
        }

        // POST: QualityPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QualityPlan qualityPlan = Mapper.Map<QualityPlan>(qualityPlanService.Get(id));
            qualityPlan.IsDeleted = true;
            qualityPlanService.Update(qualityPlan);
            return RedirectToAction("Index");
        }

        
    }
}
