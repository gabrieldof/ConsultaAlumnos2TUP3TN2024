using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public UserDto ToDto(User user) 
        
        //{ 

        //    UserDto dto = new UserDto();

        //    { 
            
        //        dto.Id = Id;
        //        dto.Name = Name;
        //        dto.Email = Email;
        //            dto.Password = Password;

        //    };
            
        
        //}

    }
}
