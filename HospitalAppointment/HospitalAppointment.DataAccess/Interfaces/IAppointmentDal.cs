using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IAppointmentDal:IGenericDal<Appointment>
    {
        List<DateTime> GetAppointmentsHourTimesByAppointmentDayAndDoctorId(DateTime day, int doctorId);
        List<Appointment> GetPatientRegistrarAppointmentsWithAllTables(int id);
    }
}
