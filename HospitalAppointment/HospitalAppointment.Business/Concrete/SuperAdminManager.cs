using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class SuperAdminManager:GenericManager<SuperAdmin>,ISuperAdminService
    {
        public SuperAdminManager(IGenericDal<SuperAdmin> genericDal) : base(genericDal)
        {
        }
    }
}
