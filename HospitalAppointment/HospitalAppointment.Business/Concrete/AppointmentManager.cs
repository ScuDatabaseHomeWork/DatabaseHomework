using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class AppointmentManager:GenericManager<Appointment>,IAppointmentService
    {
        private readonly IAppointmentDal _appointmentDal;
        public AppointmentManager(IGenericDal<Appointment> genericDal,IAppointmentDal appointmentDal) : base(genericDal)
        {
            _appointmentDal = appointmentDal;
        }


        public List<DateTime> GetAppointmentsHourTimesByAppointmentDayAndDoctorId(DateTime day, int doctorId)
        {
            return _appointmentDal.GetAppointmentsHourTimesByAppointmentDayAndDoctorId(day, doctorId);
        }

        public List<Appointment> GetPatientRegistrarAppointmentsWithAllTables(int id)
        {
            return _appointmentDal.GetPatientRegistrarAppointmentsWithAllTables(id);
        }
    }
}
