﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Common
{
    public interface IResponse
    {
        string Message { get; set; }
        bool Status{ get; set; }
    }
}
