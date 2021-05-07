﻿using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IPatientDal:IGenericDal<Patient>
    {
        List<User> GetPatientsWithAllTables();
        User CheckAndGetPatientByTcNo(long tc);
        Patient GetPatientByUserId(int id);
    }
}
