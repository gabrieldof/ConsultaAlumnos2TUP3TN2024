using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStudentService : IRepositoryBase<Student>
    {
        //ICollection<SubjectDto> GetSubjectsByStudent(int studentId);
        //StudentDto GetStudentById(int id);
        public Student? Get(string name);


    }
}
