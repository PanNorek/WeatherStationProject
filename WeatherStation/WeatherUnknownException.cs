using System;
using System.Runtime.Serialization;

namespace WeatherStation
{
    [Serializable]
    internal class WeatherUnknownException : Exception
    {
        public WeatherUnknownException()
        {
        }

        public WeatherUnknownException(string message) : base(message)
        {
        }

        public WeatherUnknownException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WeatherUnknownException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}