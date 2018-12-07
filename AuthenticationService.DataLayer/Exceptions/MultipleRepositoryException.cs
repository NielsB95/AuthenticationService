using System;
using System.Runtime.Serialization;

namespace AuthenticationService.DataLayer.Exceptions
{
    public class MultipleRepositoryImplementationException : Exception
    {
        public MultipleRepositoryImplementationException()
        {
        }

        public MultipleRepositoryImplementationException(string message) : base(message)
        {
        }

        public MultipleRepositoryImplementationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MultipleRepositoryImplementationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
