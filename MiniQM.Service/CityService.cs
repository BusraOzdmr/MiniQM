using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> cityRepository;
        private readonly IUnitOfWork unitOfWork;
        public CityService(IRepository<City> cityRepository, IUnitOfWork unitOfWork)
        {
            this.cityRepository = cityRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return cityRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = cityRepository.Get(id);
            if (entity != null)
            {
                cityRepository.Delete(entity);
            }
        }

        public IEnumerable<City> GetAllByCountryId(int countryId)
        {
            return cityRepository.GetAll(x => x.CountryId == countryId, o => o.Name, false);
        }

        public City Get(int id)
        {
            return cityRepository.Get(id);
        }

        public IEnumerable<City> GetAll()
        {
            return cityRepository.GetAll();
        }

        public void Insert(City city)
        {
            cityRepository.Insert(city);
            unitOfWork.SaveChanges();
        }

        public void Update(City city)
        {
            cityRepository.Update(city);
            unitOfWork.SaveChanges();
        }
    }

    public interface ICityService
    {
        IEnumerable<City> GetAll();
        IEnumerable<City> GetAllByCountryId(int countryId);
        City Get(int id);
        void Insert(City city);
        void Update(City city);
        void Delete(int id);
        bool Any(int id);
    }
}
