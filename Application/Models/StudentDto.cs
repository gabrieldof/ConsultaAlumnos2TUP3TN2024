﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CompleteName
        {
            get
            {
                return Name + " " + LastName;
            }
        }
        public IList<SubjectDto> SubjectsAttended { get; set; } = new List<SubjectDto>();
    }
}
