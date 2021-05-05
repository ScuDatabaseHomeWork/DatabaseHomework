using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface IAppointmentService:IGenericService<Appointment>
    {
        List<DateTime> GetAppointmentsHourTimesByAppointmentDayAndDoctorId(DateTime day, int doctorId);
        List<Appointment> GetPatientRegistrarAppointmentsWithAllTables(int id);
    }
}
