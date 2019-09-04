using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<Supplier> supplierRepository;
        private readonly IUnitOfWork unitOfWork;
        public SupplierService(IRepository<Supplier> supplierRepository, IUnitOfWork unitOfWork)
        {
            this.supplierRepository = supplierRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return supplierRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = supplierRepository.Get(id);
            if (entity != null)
            {
                supplierRepository.Delete(entity);
            }
        }

        public Supplier Get(int id)
        {
            return supplierRepository.Get(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return supplierRepository.GetAll();
        }

        public void Insert(Supplier supplier)
        {
            supplierRepository.Insert(supplier);
            unitOfWork.SaveChanges();
        }

        public void Update(Supplier supplier)
        {
            supplierRepository.Update(supplier);
            unitOfWork.SaveChanges();
        }
    }

    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        Supplier Get(int id);
        void Insert(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(int id);
        bool Any(int id);
    }
}
