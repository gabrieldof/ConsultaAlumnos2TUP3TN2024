using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }


        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById<Tid>(Tid id)
        {
            return _context.Set<T>().Find(new object[] { id });
        }

        public T Add(T entity)

        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }


        public int Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChanges();

        }


        public int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges();

        }


    }
}
