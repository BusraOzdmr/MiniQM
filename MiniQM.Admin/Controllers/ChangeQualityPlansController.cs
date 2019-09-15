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
    public class ChangeQualityPlansController : Controller
    {
        private readonly IQualityPlanService qualityPlanService;
        private readonly IMaterialService materialService;
        private readonly ICriterionService criterionService;
        private readonly ICertificateService certificateService;
        private readonly IUnitService unitService;
        private readonly IChangeQualityPlanService changeQualityPlanService;
        private readonly IProductionEquipmentService productionEquipmentService;
        public ChangeQualityPlansController(IChangeQualityPlanService changeQualityPlanService, IUnitService unitService, ICertificateService certificateService, ICriterionService criterionService, IMaterialService materialService, IQualityPlanService qualityPlanService, IProductionEquipmentService productionEquipmentService)
        {
            this.changeQualityPlanService = changeQualityPlanService;
            this.qualityPlanService = qualityPlanService;
            this.criterionService = criterionService;
            this.certificateService = certificateService;
            this.unitService = unitService;
            this.materialService = materialService;
            this.productionEquipmentService = productionEquipmentService;
        }
        
        // GET: ChangeQualityPlans
        public ActionResult Index()
        {
            var changeQualityPlans = Mapper.Map<IEnumerable<ChangeQualityPlanViewModel>>(changeQualityPlanService.GetAll());
            return View(changeQualityPlans);
        }

        // GET: ChangeQualityPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeQualityPlanViewModel changeQualityPlan = Mapper.Map<ChangeQualityPlanViewModel>(changeQualityPlanService.Get(id.Value));
            if (changeQualityPlan == null)
            {
                return HttpNotFound();
            }
            return View(changeQualityPlan);
        }

        // GET: ChangeQualityPlans/Create
        public ActionResult Create()
        {
            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name");
            ViewBag.CriterionId = new SelectList(criterionService.GetAll(), "Id", "Name");
            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Id");
            ViewBag.QualityPlanId = new SelectList(qualityPlanService.GetAll(), "Id", "Id");
            ViewBag.UnitId = new SelectList(unitService.GetAll(), "Id", "Name");
            ViewBag.ProductionEquipmentId = new SelectList(productionEquipmentService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: ChangeQualityPlans/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QualityPlanId,MaterialId,CriterionId,IsDynamic,IsDetailed,UnitId,CertificateId,Level,Contrafactor,AQL,ProductionEquipmentName,NominalSize,MaxSize,MinSize,PurchasingControl,ProductionControl,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] ChangeQualityPlan changeQualityPlan)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<ChangeQualityPlan>(changeQualityPlan);
                changeQualityPlanService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name", changeQualityPlan.CertificateId);
            ViewBag.CriterionId = new SelectList(criterionService.GetAll(), "Id", "Name", changeQualityPlan.CriterionId);
            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Name", changeQualityPlan.MaterialId);
            ViewBag.QualityPlanId = new SelectList(qualityPlanService.GetAll(), "Id", "Description", changeQualityPlan.QualityPlanId);
            ViewBag.UnitId = new SelectList(unitService.GetAll(), "Id", "Name", changeQualityPlan.UnitId);
            ViewBag.ProductionEquipmentId = new SelectList(productionEquipmentService.GetAll(), "Id", "Name", changeQualityPlan.ProductionEquipmentId);
            return View(changeQualityPlan);
        }

        // GET: ChangeQualityPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeQualityPlanViewModel changeQualityPlan = Mapper.Map<ChangeQualityPlanViewModel>(changeQualityPlanService.Get(id.Value));
            if (changeQualityPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name", changeQualityPlan.CertificateId); ;
            ViewBag.CriterionId = new SelectList(criterionService.GetAll(), "Id", "Name", changeQualityPlan.CriterionId);
            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Name", changeQualityPlan.MaterialId);
            ViewBag.QualityPlanId = new SelectList(qualityPlanService.GetAll(), "Id", "Description", changeQualityPlan.QualityPlanId);
            ViewBag.UnitId = new SelectList(unitService.GetAll(), "Id", "Name", changeQualityPlan.UnitId);
            ViewBag.ProductionEquipmentId = new SelectList(productionEquipmentService.GetAll(), "Id", "Name", changeQualityPlan.ProductionEquipmentId);
            return View(changeQualityPlan);
        }

        // POST: ChangeQualityPlans/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QualityPlanId,MaterialId,CriterionId,IsDynamic,IsDetailed,UnitId,CertificateId,Level,Contrafactor,AQL,ProductionEquipmentName,NominalSize,MaxSize,MinSize,PurchasingControl,ProductionControl,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] ChangeQualityPlan changeQualityPlan)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<ChangeQualityPlan>(changeQualityPlan);
                changeQualityPlanService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name", changeQualityPlan.CertificateId);
            ViewBag.CriterionId = new SelectList(certificateService.GetAll(), "Id", "Name", changeQualityPlan.CriterionId);
            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Name", changeQualityPlan.MaterialId);
            ViewBag.QualityPlanId = new SelectList(qualityPlanService.GetAll(), "Id", "Description", changeQualityPlan.QualityPlanId);
            ViewBag.UnitId = new SelectList(unitService.GetAll(), "Id", "Name", changeQualityPlan.UnitId);
            ViewBag.ProductionEquipmentId = new SelectList(productionEquipmentService.GetAll(), "Id", "Name", changeQualityPlan.ProductionEquipmentId);
            return View(changeQualityPlan);
        }

        // GET: ChangeQualityPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeQualityPlanViewModel changeQualityPlan = Mapper.Map<ChangeQualityPlanViewModel>(changeQualityPlanService.Get(id.Value));
            if (changeQualityPlan == null)
            {
                return HttpNotFound();
            }
            return View(changeQualityPlan);
        }

        // POST: ChangeQualityPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChangeQualityPlan changeQualityPlan = Mapper.Map<ChangeQualityPlan>(changeQualityPlanService.Get(id));
            changeQualityPlan.IsDeleted = true;
            changeQualityPlanService.Update(changeQualityPlan);
            return RedirectToAction("Index");
        }

        
    }
}
