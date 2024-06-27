using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)

        {
            _studentRepository = studentRepository;
        }

        public Student? Get(string name)
        {
            return _studentRepository.Get(name);
        }


        public List<Student> Get()
        {
            return _studentRepository.Get();
        }

        public Student Add(Student student)
        {
            return _studentRepository.Add(student);
        }

        public int Update(Student student)
        {
            return _studentRepository.Update(student);
        }

        public int Delete(Student student)
        {
            return _studentRepository.Delete(student);
        }

        public Student? GetById<Tid>(Tid id)
        {
            return _studentRepository.GetById(id);
        }
    }
}
