using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class ProductionEquipmentService : IProductionEquipmentService
    {
        private readonly IRepository<ProductionEquipment> productionEquipmentRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductionEquipmentService(IRepository<ProductionEquipment> productionEquipmentRepository, IUnitOfWork unitOfWork)
        {
            this.productionEquipmentRepository = productionEquipmentRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return productionEquipmentRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = productionEquipmentRepository.Get(id);
            if (entity != null)
            {
                productionEquipmentRepository.Delete(entity);
            }
        }

        public ProductionEquipment Get(int id)
        {
            return productionEquipmentRepository.Get(id);
        }

        public IEnumerable<ProductionEquipment> GetAll()
        {
            return productionEquipmentRepository.GetAll();
        }

        public void Insert(ProductionEquipment productionEquipment)
        {
            productionEquipmentRepository.Insert(productionEquipment);
            unitOfWork.SaveChanges();
        }

        public void Update(ProductionEquipment productionEquipment)
        {
            productionEquipmentRepository.Update(productionEquipment);
            unitOfWork.SaveChanges();
        }
    }

    public interface IProductionEquipmentService
    {
        IEnumerable<ProductionEquipment> GetAll();
        ProductionEquipment Get(int id);
        void Insert(ProductionEquipment productionEquipment);
        void Update(ProductionEquipment productionEquipment);
        void Delete(int id);
        bool Any(int id);
    }
}
