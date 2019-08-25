using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> companyRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompanyService(IRepository<Company> companyRepository, IUnitOfWork unitOfWork)
        {
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return companyRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = companyRepository.Get(id);
            if (entity != null)
            {
                companyRepository.Delete(entity);
                unitOfWork.SaveChanges();
            }
        }

        public Company Get(int id)
        {
            return companyRepository.Get(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return companyRepository.GetAll();
        }

        public void Insert(Company company)
        {
            companyRepository.Insert(company);
            unitOfWork.SaveChanges();
        }

        public void Update(Company company)
        {
            companyRepository.Update(company);
            unitOfWork.SaveChanges();
        }
    }
    public interface ICompanyService
    {
        IEnumerable<Company> GetAll();
        Company Get(int id);
        void Insert(Company company);
        void Update(Company company);
        void Delete(int id);
        bool Any(int id);
    }
}
