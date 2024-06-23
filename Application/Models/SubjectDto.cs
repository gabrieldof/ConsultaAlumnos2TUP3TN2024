using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProfessorDto> Professors { get; set; } = new List<ProfessorDto>();

    }
}
