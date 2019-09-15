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
    public class CriteriaController : Controller
    {
        private readonly ICertificateService certificateService;
        private readonly IProductionEquipmentService productionEquipmentService;
        private readonly ISystemUserService systemUserService;
        private readonly IUnitService unitService;
        private readonly IUserGroupService userGroupService;
        private readonly ICriterionService criterionService;

        public CriteriaController(ICertificateService certificateService, IProductionEquipmentService productionEquipmentService, ISystemUserService systemUserService, IUnitService unitService, IUserGroupService userGroupService, ICriterionService criterionService)
        {
            this.certificateService = certificateService;
            this.productionEquipmentService = productionEquipmentService;
            this.systemUserService = systemUserService;
            this.unitService = unitService;
            this.userGroupService = userGroupService;
            this.criterionService = criterionService;

        }

        // GET: Criteria
        public ActionResult Index()
        {
            var criterions = Mapper.Map<IEnumerable<CriterionViewModel>>(criterionService.GetAll());
            return View(criterions);
        }

        // GET: Criteria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriterionViewModel criterion = Mapper.Map<CriterionViewModel>(criterionService.Get(id.Value));
            if (criterion == null)
            {
                return HttpNotFound();
            }
            return View(criterion);
        }

        // GET: Criteria/Create
        public ActionResult Create()
        {
            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name");
            ViewBag.ProductionEquipmentId = new SelectList(productionEquipmentService.GetAll(), "Id", "Name");
            ViewBag.SystemUserId = new SelectList(systemUserService.GetAll(), "Id", "UserName");
            ViewBag.UnitId = new SelectList(unitService.GetAll(), "Id", "Name");
            ViewBag.UserGroupId = new SelectList(userGroupService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Criteria/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Level,CertificateId,Contrafactor,AQL,IsDynamic,IsDetailed,UnitId,ProductionEquipmentId,SystemUserId,UserGroupId,IsCritical,NominalSize,MaxSize,MinSize,PurchasingControl,ProductionControl,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Criterion criterion)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Criterion>(criterion);
                criterionService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name", criterion.CertificateId);
            ViewBag.ProductionEquipmentId = new SelectList(productionEquipmentService.GetAll(), "Id", "Name", criterion.ProductionEquipmentId);
            ViewBag.SystemUserId = new SelectList(systemUserService.GetAll(), "Id", "UserName", criterion.SystemUserId);
            ViewBag.UnitId = new SelectList(unitService.GetAll(), "Id", "Name", criterion.UnitId);
            ViewBag.UserGroupId = new SelectList(userGroupService.GetAll() , "Id", "Name", criterion.UserGroupId);
            return View(criterion);
        }

        // GET: Criteria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriterionViewModel criterion = Mapper.Map<CriterionViewModel>(criterionService.Get(id.Value));
            if (criterion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name", criterion.CertificateId);
            ViewBag.ProductionEquipmentId = new SelectList(productionEquipmentService.GetAll(), "Id", "Name", criterion.ProductionEquipmentId);
            ViewBag.SystemUserId = new SelectList(systemUserService.GetAll(), "Id", "UserName", criterion.SystemUserId);
            ViewBag.UnitId = new SelectList(unitService.GetAll(), "Id", "Name", criterion.UnitId);
            ViewBag.UserGroupId = new SelectList(userGroupService.GetAll(), "Id", "Name", criterion.UserGroupId);
            return View(criterion);
        }

        // POST: Criteria/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Level,CertificateId,Contrafactor,AQL,IsDynamic,IsDetailed,UnitId,ProductionEquipmentId,SystemUserId,UserGroupId,IsCritical,NominalSize,MaxSize,MinSize,PurchasingControl,ProductionControl,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Criterion criterion)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Criterion>(criterion);
                criterionService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name", criterion.CertificateId);
            ViewBag.ProductionEquipmentId = new SelectList(productionEquipmentService.GetAll(), "Id", "Name", criterion.ProductionEquipmentId);
            ViewBag.SystemUserId = new SelectList(systemUserService.GetAll(), "Id", "UserName", criterion.SystemUserId);
            ViewBag.UnitId = new SelectList(unitService.GetAll(), "Id", "Name", criterion.UnitId);
            ViewBag.UserGroupId = new SelectList(userGroupService.GetAll(), "Id", "Name", criterion.UserGroupId);
            return View(criterion);
        }

        // GET: Criteria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriterionViewModel criterion = Mapper.Map<CriterionViewModel>(criterionService.Get(id.Value));
            if (criterion == null)
            {
                return HttpNotFound();
            }
            return View(criterion);
        }

        // POST: Criteria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Criterion criterion = Mapper.Map<Criterion>(criterionService.Get(id));
            criterion.IsDeleted = true;
            criterionService.Update(criterion);
            return RedirectToAction("Index");
        }
        
    }
}
