using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class CriterionService : ICriterionService
    {
        private readonly IRepository<Criterion> criterionRepository;
        private readonly IUnitOfWork unitOfWork;

        public CriterionService(IRepository<Criterion> criterionRepository, IUnitOfWork unitOfWork)
        {
            this.criterionRepository = criterionRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(int id)
        {
            return criterionRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = criterionRepository.Get(id);
            if (entity != null)
            {
                criterionRepository.Delete(entity);
            }
        }

        public Criterion Get(int id)
        {
            return criterionRepository.Get(id);
        }

        public IEnumerable<Criterion> GetAll()
        {
            return criterionRepository.GetAll();
        }

        public void Insert(Criterion criterion)
        {
            criterionRepository.Insert(criterion);
            unitOfWork.SaveChanges();
        }

        public void Update(Criterion criterion)
        {
            criterionRepository.Update(criterion);
            unitOfWork.SaveChanges();
        }
    }

    public interface ICriterionService
    {
        IEnumerable<Criterion> GetAll();
        Criterion Get(int id);
        void Insert(Criterion criterion);
        void Update(Criterion criterion);
        void Delete(int id);
        bool Any(int id);
    }
}
