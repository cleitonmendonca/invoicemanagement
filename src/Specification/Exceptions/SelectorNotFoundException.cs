﻿using System;

namespace Specification.Exceptions
{
    public class SelectorNotFoundException : Exception
    {
        private new const string Message = "The specification must have Selector defined.";

        public SelectorNotFoundException() : base(Message)
        {

        }

        public SelectorNotFoundException(Exception innerException) : base(Message, innerException)
        {

        }
    }
}
