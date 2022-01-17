using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using System;

namespace proyekUAS1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ourWindow = new NativeWindowSettings()
            {
                Size = new Vector2i(3840, 2160),
                //Size = new Vector2i(1000, 1000),
                Title = "Proyek UAS"
            };
            using (var win = new Window(GameWindowSettings.Default, ourWindow))
            {
                win.Run();
            }
        }
    }
}
