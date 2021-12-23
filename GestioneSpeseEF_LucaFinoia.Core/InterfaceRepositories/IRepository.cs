using GestioneSpeseEF_LucaFinoia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpeseEF_LucaFinoia.Core.InterfaceRepositories
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T Add(T entity);
        public T Update(T entity);
        public bool Delete(T entity);
        T GetByCode(int Id);
    }
}
