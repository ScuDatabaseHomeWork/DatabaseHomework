﻿using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IPatientRegistrarDal:IGenericDal<PatientRegistrar>
    {
        List<User> GetPatientRegistrarsWithAllTables();
        PatientRegistrar GetPatientRegistrarByUserId(int id);
    }
}
