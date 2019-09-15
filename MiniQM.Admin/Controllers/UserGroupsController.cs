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
    public class UserGroupsController : Controller
    {
        private readonly ILanguageService languageService;
        private readonly IUserGroupService userGroupService;
        public UserGroupsController(ILanguageService languageService, IUserGroupService userGroupService)
        {
            this.languageService = languageService;
            this.userGroupService = userGroupService;
        }
        // GET: UserGroups
        public ActionResult Index()
        {
            var userGroups = Mapper.Map<IEnumerable<UserGroupViewModel>>(userGroupService.GetAll());
            return View(userGroups);
        }

        // GET: UserGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroupViewModel userGroup = Mapper.Map<UserGroupViewModel>(userGroupService.Get(id.Value));
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            return View(userGroup);
        }

        // GET: UserGroups/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code");
            return View();
        }

        // POST: UserGroups/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LanguageId,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<UserGroup>(userGroup);
                userGroupService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code", userGroup.LanguageId);
            return View(userGroup);
        }

        // GET: UserGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroupViewModel userGroup = Mapper.Map<UserGroupViewModel>(userGroupService.Get(id.Value));
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code", userGroup.LanguageId);
            return View(userGroup);
        }

        // POST: UserGroups/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LanguageId,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<UserGroup>(userGroup);
                userGroupService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(languageService.GetAll(), "Id", "Code", userGroup.LanguageId);
            return View(userGroup);
        }

        // GET: UserGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroupViewModel userGroup = Mapper.Map<UserGroupViewModel>(userGroupService.Get(id.Value));
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            return View(userGroup);
        }

        // POST: UserGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserGroup userGroup = Mapper.Map<UserGroup>(userGroupService.Get(id));
            userGroup.IsDeleted = true;
            userGroupService.Update(userGroup);
            return RedirectToAction("Index");
        }

        
    }
}
