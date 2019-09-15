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
    public class ProductionEquipmentsController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IFacilityService facilityService;
        private readonly ILanguageService languageService;
        private readonly IProductionEquipmentService productionEquipmentService;
        public ProductionEquipmentsController(ICompanyService companyService, IFacilityService facilityService, ILanguageService languageService, IProductionEquipmentService productionEquipmentService)
        {
            this.companyService = companyService;
            this.facilityService = facilityService;
            this.languageService = languageService;
            this.productionEquipmentService = productionEquipmentService;
        }
        // GET: ProductionEquipments
        public ActionResult Index()
        {
            var productionEquipments = Mapper.Map<IEnumerable<ProductionEquipmentViewModel>>(productionEquipmentService.GetAll());
            return View(productionEquipments);
        }
        [HttpPost]
        public ActionResult GetFacilities(int companyId)
        {
            var facilities = Mapper.Map<IEnumerable<FacilityViewModel>>(facilityService.GetAllByCompanyId(companyId));
            return Json(facilities);
        }
        // GET: ProductionEquipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionEquipmentViewModel productionEquipment = Mapper.Map<ProductionEquipmentViewModel>(productionEquipmentService.Get(id.Value));
            if (productionEquipment == null)
            {
                return HttpNotFound();
            }
            return View(productionEquipment);
        }

        // GET: ProductionEquipments/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name");
            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code");
            return View();
        }

        // POST: ProductionEquipments/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LangugeId,CompanyId,FacilityId,Name,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] ProductionEquipment productionEquipment)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<ProductionEquipment>(productionEquipment);
                productionEquipmentService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", productionEquipment.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", productionEquipment.FacilityId);
            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code", productionEquipment.LanguageId);
            return View(productionEquipment);
        }

        // GET: ProductionEquipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionEquipmentViewModel productionEquipment = Mapper.Map<ProductionEquipmentViewModel>(productionEquipmentService.Get(id.Value));
            if (productionEquipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", productionEquipment.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", productionEquipment.FacilityId);
            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code", productionEquipment.LanguageId);
            return View(productionEquipment);
        }

        // POST: ProductionEquipments/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LangugeId,CompanyId,FacilityId,Name,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] ProductionEquipment productionEquipment)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<ProductionEquipment>(productionEquipment);
                productionEquipmentService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", productionEquipment.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", productionEquipment.FacilityId);
            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code", productionEquipment.LanguageId);
            return View(productionEquipment);
        }

        // GET: ProductionEquipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionEquipmentViewModel productionEquipment = Mapper.Map<ProductionEquipmentViewModel>(productionEquipmentService.Get(id.Value));
            if (productionEquipment == null)
            {
                return HttpNotFound();
            }
            return View(productionEquipment);
        }

        // POST: ProductionEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionEquipment productionEquipment = Mapper.Map<ProductionEquipment>(productionEquipmentService.Get(id));
            productionEquipment.IsDeleted = true;
            productionEquipmentService.Update(productionEquipment);
            return RedirectToAction("Index");
        }

        
    }
}
