using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    
    public class MaterialInputService : IMaterialInputService
    {
        private readonly IRepository<MaterialInput> materialInputRepository;
        private readonly IUnitOfWork unitOfWork;

        public MaterialInputService(IRepository<MaterialInput> materialInputRepository, IUnitOfWork unitOfWork)
        {
            this.materialInputRepository = materialInputRepository;
            this.unitOfWork = unitOfWork;
        }
        
        public bool Any(int id)
        {
            return materialInputRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = materialInputRepository.Get(id);
            if(entity != null)
            { 
                materialInputRepository.Delete(entity);
            }
        }

        public MaterialInput Get(int id)
        {
            return materialInputRepository.Get(id);
        }

        public IEnumerable<MaterialInput> GetAll()
        {
            return materialInputRepository.GetAll();
        }

        public void Insert(MaterialInput materialInput)
        {
            materialInputRepository.Insert(materialInput);
            unitOfWork.SaveChanges();
        }

        public void Update(MaterialInput materialInput)
        {
            materialInputRepository.Update(materialInput);
            unitOfWork.SaveChanges();
        }
    }
    public interface IMaterialInputService
    {
        MaterialInput Get(int id);
        IEnumerable<MaterialInput> GetAll();
        void Insert(MaterialInput materialInput);
        void Update(MaterialInput materialInput);
        void Delete(int id);
        bool Any(int id);
    }
}
