using System;

namespace OGameEmptyPlanetFinder.Exceptions
{
    public class SessionClosedException : Exception
    {
        public SessionClosedException()
        { }
        public SessionClosedException(string message) : base(message) { }
    }
}
