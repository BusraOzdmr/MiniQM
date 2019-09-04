using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class PurchasingDepartmentService : IPurchasingDepartmentService
    {
        private readonly IRepository<PurchasingDepartment> purchasingDepartmentRepository;
        private readonly IUnitOfWork unitOfWork;
        public PurchasingDepartmentService(IRepository<PurchasingDepartment> purchasingDepartmentRepository, IUnitOfWork unitOfWork)
        {
            this.purchasingDepartmentRepository = purchasingDepartmentRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return purchasingDepartmentRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = purchasingDepartmentRepository.Get(id);
            if (entity != null)
            {
                purchasingDepartmentRepository.Delete(entity);
            }
        }

        public PurchasingDepartment Get(int id)
        {
            return purchasingDepartmentRepository.Get(id);
        }

        public IEnumerable<PurchasingDepartment> GetAll()
        {
            return purchasingDepartmentRepository.GetAll();
        }

        public void Insert(PurchasingDepartment purchasingDepartment)
        {
            purchasingDepartmentRepository.Insert(purchasingDepartment);
            unitOfWork.SaveChanges();
        }

        public void Update(PurchasingDepartment purchasingDepartment)
        {
            purchasingDepartmentRepository.Update(purchasingDepartment);
            unitOfWork.SaveChanges();
        }
    }

    public interface IPurchasingDepartmentService
    {
        IEnumerable<PurchasingDepartment> GetAll();
        PurchasingDepartment Get(int id);
        void Insert(PurchasingDepartment purchasingDepartment);
        void Update(PurchasingDepartment purchasingDepartment);
        void Delete(int id);
        bool Any(int id);
    }
}
