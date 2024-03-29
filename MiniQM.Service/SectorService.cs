﻿using MiniQM.Data;
using MiniQM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniQM.Service
{
    public class SectorService : ISectorService
    {
        private readonly IRepository<Sector> sectorRepository;
        private readonly IUnitOfWork unitOfWork;
        public SectorService(IRepository<Sector> sectorRepository, IUnitOfWork unitOfWork)
        {
            this.sectorRepository = sectorRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(int id)
        {
            return sectorRepository.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = sectorRepository.Get(id);
            if (entity != null)
            {
                sectorRepository.Delete(entity);
            }
        }

        public Sector Get(int id)
        {
            return sectorRepository.Get(id);
        }

        public IEnumerable<Sector> GetAll()
        {
            return sectorRepository.GetAll();
        }

        public void Insert(Sector sector)
        {
            sectorRepository.Insert(sector);
            unitOfWork.SaveChanges();
        }

        public void Update(Sector sector)
        {
            sectorRepository.Update(sector);
            unitOfWork.SaveChanges();
        }
    }

    public interface ISectorService
    {
        IEnumerable<Sector> GetAll();
        Sector Get(int id);
        void Insert(Sector sector);
        void Update(Sector sector);
        void Delete(int id);
        bool Any(int id);
    }
}
