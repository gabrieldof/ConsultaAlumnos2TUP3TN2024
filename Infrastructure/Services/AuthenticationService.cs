﻿using Application.Interfaces;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static Infrastructure.Services.AuthenticationService;

namespace Infrastructure.Services
{
    public class AuthenticationService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationServiceOptions _options;

        public AuthenticationService(IUserRepository userRepository, IOptions<AuthenticationServiceOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }
        private User? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;
            var user = _userRepository.GetUserByName(authenticationRequest.UserName);

            return user;
        }

        public string Autenticar(AuthenticationRequest authenticationRequest)
        {
            //Paso 1: Validamos las credenciales
            var user = ValidateUser(authenticationRequest);

            //Paso 2: Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("thisisthesecretforgeneratingakey(mustbeatleast32bitlong)")); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("given_name", user.Name));
            //claimsForToken.Add(new Claim("family_name", user.LastName));

            var jwtSecurityToken = new JwtSecurityToken(
                _options.Issuer //issuer
                , _options.Audience//Audience
                , claimsForToken //Claims
                , DateTime.UtcNow // Inicio
                , DateTime.UtcNow.AddHours(1) //Fin Dura una hora
                , credentials
                );

            //Paso 3: Return del token
            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();


        }
        public class AuthenticationServiceOptions
        {
            public const string AuthenticationService = "AuthenticationService";

            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }
    }
}
