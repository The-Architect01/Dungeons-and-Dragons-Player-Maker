using System;
using System.Windows.Forms;

using Dungeons_and_Dragons_Player_Maker.Properties;
using AutoUpdaterDotNET;
using DD = Dungeons_and_Dragons_Player_Maker;

namespace Dungeons_and_Dragons_Player_Maker {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread, Obsolete]
        private static void Main() {
            if (DD.Update.Version > new Version(Settings.Default.CurrentVersion) /*&& DD.Update.PublishDate >= Settings.Default.LastUpdated*/) {
                AutoUpdater.Mandatory = true;
                AutoUpdater.ShowSkipButton = false;
                AutoUpdater.ShowRemindLaterButton = false;
                AutoUpdater.UpdateFormSize = new System.Drawing.Size(800, 600);
                AutoUpdater.InstalledVersion = new Version(Settings.Default.CurrentVersion);
                AutoUpdater.ApplicationExitEvent += ExitEvent;
                AutoUpdater.Start(DD.Update.Location);
                while (!moveOn) { }
                Settings.Default.LastUpdated = DateTime.UtcNow;
                Settings.Default.CurrentVersion = DD.Update.Version.ToString();
                Settings.Default.Save();
            }
            if (Settings.Default.LastUpdated == DateTime.MinValue) { Settings.Default.LastUpdated = DateTime.UtcNow; Settings.Default.Save(); }
        //  Application.SetHighDpiMode(HighDpiMode.PerMonitor);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new SplashScreen());
            Application.Run(new MainMenu());
        }

        static bool moveOn = false;

        private static void ExitEvent() {
            moveOn = true;
        }
    }
}
