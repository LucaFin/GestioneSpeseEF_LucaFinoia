using GestioneSpeseEF_LucaFinoia.Core.Entities;
using GestioneSpeseEF_LucaFinoia.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpeseEF_LucaFinoia.Core.BusinessLayer
{
    public class MainBusinessLayer:IBusinessLayer
    {
        private readonly IRepository<Spese> speseRepo;
        private readonly IRepository<Category> categorieRepo;


        public MainBusinessLayer(IRepository<Spese> spese, IRepository<Category> categorie)
        {
            speseRepo = spese;
            categorieRepo = categorie;
        }

        public void ApprovaSpesa(int spesaId)
        {
            Spese spesa = speseRepo.GetByCode(spesaId);
            if (spesa != null)
            {
                spesa.Approvato = true;
                speseRepo.Update(spesa);
            }
            else { 
                Console.WriteLine("La spesa inserita non esiste");
            }
        }

        public void CancellaSpesa(int spesaId)
        {
            Spese spesa = speseRepo.GetByCode(spesaId);
            if (spesa != null)
            {
                speseRepo.Delete(spesa);
            }
            else
            {
                Console.WriteLine("La spesa inserita non esiste");
            }
        }

        public List<Spese> GetSpeseByApproved()
        {
            return speseRepo.GetAll().Where(s=>s.Approvato==true).ToList() ;
        }

        public List<Spese> GetSpeseByUser(string? user)
        {
            return speseRepo.GetAll().Where(s=>s.Utente==user).ToList() ;
        }

        public List<(double, string)> GetTotalSpeseByCategory()
        {
            List<(double, string)> totalSpeseByCategory = new List<(double, string)>();
            var groupByCategory = speseRepo.GetAll().GroupBy(s => s.Categoria);
            
            foreach (var group in groupByCategory)
            {
                double total = group.Sum(s => s.Importo);
                string cat=group.Key.ToString();
                (double, string) pair = (total, cat);
                totalSpeseByCategory.Add(pair);
            }
            return totalSpeseByCategory;
        }

        public void InserisciSpesa(Spese spesa)
        {
            Category categoria = categorieRepo.GetByCode(spesa.CategoryId);
            if(categoria != null) {
                speseRepo.Add(spesa);
            }
            else
            {
                Console.WriteLine("La categoria inserita non esiste");
            }
        }
    }
}
