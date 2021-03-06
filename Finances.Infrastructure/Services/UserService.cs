﻿using Finances.Core.Domain;
using Finances.Core.Repositories;
using System;
using Finances.Infrastructure.DTO;
using AutoMapper;
using System.Threading.Tasks;
using Finances.Infrastructure.IServices;
using Finances.Infrastructure.Exceptions;

namespace Finances.Infrastructure.Services
{
    public class UserService : IUserServices
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            
            return _mapper.Map<User,UserDTO>(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new ServiceExceptions(Exceptions.ErrorCodes.InvalidCredentials,"Invalid Credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == hash)
            {
                return;
            }
            throw new ServiceExceptions(Exceptions.ErrorCodes.InvalidCredentials,"Invalid Credentials");
        }

        public async Task RegisterAsync(Guid userId,string email, string username, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new ServiceExceptions(Exceptions.ErrorCodes.EmailAlreadyExist, $"User with email: {email} already exist");
            }
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(userId,email,username,hash,salt);
            await _userRepository.AddAsync(user);
        }
    }
}
