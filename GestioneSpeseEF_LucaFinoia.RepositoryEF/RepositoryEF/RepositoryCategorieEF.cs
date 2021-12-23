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
    public class RepositoryCategorieEF : IRepository<Category>
    {
        private readonly Context context;

        public RepositoryCategorieEF()
        {
            context = new Context();
        }

        public Category Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetByCode(int Id)
        {
            return context.CategoryDB.FirstOrDefault(c => c.Id == Id);
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
