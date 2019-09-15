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
    public class FacilitiesController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IFacilityService facilityService;

        public FacilitiesController(ICompanyService companyService, IFacilityService facilityService)
        {
            this.companyService = companyService;
            this.facilityService = facilityService;
        }
        
        // GET: Facilities
        public ActionResult Index()
        {
            var facilities = Mapper.Map<IEnumerable<FacilityViewModel>>(facilityService.GetAll());
            return View(facilities);
        }

        // GET: Facilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacilityViewModel facility = Mapper.Map<FacilityViewModel>(facilityService.Get(id.Value));

            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        // GET: Facilities/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Facilities/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CompanyId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Facility facility)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Facility>(facility);
                facilityService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", facility.CompanyId);
            return View(facility);
        }

        // GET: Facilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacilityViewModel facility = Mapper.Map<FacilityViewModel>(facilityService.Get(id.Value));
            if (facility == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", facility.CompanyId);
            return View(facility);
        }

        // POST: Facilities/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Facility facility)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Facility>(facility);
                facilityService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", facility.CompanyId);
            return View(facility);
        }

        // GET: Facilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacilityViewModel facility = Mapper.Map<FacilityViewModel>(facilityService.Get(id.Value));
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        // POST: Facilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facility facility = Mapper.Map<Facility>(facilityService.Get(id));
            facility.IsDeleted = true;
            facilityService.Update(facility);
            return RedirectToAction("Index");
        }

        
    }
}
