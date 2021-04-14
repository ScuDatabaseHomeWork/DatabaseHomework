using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeritbaniDeneme.Database.Entities
{
    public class Doktor
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string  Cinsiyet { get; set; }
        public long Telefon { get; set; }

        public int PoliklinikId { get; set; }
        public Poliklinik Poliklinik { get; set; }

        public List<Randevu> Randevular { get; set; }
    }
}
