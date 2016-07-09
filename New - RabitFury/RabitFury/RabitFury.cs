using System;

namespace RabitFury
{
#if WINDOWS || LINUX
    public static class RabitFury
    {
        [STAThread]
        static void Main()
        {
            using (var game = new StartUp.Engine())
                game.Run();
        }
    }
#endif
}