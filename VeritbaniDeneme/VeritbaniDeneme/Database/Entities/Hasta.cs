using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeritbaniDeneme.Database.Entities
{
    public class Hasta
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string AnaAdi { get; set; }
        public string BabaAdi { get; set; }
        public long Telefon { get; set; }
        public long Tcno { get; set; }
        public string Parola { get; set; }

        public List<Randevu> Randevular { get; set; }

    }
}
