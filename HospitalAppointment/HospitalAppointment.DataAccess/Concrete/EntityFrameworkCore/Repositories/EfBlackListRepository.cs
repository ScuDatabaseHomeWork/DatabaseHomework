using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBlackListRepository : EfGenericRepository<BlackList>, IBlackListDal
    {
        private readonly HospitalAppBbContext _context;
        public EfBlackListRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<BlackList> GetPatientBlackListsByPatientId(int id)
        {
            return _context.BlackLists.Where(I => I.PatientId == id).ToList();
        }

        public bool CheckInBlackListByPatientId(int id)
        {
            var lastBlackList = _context.BlackLists.Where(I => I.PatientId == id).OrderByDescending(I => I.DeceptionCount).FirstOrDefault();

            if (lastBlackList != null && lastBlackList.DeceptionCount >= DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
