using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class OrderTypeService : IOrderTypeService
    {
        private readonly IRepository<OrderType> orderTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        public OrderTypeService(IRepository<OrderType> orderTypeRepository, IUnitOfWork unitOfWork)
        {
            this.orderTypeRepository = orderTypeRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return orderTypeRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = orderTypeRepository.Get(id);
            if (entity != null)
            {
                orderTypeRepository.Delete(entity);
            }
        }

        public OrderType Get(int id)
        {
            return orderTypeRepository.Get(id);
        }

        public IEnumerable<OrderType> GetAll()
        {
            return orderTypeRepository.GetAll();
        }

        public void Insert(OrderType orderType)
        {
            orderTypeRepository.Insert(orderType);
            unitOfWork.SaveChanges();
        }

        public void Update(OrderType orderType)
        {
            orderTypeRepository.Update(orderType);
            unitOfWork.SaveChanges();
        }
    }

    public interface IOrderTypeService
    {
        IEnumerable<OrderType> GetAll();
        OrderType Get(int id);
        void Insert(OrderType orderType);
        void Update(OrderType orderType);
        void Delete(int id);
        bool Any(int id);
    }
}
