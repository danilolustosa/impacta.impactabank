﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Model.Response
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
