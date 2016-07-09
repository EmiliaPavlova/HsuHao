namespace RabitFury.Exceptions
{
    using System;

    public class EndGameException : Exception
    {
        public EndGameException(string msg)
            :base(msg) { }

        public EndGameException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}