using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User? Get(string name);
        List<User> GetAll();

        public int Add(User user);
        public int Update(User user);
        public int Delete(User user);



    }
}
