using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context) : base(context) 
        { 
            _context = context;
    
        }

        public Student? Get(string name)
        {
            return _context.Students.FirstOrDefault(s => s.Name == name);
        }



    }
}
