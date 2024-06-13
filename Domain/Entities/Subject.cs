using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Professor> Professors { get; set; } = new List<Professor>();

        //public int ProfessorId { get; set; }
        //public Professor Professor { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();


    }
}
