using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> departmentRepository;
        private readonly IUnitOfWork unitOfWork;
        
        public DepartmentService(IRepository<Department> departmentRepository, IUnitOfWork unitOfWork)
        {
            this.departmentRepository = departmentRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return departmentRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var department = departmentRepository.Get(id);
            if (department != null)
            {
                departmentRepository.Delete(department);
                unitOfWork.SaveChanges();
            }
        }

        public Department Get(int id)
        {
            return departmentRepository.Get(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return departmentRepository.GetAll();
        }

        public void Insert(Department department)
        {
            departmentRepository.Insert(department);
            unitOfWork.SaveChanges();
        }

        public void Upload(Department department)
        {
            departmentRepository.Update(department);
            unitOfWork.SaveChanges();
        }
    }
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();
        Department Get(int id);
        void Delete(int id);
        void Insert(Department department);
        void Upload(Department department);
        bool Any(int id);
    }

}
