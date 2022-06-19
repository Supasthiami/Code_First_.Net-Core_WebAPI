using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApproach.Repository
{
    public interface IDataRepository<TEntity>
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity GetEmployee(int id);
        public void SaveEmployee(TEntity tEntity);
        public void DeleteEmployee(TEntity tEntity);
        public void UpdateEmployee(TEntity tEntity, TEntity tEntity1);

    }
}
