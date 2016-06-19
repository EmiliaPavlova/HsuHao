using System;

namespace Ninjacademy
{
#if WINDOWS || LINUX
    public static class StartUp
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
