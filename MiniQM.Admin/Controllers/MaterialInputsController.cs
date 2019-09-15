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
    public class MaterialInputsController : Controller
    {
        private readonly IMaterialInputService materialInputService;
        private readonly IOrderTypeService orderTypeService;
        private readonly IOrderService orderService;
        private readonly IMaterialService materialService;
        private readonly ISupplierService supplierService;
        private readonly IStockLocationService stockLocationService;

        public MaterialInputsController(IMaterialInputService materialInputService, IOrderTypeService orderTypeService, IOrderService orderService, IMaterialService materialService, ISupplierService supplierService, IStockLocationService stockLocationService)
        {
            this.materialInputService = materialInputService;
            this.orderTypeService = orderTypeService;
            this.orderService = orderService;
            this.materialService = materialService;
            this.supplierService = supplierService;
            this.stockLocationService = stockLocationService;
        }
        // GET: MaterialInputs
        public ActionResult Index()
        {
            var materialInputs = Mapper.Map<IEnumerable<MaterialInputViewModel>>(materialInputService.GetAll());
            return View(materialInputs);
        }

        // GET: MaterialInputs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialInputViewModel materialInput = Mapper.Map<MaterialInputViewModel>(materialInputService.Get(id.Value));
            if (materialInput == null)
            {
                return HttpNotFound();
            }
            return View(materialInput);
        }

        // GET: MaterialInputs/Create
        public ActionResult Create()
        {
            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Name");
            ViewBag.OrderId = new SelectList(orderService.GetAll(), "Id", "Name");
            ViewBag.OrderTypeId = new SelectList(orderTypeService.GetAll(), "Id", "Name");
            ViewBag.StockLocationId = new SelectList(stockLocationService.GetAll(), "Id", "Name");
            ViewBag.SupplierId = new SelectList(supplierService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: MaterialInputs/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderTypeId,OrderId,Cost,MaterialId,InputAmount,SampleAmount,MaterialQuality,Returned,SupplierId,StockLocationId,Checked,QualityControlStatus,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] MaterialInput materialInput)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<MaterialInput>(materialInput);
                materialInputService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Name", materialInput.MaterialId);
            ViewBag.OrderId = new SelectList(orderService.GetAll(), "Id", "Name", materialInput.OrderId);
            ViewBag.OrderTypeId = new SelectList(orderTypeService.GetAll(), "Id", "Name", materialInput.OrderTypeId);
            ViewBag.StockLocationId = new SelectList(stockLocationService.GetAll(), "Id", "Name", materialInput.StockLocationId);
            ViewBag.SupplierId = new SelectList(supplierService.GetAll(), "Id", "Name", materialInput.SupplierId);
            return View(materialInput);
        }

        // GET: MaterialInputs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialInputViewModel materialInput = Mapper.Map<MaterialInputViewModel>(materialInputService.Get(id.Value));
            if (materialInput == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Name", materialInput.MaterialId);
            ViewBag.OrderId = new SelectList(orderService.GetAll(), "Id", "Name", materialInput.OrderId);
            ViewBag.OrderTypeId = new SelectList(orderTypeService.GetAll(), "Id", "Name", materialInput.OrderTypeId);
            ViewBag.StockLocationId = new SelectList(stockLocationService.GetAll(), "Id", "Name", materialInput.StockLocationId);
            ViewBag.SupplierId = new SelectList(supplierService.GetAll(), "Id", "Name", materialInput.SupplierId); 
            return View(materialInput);
        }

        // POST: MaterialInputs/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderTypeId,OrderId,Cost,MaterialId,InputAmount,SampleAmount,MaterialQuality,Returned,SupplierId,StockLocationId,Checked,QualityControlStatus,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] MaterialInput materialInput)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<MaterialInput>(materialInput);
                materialInputService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.MaterialId = new SelectList(materialService.GetAll(), "Id", "Name", materialInput.MaterialId);
            ViewBag.OrderId = new SelectList(orderService.GetAll(), "Id", "Name", materialInput.OrderId);
            ViewBag.OrderTypeId = new SelectList(orderTypeService.GetAll(), "Id", "Name", materialInput.OrderTypeId);
            ViewBag.StockLocationId = new SelectList(stockLocationService.GetAll(), "Id", "Name", materialInput.StockLocationId);
            ViewBag.SupplierId = new SelectList(supplierService.GetAll(), "Id", "Name", materialInput.SupplierId);
            return View(materialInput);
        }

        // GET: MaterialInputs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialInputViewModel materialInput = Mapper.Map<MaterialInputViewModel>(materialInputService.Get(id.Value));
            if (materialInput == null)
            {
                return HttpNotFound();
            }
            return View(materialInput);
        }

        // POST: MaterialInputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterialInput materialInput = Mapper.Map<MaterialInput>(materialInputService.Get(id));
            materialInput.IsDeleted = true;
            materialInputService.Update(materialInput);
            return RedirectToAction("Index");
        }

        
    }
}
