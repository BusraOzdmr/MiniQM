using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IRepository<UserGroup> userGroupRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserGroupService(IRepository<UserGroup> userGroupRepository, IUnitOfWork unitOfWork)
        {
            this.userGroupRepository = userGroupRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return userGroupRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = userGroupRepository.Get(id);
            if(entity != null)
            {
                userGroupRepository.Delete(entity);
                unitOfWork.SaveChanges();
            }
        }

        public UserGroup Get(int id)
        {
            return userGroupRepository.Get(id);
        }

        public IEnumerable<UserGroup> GetAll()
        {
            return userGroupRepository.GetAll();
        }

        public void Insert(UserGroup userGroup)
        {
            userGroupRepository.Insert(userGroup);
            unitOfWork.SaveChanges();
        }

        public void Update(UserGroup userGroup)
        {
            userGroupRepository.Update(userGroup);
            unitOfWork.SaveChanges();
        }
    }
    public interface IUserGroupService
    {       
        IEnumerable<UserGroup> GetAll();
        UserGroup Get(int id);
        void Insert(UserGroup userGroup);
        void Update(UserGroup userGroup);
        void Delete(int id);
        bool Any(int id);


    }

}
