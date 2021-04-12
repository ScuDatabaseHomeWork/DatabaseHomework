using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeritbaniDeneme.Database.Entities
{
    public class Randevu
    {
        public int Id { get; set; }
        public DateTime Tarihi { get; set; }


        public int HastaId { get; set; }
        public Hasta Hasta { get; set; }


        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }


    }
}
