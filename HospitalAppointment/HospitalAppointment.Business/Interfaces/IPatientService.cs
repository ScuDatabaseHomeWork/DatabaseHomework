using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface IPatientService:IGenericService<Patient>
    {
        List<Patient> GetPatientsWithAllTables();
        User CheckAndGetPatientByTcNo(long tc);
    }
}
