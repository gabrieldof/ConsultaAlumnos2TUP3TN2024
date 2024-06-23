using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class ProfessorUpdateRequest
    {

        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string MainProfessorEmail { get; set; } = string.Empty;
    }
}
