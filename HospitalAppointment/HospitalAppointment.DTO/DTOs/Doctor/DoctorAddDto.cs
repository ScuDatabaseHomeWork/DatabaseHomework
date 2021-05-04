﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.Doctor
{
    public class DoctorAddDto
    {
        public long Tcno { get; set; }
        public int RolId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public long Telephone { get; set; }
        public bool Gender { get; set; }
        public string Password { get; set; }

        public int DepartmentId { get; set; }
        public string Apellation { get; set; }
        public int UserId { get; set; }
        public int SuperAdminId { get; set; }

        public string PoliclinicName { get; set; }
    }
}
