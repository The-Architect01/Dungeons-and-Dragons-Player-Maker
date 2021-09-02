using System;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread, Obsolete]
        private static void Main() {
        //  Application.SetHighDpiMode(HighDpiMode.PerMonitor);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new SplashScreen());
            Application.Run(new MainMenu());
        }
    }
}
