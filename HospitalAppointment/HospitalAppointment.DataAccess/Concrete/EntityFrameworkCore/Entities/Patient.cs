﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("Patient")]
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            BlackLists = new HashSet<BlackList>();
            Prescribes = new HashSet<Prescribe>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string AnaAdi { get; set; }
        [Required]
        [StringLength(50)]
        public string BabaAdi { get; set; }
        public int UserId { get; set; }
        public int SuperAdminId { get; set; }

        [ForeignKey(nameof(SuperAdminId))]
        [InverseProperty("Patients")]
        public virtual SuperAdmin SuperAdmin { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Patients")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Appointment.Patient))]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [InverseProperty(nameof(BlackList.Patient))]
        public virtual ICollection<BlackList> BlackLists { get; set; }
        [InverseProperty(nameof(Prescribe.Patient))]
        public virtual ICollection<Prescribe> Prescribes { get; set; }
    }
}
