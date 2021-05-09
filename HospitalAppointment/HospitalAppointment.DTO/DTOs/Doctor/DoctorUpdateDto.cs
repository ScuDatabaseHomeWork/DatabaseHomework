﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.Doctor
{
    public class DoctorUpdateDto
    {
        public int Id { get; set; }
        public long TCNo { get; set; }
        public int RolId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public long Telephone { get; set; }
        public bool Gender { get; set; }
        public string Password { get; set; }
        public DataAccess.Concrete.EntityFrameworkCore.Entities.Policlinic Policlinic { get; set; }
        public DataAccess.Concrete.EntityFrameworkCore.Entities.Doctor Doctor { get; set; }

    }
}
