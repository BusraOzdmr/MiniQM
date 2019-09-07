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
    public class OrderTypesController : Controller
    {
        private readonly IOrderTypeService orderTypeService;

        public OrderTypesController(IOrderTypeService orderTypeService)
        {
            this.orderTypeService = orderTypeService;
        }

        // GET: OrderTypes
        public ActionResult Index()
        {
            var orderTypes = Mapper.Map<IEnumerable<OrderTypeViewModel>>(orderTypeService.GetAll());
            return View(orderTypes);
        }

        // GET: OrderTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTypeViewModel orderType = Mapper.Map<OrderTypeViewModel>(orderTypeService.Get(id.Value));
            if (orderType == null)
            {
                return HttpNotFound();
            }
            return View(orderType);
        }

        // GET: OrderTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderTypes/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TypeCode,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] OrderType orderType)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<OrderType>(orderType);
                orderTypeService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(orderType);
        }

        // GET: OrderTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTypeViewModel orderType = Mapper.Map<OrderTypeViewModel>(orderTypeService.Get(id.Value));
            if (orderType == null)
            {
                return HttpNotFound();
            }
            return View(orderType);
        }

        // POST: OrderTypes/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TypeCode,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] OrderType orderType)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<OrderType>(orderType);
                orderTypeService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(orderType);
        }

        // GET: OrderTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTypeViewModel orderType = Mapper.Map<OrderTypeViewModel>(orderTypeService.Get(id.Value));
            if (orderType == null)
            {
                return HttpNotFound();
            }
            return View(orderType);
        }

        // POST: OrderTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orderTypeService.Delete(id);
            return RedirectToAction("Index");
        }       
    }
}
