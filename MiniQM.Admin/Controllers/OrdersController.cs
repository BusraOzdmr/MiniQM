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
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IBusinessAreaService businessAreaService;
        private readonly ISupplierService supplierService;
        private readonly IOrderTypeService orderTypeService;
        private readonly IPurchasingDepartmentService purchasingDepartmentService;
        private readonly ICompanyService companyService;
        private readonly IFacilityService facilityService;

        public OrdersController(IOrderService orderService, IBusinessAreaService businessAreaService, ISupplierService supplierService, IOrderTypeService orderTypeService, IPurchasingDepartmentService purchasingDepartmentService, ICompanyService companyService, IFacilityService facilityService)
        {
            this.orderService = orderService;
            this.businessAreaService = businessAreaService;
            this.supplierService = supplierService;
            this.orderTypeService = orderTypeService;
            this.purchasingDepartmentService = purchasingDepartmentService;
            this.companyService = companyService;
            this.facilityService = facilityService;
        }
        // GET: Orders
        public ActionResult Index()
        {
            var orders = Mapper.Map<IEnumerable<OrderViewModel>>(orderService.GetAll());
            return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderViewModel order = Mapper.Map<OrderViewModel>(orderService.Get(id.Value));
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.BusinessAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name");
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name");
            ViewBag.OrderTypeId = new SelectList(orderTypeService.GetAll(), "Id", "Name");
            ViewBag.PurchasingDepartmentId = new SelectList(purchasingDepartmentService.GetAll(), "Id", "Name");
            ViewBag.SupplierId = new SelectList(supplierService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CompanyId,FacilityId,BusinessAreaId,PurchasingDepartmentId,OrderTypeId,OrderDate,SupplierId,Gross,Discount,NetCost,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Order order)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Order>(order);
                orderService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.BusinessAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name", order.BusinessAreaId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", order.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", order.FacilityId);
            ViewBag.OrderTypeId = new SelectList(orderTypeService.GetAll(), "Id", "Name", order.OrderTypeId);
            ViewBag.PurchasingDepartmentId = new SelectList(purchasingDepartmentService.GetAll(), "Id", "Name", order.PurchasingDepartmentId);
            ViewBag.SupplierId = new SelectList(supplierService.GetAll(), "Id", "Name", order.SupplierId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderViewModel order = Mapper.Map<OrderViewModel>(orderService.Get(id.Value));
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name", order.BusinessAreaId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", order.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", order.FacilityId);
            ViewBag.OrderTypeId = new SelectList(orderTypeService.GetAll(), "Id", "Name", order.OrderTypeId);
            ViewBag.PurchasingDepartmentId = new SelectList(purchasingDepartmentService.GetAll(), "Id", "Name", order.PurchasingDepartmentId);
            ViewBag.SupplierId = new SelectList(supplierService.GetAll(), "Id", "Name", order.SupplierId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CompanyId,FacilityId,BusinessAreaId,PurchasingDepartmentId,OrderTypeId,OrderDate,SupplierId,Gross,Discount,NetCost,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Order order)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Order>(order);
                orderService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.BusinessAreaId = new SelectList(businessAreaService.GetAll(), "Id", "Name", order.BusinessAreaId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", order.CompanyId);
            ViewBag.FacilityId = new SelectList(facilityService.GetAll(), "Id", "Name", order.FacilityId);
            ViewBag.OrderTypeId = new SelectList(orderTypeService.GetAll(), "Id", "Name", order.OrderTypeId);
            ViewBag.PurchasingDepartmentId = new SelectList(purchasingDepartmentService.GetAll(), "Id", "Name", order.PurchasingDepartmentId);
            ViewBag.SupplierId = new SelectList(supplierService.GetAll(), "Id", "Name", order.SupplierId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderViewModel order = Mapper.Map<OrderViewModel>(orderService.Get(id.Value));
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = Mapper.Map<Order>(orderService.Get(id));
            order.IsDeleted = true;
            orderService.Update(order);
            return RedirectToAction("Index");
        }

        
    }
}
