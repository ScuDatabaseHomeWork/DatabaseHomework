using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class PrescribeManager:GenericManager<Prescribe>,IPrescribeService
    {
        public PrescribeManager(IGenericDal<Prescribe> genericDal) : base(genericDal)
        {
        }
    }
}
