using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class FacilityService : IFacilityService
    {
        private readonly IRepository<Facility> facilityRepository;
        private readonly IUnitOfWork unitOfWork;
        public bool Any(int id)
        {
            return facilityRepository.Any(x => x.Id == id);
        }
        public FacilityService(IRepository<Facility> facilityRepository, IUnitOfWork unitOfWork)
        {
            this.facilityRepository = facilityRepository;
            this.unitOfWork = unitOfWork;
        }
        public void Delete(int id)
        {
            var entity = facilityRepository.Get(id);
            if (entity != null)
            {
                facilityRepository.Delete(entity);
            }
        }

        public Facility Get(int id)
        {
            return facilityRepository.Get(id);
        }

        public IEnumerable<Facility> GetAll()
        {
            return facilityRepository.GetAll();
        }

        public void Insert(Facility facility)
        {
            facilityRepository.Insert(facility);
            unitOfWork.SaveChanges();
        }

        public void Update(Facility facility)
        {
            facilityRepository.Update(facility);
            unitOfWork.SaveChanges();
        }
    }

    public interface IFacilityService
    {
        IEnumerable<Facility> GetAll();
        Facility Get(int id);
        void Insert(Facility facility);
        void Update(Facility facility);
        void Delete(int id);
        bool Any(int id);
    }
}

