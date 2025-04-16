using System;

namespace Specification.Exceptions{
    public abstract class BaseSpecificationException : Exception
    {
        protected BaseSpecificationException(string message) : base(message)
        {         
        }

        protected BaseSpecificationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BaseSpecificationException(string message, string specificationName) : base($"{message} in {specificationName}")
        {
        }

        protected BaseSpecificationException(string message, string specificationName, Exception innerException) : base($"{message} in {specificationName}", innerException)
        {
        }

        protected static string FormatMessage(string baseMessage, string? specificationName = null)
        {
            return specificationName == null ? baseMessage : $"{baseMessage} in {specificationName}";
        }
    }
}