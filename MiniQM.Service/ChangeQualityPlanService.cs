using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class ChangeQualityPlanService : IChangeQualityPlanService
    {
        private readonly IRepository<ChangeQualityPlan> changeQualityPlanRepository;
        private readonly IUnitOfWork unitOfWork;
        public bool Any(int id)
        {
            return changeQualityPlanRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = changeQualityPlanRepository.Get(id);
            if (entity != null)
            {
                changeQualityPlanRepository.Delete(entity);
            }
        }

        public ChangeQualityPlan Get(int id)
        {
            return changeQualityPlanRepository.Get(id);
        }

        public IEnumerable<ChangeQualityPlan> GetAll()
        {
            return changeQualityPlanRepository.GetAll();
        }

        public void Insert(ChangeQualityPlan changeQualityPlan)
        {
            changeQualityPlanRepository.Insert(changeQualityPlan);
            unitOfWork.SaveChanges();
        }

        public void Update(ChangeQualityPlan changeQualityPlan)
        {
            changeQualityPlanRepository.Update(changeQualityPlan);
            unitOfWork.SaveChanges();
        }
    }

    public interface IChangeQualityPlanService
    {
        IEnumerable<ChangeQualityPlan> GetAll();
        ChangeQualityPlan Get(int id);
        void Insert(ChangeQualityPlan changeQualityPlan);
        void Update(ChangeQualityPlan changeQualityPlan);
        void Delete(int id);
        bool Any(int id);
    }
}
