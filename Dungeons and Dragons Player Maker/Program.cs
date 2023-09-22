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
            IO.CreateShortcut();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new SplashScreen());
            try {
                IO.SaveDataToDisk();
                if (Update.CheckForUpdates(Engine.SaveData.CurrentVersion)) {
                    MessageBox.Show("The application has detected that an update is available. This application will update when it is closed.");
                    Engine.SaveData.CurrentVersion = Update.Version.ToString();
                    Application.ApplicationExit += delegate { Update.DownloadUpdate(); };
                } 
            } catch (IndexOutOfRangeException) {}
            if (Engine.SaveData.LastUpdated == DateTime.MinValue) { Engine.SaveData.LastUpdated = DateTime.UtcNow; IO.SaveDataToDisk(); }
            Application.Run(new MainMenu());
            IO.SaveDataToDisk();
        }
    }
}
