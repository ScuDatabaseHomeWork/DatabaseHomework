using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppointmentRepository:EfGenericRepository<Appointment>,IAppointmentDal
    {
        public EfAppointmentRepository(HospitalAppBbContext context) : base(context)
        {

        }
    }
}
