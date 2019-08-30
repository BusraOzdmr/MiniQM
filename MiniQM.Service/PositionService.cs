using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class PositionService : IPositionService
    {
        private readonly IRepository<Position> positionRepository;
        private readonly IUnitOfWork unitOfWork;

        public PositionService(IRepository<Position> positionRepository, IUnitOfWork unitOfWork)
        {
            this.positionRepository = positionRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return positionRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = positionRepository.Get(id);
            if(entity != null)
            {
                positionRepository.Delete(entity);
            }
        }

        public Position Get(int id)
        {
            return positionRepository.Get(id);
        }

        public IEnumerable<Position> GetAll()
        {
            return positionRepository.GetAll();
        }

        public void Insert(Position position)
        {
            positionRepository.Insert(position);
            unitOfWork.SaveChanges();
        }

        public void Update(Position position)
        {
            positionRepository.Update(position);
            unitOfWork.SaveChanges();
        }
    }

    public interface IPositionService
    {
        IEnumerable<Position> GetAll();
        Position Get(int id);
        void Insert(Position position);
        void Update(Position position);
        void Delete(int id);
        bool Any(int id);
    }
}
