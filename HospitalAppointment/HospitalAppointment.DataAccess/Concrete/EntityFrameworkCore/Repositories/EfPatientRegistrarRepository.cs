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
    public class EfPatientRegistrarRepository : EfGenericRepository<PatientRegistrar>, IPatientRegistrarDal
    {
        private readonly HospitalAppBbContext _context;
        public EfPatientRegistrarRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<PatientRegistrar> GetPatientRegistrarsWithAllTables()
        {
            return _context.PatientRegistrars.Include(I => I.User).ToList();
        }

        public PatientRegistrar GetPatientRegistrarByUserId(int id)
        {
            return _context.PatientRegistrars.FirstOrDefault(I => I.UserId == id);
        }
    }
}
