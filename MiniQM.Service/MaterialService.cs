using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    class MaterialService : IMaterialService
    {
        private readonly IRepository<Material> materialRepository;
        private readonly IUnitOfWork unitOfWork;


        public MaterialService(IRepository<Material> materialRepository, IUnitOfWork unitOfWork)
        {
            this.materialRepository = materialRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return materialRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var material = materialRepository.Get(id);
            if(material != null)
            {
                materialRepository.Delete(material);
                unitOfWork.SaveChanges();
            }
        }

        public Material Get(int id)
        {
            return materialRepository.Get(id);
        }

        public IEnumerable<Material> GetAll()
        {
            return materialRepository.GetAll();
        }

        public void Insert(Material material)
        {
            materialRepository.Insert(material);
            unitOfWork.SaveChanges();
        }

        public void Update(Material material)
        {
            materialRepository.Update(material);
            unitOfWork.SaveChanges();
        }
    }
    
    public interface IMaterialService
    {
        IEnumerable<Material> GetAll();
        Material Get(int id);
        void Insert(Material material);
        void Update(Material material);
        void Delete(int id);
        bool Any(int id);
    }
}
