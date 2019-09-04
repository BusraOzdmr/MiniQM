using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class OrderService : IOrderService
    {
        public readonly IRepository<Order> orderRepository;
        public readonly IUnitOfWork unitOfWork;
        public OrderService(IRepository<Order> orderRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return orderRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = orderRepository.Get(id);
            if(entity != null)
            {
                orderRepository.Delete(entity);
            }
        }

        public Order Get(int id)
        {
            return orderRepository.Get(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return orderRepository.GetAll();
        }

        public void Insert(Order order)
        {
            orderRepository.Insert(order);
            unitOfWork.SaveChanges();
        }

        public void Update(Order order)
        {
            orderRepository.Update(order);
            unitOfWork.SaveChanges();
        }
    }
    public interface IOrderService
    {
        Order Get(int id);
        IEnumerable<Order> GetAll();
        void Insert(Order order);
        void Update(Order order);
        void Delete(int id);
        bool Any(int id);
    }
}
