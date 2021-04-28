using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfSuperAdminRepository:EfGenericRepository<SuperAdmin>,ISuperAdminDal
    {
        public EfSuperAdminRepository(HospitalAppBbContext context) : base(context)
        {
        }
    }
}
