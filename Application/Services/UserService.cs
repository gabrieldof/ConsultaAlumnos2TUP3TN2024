﻿using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces;
using Application.Models.Request;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        
        {
            _userRepository = userRepository;
        }
        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Get(string name)
        {
            return _userRepository.Get(name);
        }

        public int Add(User user) { 
        
        return _userRepository.Add(user);

        }



    }
}
