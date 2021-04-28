using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("PatientRegistrar")]
    public partial class PatientRegistrar
    {
        public PatientRegistrar()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        public int Id { get; set; }
        public int TellerNumber { get; set; }
        public int UserId { get; set; }
        public int SuperAdminId { get; set; }

        [ForeignKey(nameof(SuperAdminId))]
        [InverseProperty("PatientRegistrars")]
        public virtual SuperAdmin SuperAdmin { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("PatientRegistrars")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Appointment.Registrar))]
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
