using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Language> languageRepository;
        private readonly IUnitOfWork unitOfWork;
        public bool Any(int id)
        {
            return languageRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = languageRepository.Get(id);
            if(entity != null)
            {
                languageRepository.Delete(entity);
            }
        }

        public Language Get(int id)
        {
            return languageRepository.Get(id);
        }

        public IEnumerable<Language> GetAll()
        {
            return languageRepository.GetAll();
        }

        public void Insert(Language language)
        {
            languageRepository.Insert(language);
        }

        public void Update(Language language)
        {
            languageRepository.Update(language);
        }
    }

    public interface ILanguageService
    {
        IEnumerable<Language> GetAll();
        Language Get(int id);
        void Insert(Language language);
        void Update(Language language);
        void Delete(int id);
        bool Any(int id);
    }
}
