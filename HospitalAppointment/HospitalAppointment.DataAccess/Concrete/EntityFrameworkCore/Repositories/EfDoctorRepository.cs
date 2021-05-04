using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfDoctorRepository : EfGenericRepository<Doctor>, IDoctorDal
    {
        private readonly HospitalAppBbContext _context;
        public EfDoctorRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<Doctor> GetDoctorsWithAllTables()
        {
            return _context.Doctors.Include(I => I.User).Include(I => I.Department).Include(I => I.Policlinic).ToList();
        }

        public List<User> GetDepartmentDoctorsByDepartmentId(int id)
        {
            var doctors = _context.Doctors.Where(I => I.DepartmentId == id).Include(I => I.User).ToList();
            List<User> doctorUsers = new List<User>();
            foreach (var doctor in doctors)
            {
                doctorUsers.Add(_context.Users.FirstOrDefault(I=>I.Id == doctor.UserId));
            }
            return doctorUsers;
        }

        public Doctor GetDoctorByUserId(int id)
        {
            return _context.Doctors.FirstOrDefault(I => I.UserId == id);
        }
    }
}
