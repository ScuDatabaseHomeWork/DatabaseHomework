using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.Patient
{
    public class PatientListDto
    {
        public int Id { get; set; }
        public string AnaAdi { get; set; }
        public string BabaAdi { get; set; }
        public DataAccess.Concrete.EntityFrameworkCore.Entities.User User { get; set; }

    }
}
