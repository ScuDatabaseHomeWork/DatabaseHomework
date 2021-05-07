using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IDoctorDal:IGenericDal<Doctor>
    {
        List<User> GetDoctorsWithAllTables();
        List<User> GetDepartmentDoctorsByDepartmentId(int id);
        Doctor GetDoctorByUserId(int id);
    }
}
