using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPatientRepository : EfGenericRepository<Patient>, IPatientDal
    {
        private readonly HospitalAppBbContext _context;
        public EfPatientRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<Patient> GetPatientsWithAllTables()
        {
            return _context.Patients.Include(I => I.User).ToList();
        }

        public User CheckAndGetPatientByTcNo(long tc)
        {
            var user = _context.Users.FirstOrDefault(I => I.Tcno == tc);
            if (user != null)
            {
                var patient = _context.Patients.FirstOrDefault(I => I.UserId == user.Id);
                return patient != null ? user : null;
            }
            else
            {
                return null;
            }
        }

    }
}
