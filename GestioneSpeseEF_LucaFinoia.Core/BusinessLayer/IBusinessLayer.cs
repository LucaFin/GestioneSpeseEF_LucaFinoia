using GestioneSpeseEF_LucaFinoia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpeseEF_LucaFinoia.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        void InserisciSpesa(Spese spesa);
        void ApprovaSpesa(int spesaId);
        void CancellaSpesa(int spesaId);
        List<Spese> GetSpeseByApproved();
        List<Spese> GetSpeseByUser(string? user);
        List<(double, string)> GetTotalSpeseByCategory();
    }
}
