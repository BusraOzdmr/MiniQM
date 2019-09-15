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
    public class SystemUsersController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IDepartmentService departmentService;
        private readonly IPositionService positionService;
        private readonly ISystemUserService systemUserService;

        public SystemUsersController(ICompanyService companyService, IDepartmentService departmentService, IPositionService positionService, ISystemUserService systemUserService)
        {
            this.companyService = companyService;
            this.departmentService = departmentService;
            this.positionService = positionService;
            this.systemUserService = systemUserService;
        }
        // GET: SystemUsers
        public ActionResult Index()
        {
            var systemUsers = Mapper.Map<IEnumerable<SystemUserViewModel>>(systemUserService.GetAll());
            return View(systemUsers);
        }

        // GET: SystemUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemUserViewModel systemUser = Mapper.Map<SystemUserViewModel>(systemUserService.Get(id.Value));
            if (systemUser == null)
            {
                return HttpNotFound();
            }
            return View(systemUser);
        }

        // GET: SystemUsers/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name");
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: SystemUsers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,ContactNumber,Name,Surname,ContactType,Email,CompanyId,DepartmentId,PositionId,Profile,FilePath,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] SystemUser systemUser)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<SystemUser>(systemUser);
                systemUserService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", systemUser.CompanyId);
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", systemUser.DepartmentId);
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name", systemUser.PositionId);
            return View(systemUser);
        }

        // GET: SystemUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemUserViewModel systemUser = Mapper.Map<SystemUserViewModel>(systemUserService.Get(id.Value));
            if (systemUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", systemUser.CompanyId);
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", systemUser.DepartmentId);
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name", systemUser.PositionId);
            return View(systemUser);
        }

        // POST: SystemUsers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,ContactNumber,Name,Surname,ContactType,Email,CompanyId,DepartmentId,PositionId,Profile,FilePath,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] SystemUser systemUser)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<SystemUser>(systemUser);
                systemUserService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", systemUser.CompanyId);
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", systemUser.DepartmentId);
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name", systemUser.PositionId);
            return View(systemUser);
        }

        // GET: SystemUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemUserViewModel systemUser = Mapper.Map<SystemUserViewModel>(systemUserService.Get(id.Value));
            if (systemUser == null)
            {
                return HttpNotFound();
            }
            return View(systemUser);
        }

        // POST: SystemUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SystemUser systemUser = Mapper.Map<SystemUser>(systemUserService.Get(id));
            systemUser.IsDeleted = true;
            systemUserService.Update(systemUser);
            return RedirectToAction("Index");
        }

        
    }
}
