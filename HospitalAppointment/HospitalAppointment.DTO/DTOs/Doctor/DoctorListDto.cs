using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.Doctor
{
    public class DoctorListDto
    {
        public int Id { get; set; }
        public long Tcno { get; set; }
        public int RolId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public long Telephone { get; set; }
        public bool Gender { get; set; }
        public DataAccess.Concrete.EntityFrameworkCore.Entities.Department Department { get; set; }
        public string Apellation { get; set; }
        public  DataAccess.Concrete.EntityFrameworkCore.Entities.User User { get; set; }
        public DataAccess.Concrete.EntityFrameworkCore.Entities.Policlinic Policlinic { get; set; }
   
    }
}
