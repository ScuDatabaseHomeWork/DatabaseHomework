using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Doctors = new HashSet<Doctor>();
            PatientRegistrars = new HashSet<PatientRegistrar>();
            Patients = new HashSet<Patient>();
            SuperAdmins = new HashSet<SuperAdmin>();
        }

        [Key]
        public int Id { get; set; }
        [Column("TCNo")]
        public long Tcno { get; set; }
        public int RolId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string SurName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime BirthDate { get; set; }
        public long Telephone { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [ForeignKey(nameof(RolId))]
        [InverseProperty("Users")]
        public virtual Rol Rol { get; set; }
        [InverseProperty(nameof(Doctor.User))]
        public virtual ICollection<Doctor> Doctors { get; set; }
        [InverseProperty(nameof(PatientRegistrar.User))]
        public virtual ICollection<PatientRegistrar> PatientRegistrars { get; set; }
        [InverseProperty(nameof(Patient.User))]
        public virtual ICollection<Patient> Patients { get; set; }
        [InverseProperty(nameof(SuperAdmin.User))]
        public virtual ICollection<SuperAdmin> SuperAdmins { get; set; }
    }
}
