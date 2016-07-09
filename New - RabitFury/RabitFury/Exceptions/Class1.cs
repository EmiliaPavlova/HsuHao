namespace RabitFury.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EndGameException : Exception
    {
        public EndGameException()
        {
        }

        public EndGameException(string message)
            : base(message)
        {
        }

    }
}
