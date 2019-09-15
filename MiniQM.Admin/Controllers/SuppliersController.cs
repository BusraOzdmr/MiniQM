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
    public class SuppliersController : Controller
    {
        private readonly ISupplierService supplierService;
        private readonly IBusinessAreaService businessAreaService;
        private readonly ICompanyService companyService;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly ISectorService sectorService;

        public SuppliersController(ISupplierService supplierService, IBusinessAreaService businessAreaService, ICompanyService companyService, ICountryService countryService, ICityService cityService, ISectorService sectorService)
        {
            this.supplierService = supplierService;
            this.businessAreaService = businessAreaService;
            this.companyService = companyService;
            this.countryService = countryService;
            this.cityService = cityService;
            this.sectorService = sectorService;
        }
        // GET: Suppliers
        public ActionResult Index()
        {
            var suppliers = Mapper.Map<IEnumerable<SupplierViewModel>>(supplierService.GetAll());
            return View(suppliers);
        }

        // GET: Suppliers/Details/5
        [HttpPost]
        public ActionResult GetCities(int countryId)
        {
            var cities = Mapper.Map<IEnumerable<CityViewModel>>(cityService.GetAllByCountryId(countryId));
            return Json(cities);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierViewModel supplier = Mapper.Map<SupplierViewModel>(supplierService.Get(id.Value));
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            ViewBag.BusinessAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name");
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            ViewBag.SectorId = new SelectList(sectorService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Suppliers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,Name,BusinessAreaId,SectorId,CountryId,CityId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Supplier>(supplier);
                supplierService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.BusinessAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name", supplier.BusinessAreaId);
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", supplier.CityId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", supplier.CompanyId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", supplier.CountryId);
            ViewBag.SectorId = new SelectList(sectorService.GetAll(), "Id", "Name", supplier.SectorId);
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierViewModel supplier = Mapper.Map<SupplierViewModel>(supplierService.Get(id.Value));
            if (supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name", supplier.BusinessAreaId);
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", supplier.CityId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", supplier.CompanyId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", supplier.CountryId);
            ViewBag.SectorId = new SelectList(sectorService.GetAll(), "Id", "Name", supplier.SectorId);
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyId,Name,BusinessAreaId,SectorId,CountryId,CityId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Supplier>(supplier);
                supplierService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.BusinessAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name", supplier.BusinessAreaId);
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", supplier.CityId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", supplier.CompanyId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", supplier.CountryId);
            ViewBag.SectorId = new SelectList(sectorService.GetAll(), "Id", "Name", supplier.SectorId);
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierViewModel supplier = Mapper.Map<SupplierViewModel>(supplierService.Get(id.Value));
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = Mapper.Map<Supplier>(supplierService.Get(id));
            supplier.IsDeleted = true;
            supplierService.Update(supplier);
            return RedirectToAction("Index");
        }

        
    }
}
