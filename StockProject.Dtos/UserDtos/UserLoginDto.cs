﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Dtos.UserDtos
{
    public class UserLoginDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
