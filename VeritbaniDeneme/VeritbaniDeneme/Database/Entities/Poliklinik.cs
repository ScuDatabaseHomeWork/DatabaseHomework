using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeritbaniDeneme.Database.Entities
{
    public class Poliklinik
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<Doktor> Doktorlar { get; set; }
    }
}
