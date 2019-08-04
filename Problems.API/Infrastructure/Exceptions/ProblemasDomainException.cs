namespace SGQ.Problemas.API.Infrastructure.Exceptions
{
    using System;

    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class ProblemasDomainException : Exception
    {
        public ProblemasDomainException()
        { }

        public ProblemasDomainException(string message)
            : base(message)
        { }

        public ProblemasDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
