using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IGenericDal<TEntity> where TEntity : new()
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);

        TEntity GetById(int id);
        List<TEntity> GetAll();
    }
}
