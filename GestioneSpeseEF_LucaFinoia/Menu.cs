using GestioneSpeseEF_LucaFinoia.Core.BusinessLayer;
using GestioneSpeseEF_LucaFinoia.Core.Entities;
using GestioneSpeseEF_LucaFinoia.RepositoryEF.RepositoryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpeseEF_LucaFinoia
{
    public class Menu
    {
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositorySpeseEF(), new RepositoryCategorieEF());
        public static void Start()
        {
            Console.WriteLine("=== Esercitazione  ===");
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    InserisciSpesa();
                    break;
                case 2:
                    ApprovaSpesa();
                    break;
                case 3:
                    CancellaSpesa();
                    break;
                case 4:
                    MostraSpeseApprovate();
                    break;
                case 5:
                    MostraSpeseUtente();
                    break;
                case 6:
                    MostraTotaleSpesePerCategoria();
                    break;
                case 0:
                    return false;
            }
            return true;
        }

        private static void MostraTotaleSpesePerCategoria()
        {
            List<(double, string)> speseCategoria = bl.GetTotalSpeseByCategory();
            foreach(var spese in speseCategoria)
            {
                Console.WriteLine($"Categoria: {spese.Item2} Totale:{spese.Item1}");
            }
        }

        private static void MostraSpeseUtente()
        {
            Console.WriteLine("Inserire Utente");
            string user = Console.ReadLine();
            List<Spese> speseList = bl.GetSpeseByUser(user);
            if (speseList.Count == 0)
            {
                Console.WriteLine($"Non ci sono spese dell'utente {user}");
            }
            else
            {
                foreach (Spese spese in speseList)
                {
                    Console.WriteLine(spese.ToString());
                }
            }
        }

        private static void MostraSpeseApprovate()
        {
            List<Spese> speseList = bl.GetSpeseByApproved();
            if (speseList.Count == 0)
            {
                Console.WriteLine("Non ci sono spese approvate");
            }
            else
            {
                foreach(Spese spese in speseList)
                {
                    Console.WriteLine(spese.ToString());
                }
            }

        }

        private static void CancellaSpesa()
        {
            Console.WriteLine("Inserisci ID Categoria Spesa");
            int spesaId = int.Parse(Console.ReadLine());
            bl.CancellaSpesa(spesaId);
        }

        private static void ApprovaSpesa()
        {
            Console.WriteLine("Inserisci ID Categoria Spesa");
            int spesaId = int.Parse(Console.ReadLine());
            bl.ApprovaSpesa(spesaId);
        }

        private static void InserisciSpesa()
        {
            Console.WriteLine("Inserisci data (formato gg-mm-aaaa)");
            DateTime data = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci ID Categoria Spesa");
            int categoriaId = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci descrizione");
            string descrizione=Console.ReadLine();
            Console.WriteLine("Inserisci utente");
            string utente=Console.ReadLine();
            Console.WriteLine("Inserisci importo");
            double importo =double.Parse(Console.ReadLine());
            Spese spesa = new Spese();
            spesa.Data = data;
            spesa.CategoryId = categoriaId;
            spesa.Descrizione = descrizione;
            spesa.Utente = utente;
            spesa.Importo = importo;
            spesa.Approvato = false;
            bl.InserisciSpesa(spesa);
        }

        private static int SchermoMenu()
        {
            Console.WriteLine($"============= Menu =============");
            Console.WriteLine();
            Console.WriteLine("[ 1 ] - Aggiungi Spesa\n");
            Console.WriteLine("[ 2 ] - Approva Spesa\n");
            Console.WriteLine("[ 3 ] - Cancella Spesa\n");
            Console.WriteLine("[ 4 ] - Mostra Spese Approvate\n");
            Console.WriteLine("[ 5 ] - Mostra Spese di un Utente\n");
            Console.WriteLine("[ 6 ] - Totale Spese per Categoria\n");
            Console.WriteLine("[ 0 ] - QUIT\n");
            Console.Write(">");
            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while (!int.TryParse(Console.ReadLine(), out scelta))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta:");
            }
            return scelta;
        }
    }
}
