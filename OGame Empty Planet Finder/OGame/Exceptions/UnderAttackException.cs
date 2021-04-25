using System;

namespace OGameEmptyPlanetFinder.OGame.Exceptions
{
    public class UnderAttackException : Exception
    {
        public UnderAttackException()
        { }
        public UnderAttackException(string message) : base(message) { }
    }
}
