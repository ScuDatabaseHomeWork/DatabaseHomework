using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IPatientDal:IGenericDal<Patient>
    {
        List<Patient> GetPatientsWithAllTables();
        User CheckAndGetPatientByTcNo(long tc);
    }
}
