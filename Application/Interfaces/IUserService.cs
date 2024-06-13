using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {

        User Get(string name);
        List<User> GetAll();

       // UserDto GetById(int id);

        public int Add(User user);
        //public int Update(User user);
        //public int Delete(User user);

    }
}
