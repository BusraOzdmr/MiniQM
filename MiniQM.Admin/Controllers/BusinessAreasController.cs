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
    public class BusinessAreasController : Controller
    {
        private readonly IBusinessAreaService businessAreaService ;

        public BusinessAreasController(IBusinessAreaService businessAreaService)
        {
            this.businessAreaService = businessAreaService;
        }
        // GET: BusinessAreas
        public ActionResult Index()
        {
            var businessAreas = Mapper.Map<IEnumerable<BusinessAreaViewModel>>(businessAreaService.GetAll());
            return View(businessAreas);
        }

        // GET: BusinessAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessAreaViewModel businessArea = Mapper.Map<BusinessAreaViewModel>(businessAreaService.Get(id.Value));
            if (businessArea == null)
            {
                return HttpNotFound();
            }
            return View(businessArea);
        }

        // GET: BusinessAreas/Create
        public ActionResult Create()
        {
            ViewBag.MainAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: BusinessAreas/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,MainAreaId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] BusinessArea businessArea)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<BusinessArea>(businessArea);
                businessAreaService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.MainAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name", businessArea.MainAreaId);
            return View(businessArea);
        }

        // GET: BusinessAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessAreaViewModel businessArea = Mapper.Map<BusinessAreaViewModel>(businessAreaService.Get(id.Value));
            if (businessArea == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name", businessArea.MainAreaId);
            return View(businessArea);
        }

        // POST: BusinessAreas/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,MainAreaId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] BusinessArea businessArea)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<BusinessArea>(businessArea);
                businessAreaService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.MainAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name", businessArea.MainAreaId);
            return View(businessArea);
        }

        // GET: BusinessAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessAreaViewModel businessArea = Mapper.Map<BusinessAreaViewModel>(businessAreaService.Get(id.Value));
            if (businessArea == null)
            {
                return HttpNotFound();
            }
            return View(businessArea);
        }

        // POST: BusinessAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            businessAreaService.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
