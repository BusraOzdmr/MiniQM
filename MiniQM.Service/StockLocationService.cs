using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class StockLocationService : IStockLocationService
    {
        private readonly IRepository<StockLocation> stockLocationRepository;
        private readonly IUnitOfWork unitOfWork;
        public StockLocationService(IRepository<StockLocation> stockLocationRepository, IUnitOfWork unitOfWork)
        {
            this.stockLocationRepository = stockLocationRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return stockLocationRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = stockLocationRepository.Get(id);
            if (entity != null)
            {
                stockLocationRepository.Delete(entity);
            }
        }

        public StockLocation Get(int id)
        {
            return stockLocationRepository.Get(id);
        }

        public IEnumerable<StockLocation> GetAll()
        {
            return stockLocationRepository.GetAll();
        }

        public void Insert(StockLocation stockLocation)
        {
            stockLocationRepository.Insert(stockLocation);
            unitOfWork.SaveChanges();
        }

        public void Update(StockLocation stockLocation)
        {
            stockLocationRepository.Update(stockLocation);
            unitOfWork.SaveChanges();
        }
    }

    public interface IStockLocationService
    {
        IEnumerable<StockLocation> GetAll();
        StockLocation Get(int id);
        void Insert(StockLocation stockLocation);
        void Update(StockLocation stockLocation);
        void Delete(int id);
        bool Any(int id);
    }
}
