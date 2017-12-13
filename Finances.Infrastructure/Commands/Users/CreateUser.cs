﻿using System;

namespace Finances.Infrastructure.Commands.Users
{
    public class CreateUser : ICommand
    { 
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
