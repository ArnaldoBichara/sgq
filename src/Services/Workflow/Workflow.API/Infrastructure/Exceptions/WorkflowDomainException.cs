namespace SGQ.Workflow.API.Infrastructure.Exceptions
{
    using System;

    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class WorkflowDomainException : Exception
    {
        public WorkflowDomainException()
        { }

        public WorkflowDomainException(string message)
            : base(message)
        { }

        public WorkflowDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
