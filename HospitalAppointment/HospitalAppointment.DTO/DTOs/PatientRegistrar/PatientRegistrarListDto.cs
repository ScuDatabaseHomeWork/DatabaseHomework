using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.PatientRegistrar
{
   public class PatientRegistrarListDto
    {
        public int Id { get; set; }
        public int TellerNumber { get; set; }
        public DataAccess.Concrete.EntityFrameworkCore.Entities.User User { get; set; }
    }
}
