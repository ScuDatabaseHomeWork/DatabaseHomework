using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritbaniDeneme.Database.Context;

namespace VeritbaniDeneme.Database.Repositories
{
    public class EfGenericRepository<Tablo> where Tablo : class
    {
        public void Kaydet(Tablo tablo)
        {
            using var context = new VeritabaniOdevContext();
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges();
        }

        public void Sil(Tablo tablo)
        {
            using var context = new VeritabaniOdevContext();
            context.Set<Tablo>().Remove(tablo);
            context.SaveChanges();
        }

        public void Guncelle(Tablo tablo)
        {
            using var context = new VeritabaniOdevContext();
            context.Set<Tablo>().Update(tablo);
            context.SaveChanges();
        }

        public Tablo GetirIdile(int id)
        {
            using var context = new VeritabaniOdevContext();
            return context.Set<Tablo>().Find(id);
        }

        public List<Tablo> GetirHepsi()
        {
            using var context = new VeritabaniOdevContext();
            return context.Set<Tablo>().ToList();
        }
    }
}
