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
    public class PositionsController : Controller
    {
        private readonly IDepartmentService departmentService;
        private readonly IPositionService positionService;

        public PositionsController(IDepartmentService departmentService, IPositionService positionService)
        {
            this.departmentService = departmentService;
            this.positionService = positionService;
        }

        // GET: Positions
        public ActionResult Index()
        {
            var positions = Mapper.Map<IEnumerable<PositionViewModel>>(positionService.GetAll());
            return View(positions);
        }

        // GET: Positions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionViewModel position = Mapper.Map<PositionViewModel>(positionService.Get(id.Value));
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Positions/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DepartmentId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Position position)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Position>(position);
                positionService.Insert(entity);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name");
            return View(position);
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionViewModel position = Mapper.Map<PositionViewModel>(positionService.Get(id.Value));
            if (position == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name");
            return View(position);
        }

        // POST: Positions/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DepartmentId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Position position)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Position>(position);
                positionService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name");
            return View(position);
        }

        // GET: Positions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionViewModel position = Mapper.Map<PositionViewModel>(positionService.Get(id.Value));
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = Mapper.Map<Position>(positionService.Get(id));
            position.IsDeleted = true;
            positionService.Update(position);
            return RedirectToAction("Index");        }

       
    }
}
