using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class SystemUserService : ISystemUserService
    {
        private readonly IRepository<SystemUser> systemUserRepository;
        private readonly IUnitOfWork unitOfWork;

        public SystemUserService(IRepository<SystemUser> systemUserRepository, IUnitOfWork unitOfWork)
        {
            this.systemUserRepository = systemUserRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(int id)
        {
            return systemUserRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = systemUserRepository.Get(id);
            if (entity != null)
            {
                systemUserRepository.Delete(entity);
            }
        }

        public SystemUser Get(int id)
        {
            return systemUserRepository.Get(id);
        }

        public IEnumerable<SystemUser> GetAll()
        {
            return systemUserRepository.GetAll();
        }

        public void Insert(SystemUser systemUser)
        {
            systemUserRepository.Insert(systemUser);
            unitOfWork.SaveChanges();
        }

        public void Update(SystemUser systemUser)
        {
            systemUserRepository.Update(systemUser);
            unitOfWork.SaveChanges();
        }
    }

    public interface ISystemUserService
    {
        IEnumerable<SystemUser> GetAll();
        SystemUser Get(int id);
        void Insert(SystemUser systemUser);
        void Update(SystemUser systemUser);
        void Delete(int id);
        bool Any(int id);
    }
}
