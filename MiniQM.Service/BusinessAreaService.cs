using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class BusinessAreaService : IBusinessAreaService
    {
        private readonly IRepository<BusinessArea> businessAreaRepository;
        private readonly IUnitOfWork unitOfWork;
        public BusinessAreaService(IRepository<BusinessArea> businessAreaRepository, IUnitOfWork unitOfWork)
        {
            this.businessAreaRepository = businessAreaRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return businessAreaRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = businessAreaRepository.Get(id);
            if (entity != null)
            {
                businessAreaRepository.Delete(entity);
            }
        }

        public BusinessArea Get(int id)
        {
            return businessAreaRepository.Get(id);
        }

        public IEnumerable<BusinessArea> GetAll()
        {
            return businessAreaRepository.GetAll();
        }

        public void Insert(BusinessArea businessArea)
        {
            businessAreaRepository.Insert(businessArea);
            unitOfWork.SaveChanges();
        }

        public void Update(BusinessArea businessArea)
        {
            businessAreaRepository.Update(businessArea);
            unitOfWork.SaveChanges();
        }
    }

    public interface IBusinessAreaService
    {
        IEnumerable<BusinessArea> GetAll();
        BusinessArea Get(int id);
        void Insert(BusinessArea businessArea);
        void Update(BusinessArea businessArea);
        void Delete(int id);
        bool Any(int id);
    }
}
