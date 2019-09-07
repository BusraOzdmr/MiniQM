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
    public class StockLocationsController : Controller
    {
        private readonly IStockLocationService stockLocationService;
        private readonly ICompanyService companyService;
        private readonly IFacilityService facilityService;

        public StockLocationsController(IStockLocationService stockLocationService, ICompanyService companyService, IFacilityService facilityService)
        {
            this.stockLocationService = stockLocationService;
            this.companyService = companyService;
            this.facilityService = facilityService;
        }
        // GET: StockLocations
        public ActionResult Index()
        {
            var stockLocations = Mapper.Map<IEnumerable<StockLocationViewModel>>(stockLocationService.GetAll());
            return View(stockLocations);
        }

        // GET: StockLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockLocationViewModel stockLocation = Mapper.Map<StockLocationViewModel>(stockLocationService.Get(id.Value));
            if (stockLocation == null)
            {
                return HttpNotFound();
            }
            return View(stockLocation);
        }

        // GET: StockLocations/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: StockLocations/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CompanyId,FacilityId,Warehouse,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] StockLocation stockLocation)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<StockLocation>(stockLocation);
                stockLocationService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", stockLocation.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", stockLocation.FacilityId);
            return View(stockLocation);
        }

        // GET: StockLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockLocationViewModel stockLocation = Mapper.Map<StockLocationViewModel>(stockLocationService.Get(id.Value));
            if (stockLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", stockLocation.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", stockLocation.FacilityId);
            return View(stockLocation);
        }

        // POST: StockLocations/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CompanyId,FacilityId,Warehouse,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] StockLocation stockLocation)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<StockLocation>(stockLocation);
                stockLocationService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", stockLocation.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", stockLocation.FacilityId);
            return View(stockLocation);
        }

        // GET: StockLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockLocationViewModel stockLocation = Mapper.Map<StockLocationViewModel>(stockLocationService.Get(id.Value));
            if (stockLocation == null)
            {
                return HttpNotFound();
            }
            return View(stockLocation);
        }

        // POST: StockLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stockLocationService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
