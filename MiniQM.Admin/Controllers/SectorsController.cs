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
    public class SectorsController : Controller
    {
        private readonly ISectorService sectorService;

        public SectorsController(ISectorService sectorService)
        {
            this.sectorService = sectorService;
        }
        // GET: Sectors
        public ActionResult Index()
        {
            var sectors = Mapper.Map<IEnumerable<SectorViewModel>>(sectorService.GetAll());
            return View(sectors);
        }

        // GET: Sectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectorViewModel sector = Mapper.Map<SectorViewModel>(sectorService.Get(id.Value));
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // GET: Sectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sectors/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Sector>(sector);
                sectorService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(sector);
        }

        // GET: Sectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectorViewModel sector = Mapper.Map<SectorViewModel>(sectorService.Get(id.Value));
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // POST: Sectors/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Sector>(sector);
                sectorService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(sector);
        }

        // GET: Sectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectorViewModel sector = Mapper.Map<SectorViewModel>(sectorService.Get(id.Value));
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // POST: Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sector sector = Mapper.Map<Sector>(sectorService.Get(id));
            sector.IsDeleted = true;
            sectorService.Update(sector);
            return RedirectToAction("Index");
        }

        
    }
}
