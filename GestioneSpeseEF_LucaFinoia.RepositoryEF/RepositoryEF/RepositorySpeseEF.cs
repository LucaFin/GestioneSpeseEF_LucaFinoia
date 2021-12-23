using GestioneSpeseEF_LucaFinoia.Core.Entities;
using GestioneSpeseEF_LucaFinoia.Core.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpeseEF_LucaFinoia.RepositoryEF.RepositoryEF
{
    public class RepositorySpeseEF : IRepository<Spese>
    {
        private readonly Context context;

        public RepositorySpeseEF()
        {
            context = new Context();
        }

        public Spese Add(Spese entity)
        {
            context.SpeseDB.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Delete(Spese entity)
        {
            context.SpeseDB.Remove(entity);
            context.SaveChanges();
            return true;
        }

        public List<Spese> GetAll()
        {
            return context.SpeseDB.Include(s=>s.Categoria).ToList();
        }

        public Spese GetByCode(int Id)
        {
            return context.SpeseDB.FirstOrDefault(s=>s.Id==Id);
        }

        public Spese Update(Spese entity)
        {
            context.SpeseDB.Update(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
