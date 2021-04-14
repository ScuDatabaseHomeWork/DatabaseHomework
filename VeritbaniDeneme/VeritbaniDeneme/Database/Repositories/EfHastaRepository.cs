using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritbaniDeneme.Database.Context;
using VeritbaniDeneme.Database.Entities;

namespace VeritbaniDeneme.Database.Repositories
{
    public class EfHastaRepository : EfGenericRepository<Hasta>
    {
        public bool HastaDogrula(long tcNo, string parola)
        {
            using var context = new VeritabaniOdevContext();
            Hasta hasta = context.Hastalar.FirstOrDefault(I => I.Tcno == tcNo);
            if (hasta != null)
            {
                return hasta.Parola == parola ? true : false;
            }
            else
            {
                return false;
            }
        }

        public Hasta HastaGetirileTc(long tcNo)
        {
            using var context = new VeritabaniOdevContext();
            Hasta hasta = context.Hastalar.FirstOrDefault(I => I.Tcno == tcNo);
            if (hasta != null)
            {
                return hasta;
            }
            else
            {
                return null;
            }
        }
    }
}
