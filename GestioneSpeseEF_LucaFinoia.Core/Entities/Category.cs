using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpeseEF_LucaFinoia.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public List<Spese> SpeseList { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Categoria: {Categoria}";
        }
    }
}
