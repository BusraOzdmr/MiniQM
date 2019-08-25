using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class CertificateService : ICertificateService
    {
        private readonly IRepository<Certificate> certificateRepository;
        private readonly IUnitOfWork unitOfWork;
        public bool Any(int id)
        {
            return certificateRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = certificateRepository.Get(id);
            if (entity != null)
            {
                certificateRepository.Delete(entity);
            }
        }

        public Certificate Get(int id)
        {
            return certificateRepository.Get(id);
        }

        public IEnumerable<Certificate> GetAll()
        {
            return certificateRepository.GetAll();
        }

        public void Insert(Certificate certificate)
        {
            certificateRepository.Insert(certificate);
            unitOfWork.SaveChanges();
        }

        public void Update(Certificate certificate)
        {
            certificateRepository.Update(certificate);
            unitOfWork.SaveChanges();
        }
    }

    public interface ICertificateService
    {
        IEnumerable<Certificate> GetAll();
        Certificate Get(int id);
        void Insert(Certificate certificate);
        void Update(Certificate certificate);
        void Delete(int id);
        bool Any(int id);
    }
}
