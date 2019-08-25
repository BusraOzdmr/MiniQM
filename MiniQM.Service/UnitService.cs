using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class UnitService : IUnitService
    {
        private readonly IRepository<Unit> unitRepository;
        private readonly UnitOfWork unitOfWork;
        public bool Any(int id)
        {
            return unitRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = unitRepository.Get(id);
            if (entity != null)
            {
                unitRepository.Delete(entity);
            }
        }

        public Unit Get(int id)
        {
            return unitRepository.Get(id);
        }

        public IEnumerable<Unit> GetAll()
        {
            return unitRepository.GetAll();
        }

        public void Insert(Unit unit)
        {
            unitRepository.Insert(unit);
            unitOfWork.SaveChanges();
        }

        public void Update(Unit unit)
        {
            unitRepository.Update(unit);
            unitOfWork.SaveChanges();
        }
    }

    public interface IUnitService
    {
        IEnumerable<Unit> GetAll();
        Unit Get(int id);
        void Insert(Unit unit);
        void Update(Unit unit);
        void Delete(int id);
        bool Any(int id);
    }
}
