﻿using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class UserManager:GenericManager<User>,IUserService
    {
        public UserManager(IGenericDal<User> genericDal) : base(genericDal)
        {
        }
    }
}