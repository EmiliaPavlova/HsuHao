namespace RabitFury.Extensions
{
    using System;

    public static class MathExtensions
    {
        public static T Module<T>(T n, T m)
            where T : struct, IComparable, IComparable<T>, IConvertible
        {
            T result = ((n as dynamic % m) + m) % m;
            return result;
        }
    }
}