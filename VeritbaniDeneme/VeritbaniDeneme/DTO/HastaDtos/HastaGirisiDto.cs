using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeritbaniDeneme.DTO.HastaDtos
{
    public class HastaGirisiDto
    {
        [Display(Name = "TC No")]
        public long Tcno { get; set; }

        [Display(Name = "Parola")]
        public string Parola { get; set; }
    }
}
