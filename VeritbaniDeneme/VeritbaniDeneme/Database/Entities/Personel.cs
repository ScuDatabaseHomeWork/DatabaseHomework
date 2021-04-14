using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeritbaniDeneme.Database.Entities
{
    public class Personel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public long Telefon { get; set; }
        public long Tcno { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }

        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
