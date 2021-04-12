using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeritbaniDeneme.Database.Context;
using VeritbaniDeneme.Database.Entities;

namespace VeritbaniDeneme.Database.Repositories
{
    public class EfPersonelRepository : EfGenericRepository<Personel>
    {
        public Personel PersonelDogrula(string kullaniciAdi, string parola)
        {
            using var context = new VeritabaniOdevContext();
            Personel personel = context.Personeller.FirstOrDefault(I => I.KullaniciAdi == kullaniciAdi);
            if (kullaniciAdi != null)
            {
                return personel.Parola == parola ? personel : null;
            }
            else
            {
                return null;
            }
        }

        public string PersonelRolu(Personel personel)
        {
            using var context = new VeritabaniOdevContext();
            var result = context.Personeller.Include(I => I.Rol).FirstOrDefault(I => I.RolId == personel.RolId).Rol
                .RolAdi;
            return result;
        }
    }
}
