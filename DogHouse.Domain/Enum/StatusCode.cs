﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse.Domain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,
        DogNotFound = 10,
        OK = 200,
        NotFound = 404,
        InternalServerError = 500,
    }
}
