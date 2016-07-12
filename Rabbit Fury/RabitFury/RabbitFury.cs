namespace RabitFury
{
    using System;
#if WINDOWS || LINUX
    public static class RabbitFury
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