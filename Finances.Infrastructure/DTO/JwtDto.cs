﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.DTO
{
    public class JwtDTO
    {
        public string Token { get; set; }

        public long Expires { get; set; }
    }
}
