using System;
using System.Runtime.Serialization;

namespace SSI.Driver.Prysm
{
    [Serializable]
    internal class AppServerInitializationException : Exception
    {
        public AppServerInitializationException()
        {
        }

        public AppServerInitializationException(string message) : base(message)
        {
        }

        public AppServerInitializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AppServerInitializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}