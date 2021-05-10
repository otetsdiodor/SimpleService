﻿using System;

namespace SimpleService.Core.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {}
    }
}
