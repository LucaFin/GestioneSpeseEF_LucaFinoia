using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpeseEF_LucaFinoia.Core.Entities
{
    public class Spese
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int CategoryId { get; set; }
        public string Descrizione { get; set; }
        public string Utente { get; set; }
        public double Importo { get; set; }
        public bool Approvato { get; set; }
     
        public Category Categoria { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Data: {Data} Categoria: {CategoryId} Descrizione: {Descrizione} Utente: {Utente} Importo {Importo} Approvato:{Approvato}";
        }
    }
}
