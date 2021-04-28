using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class PoliclinicManager:GenericManager<Policlinic>,IPoliclinicService
    {
        public PoliclinicManager(IGenericDal<Policlinic> genericDal) : base(genericDal)
        {
        }
    }
}
