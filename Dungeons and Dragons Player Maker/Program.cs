using System;
using System.Windows.Forms;
using System.IO;
using AutoUpdater;

namespace Dungeons_and_Dragons_Player_Maker {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread, Obsolete]
        private static void Main() {
            //  Application.SetHighDpiMode(HighDpiMode.PerMonitor);
            Engine.CreateShortcut();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new SplashScreen());
            if (Update.CheckForUpdates(Engine.SaveData.CurrentVersion)) {
                MessageBox.Show("The application has detected that an update is available. This application will update when it is closed.");
                Application.ApplicationExit += delegate {
                    Update.DownloadUpdate();
                };
            }
            if (Engine.SaveData.LastUpdated == DateTime.MinValue) { Engine.SaveData.LastUpdated = DateTime.UtcNow; Engine.SaveDataToDisk(); }
            Application.Run(new MainMenu());
        }
    }
}
