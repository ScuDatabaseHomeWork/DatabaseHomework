using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppointmentRepository:EfGenericRepository<Appointment>,IAppointmentDal
    {
        private readonly HospitalAppBbContext _context;
        public EfAppointmentRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<DateTime> GetAppointmentsHourTimesByAppointmentDayAndDoctorId(DateTime day,int doctorId)
        {
            List<Appointment> ExistHourTimes = _context.Appointments.Where(I => I.Date.DayOfYear == day.DayOfYear)
                .Where(I => I.DoctorId == doctorId).ToList();
            List<DateTime> AppointmentsHourTimes = new List<DateTime>();
            foreach (var existHourTime in ExistHourTimes)
            {
                AppointmentsHourTimes.Add(existHourTime.Date);
            }
            return AppointmentsHourTimes;
        }
    }
}
