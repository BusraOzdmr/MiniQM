using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> countryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CountryService(IRepository<Country> countryRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return countryRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = countryRepository.Get(id);
            if (entity != null)
            {
                countryRepository.Delete(entity);
            }
        }

        public Country Get(int id)
        {
            return countryRepository.Get(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return countryRepository.GetAll();
        }

        public void Insert(Country country)
        {
            countryRepository.Insert(country);
            unitOfWork.SaveChanges();
        }

        public void Update(Country country)
        {
            countryRepository.Update(country);
            unitOfWork.SaveChanges();
        }
    }

    public interface ICountryService
    {
        IEnumerable<Country> GetAll();
        Country Get(int id);
        void Insert(Country country);
        void Update(Country country);
        void Delete(int id);
        bool Any(int id);
    }
}
