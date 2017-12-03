﻿using Finances.Infrastructure.DTO;
using Finances.Infrastructure.IServices;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Services
{
    public interface IUserServices : IService
    {
        Task RegisterAsync(string email, string username, string password);

        Task<UserDTO> GetAsync(string email);

        Task LoginAsync(string email, string password);
    }
}
