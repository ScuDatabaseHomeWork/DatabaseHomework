using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeritbaniDeneme.Database.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string RolAdi { get; set; }
        public List<Personel> Personeller { get; set; }
    }
}
