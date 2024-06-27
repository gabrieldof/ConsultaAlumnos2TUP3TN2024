using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        public List<T> Get();

        public T? GetById<Tid>(Tid id);

        public T Add(T entity);

        public int Update(T entity);
        public int Delete(T entity);



    }
}
