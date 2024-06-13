using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public User? Get(string name)
        {
            return _context.Users.FirstOrDefault(x => x.Name == name);
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public int Add(User user)

        {
            _context.Users.Add(user);
             _context.SaveChanges();
            return user.Id;

        }

        public int Update(User user)
        {
            _context.Users.Update(user);
            return _context.SaveChanges();

        }


        public int Delete(User user)
        {
            _context.Users.Remove(user);
            return _context.SaveChanges();

        }

    }
}
