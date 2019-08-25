using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{    
    class QualityPlanService : IQualityPlanService
    {
        private readonly IRepository<QualityPlan> qualityPlanRepository;
        private readonly IUnitOfWork unitOfWork;

        public QualityPlanService(IRepository<QualityPlan> qualityPlanRepository, IUnitOfWork unitOfWork)
        {
            this.qualityPlanRepository = qualityPlanRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return qualityPlanRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var qualityPlan = qualityPlanRepository.Get(id);
            if (qualityPlan != null)
            {
                qualityPlanRepository.Delete(qualityPlan);
                unitOfWork.SaveChanges();
            }
        }

        public QualityPlan Get(int id)
        {
            return qualityPlanRepository.Get(id);
        }

        public IEnumerable<QualityPlan> GetAll()
        {
            return qualityPlanRepository.GetAll();
        }

        public void Insert(QualityPlan qualityPlan)
        {
            qualityPlanRepository.Insert(qualityPlan);
            unitOfWork.SaveChanges();
        }

        public void Update(QualityPlan qualityPlan)
        {
            qualityPlanRepository.Update(qualityPlan);
            unitOfWork.SaveChanges();
        }
    }
    public interface IQualityPlanService
    {
        IEnumerable<QualityPlan> GetAll();
        QualityPlan Get(int id);
        void Insert(QualityPlan qualityPlan);
        void Update(QualityPlan qualityPlan);
        void Delete(int id);
        bool Any(int id);
    }
}

    

