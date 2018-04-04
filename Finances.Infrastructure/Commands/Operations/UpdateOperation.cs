﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Commands.Operations
{
    public class UpdateOperation : AuthenticatedCommandBase
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
