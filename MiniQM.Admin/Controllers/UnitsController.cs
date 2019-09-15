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
    public class UnitsController : Controller
    {
        private readonly IUnitService unitService;
        private readonly ILanguageService languageService;
        public UnitsController(IUnitService unitService, ILanguageService languageService)
        {
            this.unitService = unitService;
            this.languageService = languageService;
        }
        // GET: Units
        public ActionResult Index()
        {
            var units = Mapper.Map<IEnumerable<UnitViewModel>>(unitService.GetAll());
            return View(units);
        }

        // GET: Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitViewModel unit = Mapper.Map<UnitViewModel>(unitService.Get(id.Value));
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Units/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code");
            return View();
        }

        // POST: Units/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Name,Factor,Description,UnitCategory,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Unit>(unit);
                unitService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code", unit.LanguageId);
            return View(unit);
        }

        // GET: Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitViewModel unit = Mapper.Map<UnitViewModel>(unitService.Get(id.Value));
            if (unit == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code", unit.LanguageId);
            return View(unit);
        }

        // POST: Units/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Name,Factor,Description,UnitCategory,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Unit>(unit);
                unitService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code", unit.LanguageId);
            return View(unit);
        }

        // GET: Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitViewModel unit = Mapper.Map<UnitViewModel>(unitService.Get(id.Value));
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            Unit unit = Mapper.Map<Unit>(unitService.Get(id));
            unit.IsDeleted = true;
            unitService.Update(unit);
            return RedirectToAction("Index");
        }

       
    }
}
