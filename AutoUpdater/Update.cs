using System;
using System.IO;
using System.Net;
using System.IO.Compression;

namespace AutoUpdater {
    public static class Update {

        public static string API { get; } = "https://api.github.com/repos/The-Architect01/Dungeons-and-Dragons-Player-Maker/releases";

        static string SaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Star Interactive\file0";

        public static DateTime PublishDate {
            get {
                using(WebClient wc = new()) {
                    wc.Headers.Add("user-agent:Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36");
                    string response = wc.DownloadString(API);
                    string datalocation = response.Split("\"assets\": [")[0];
                    string data = datalocation.Split("\"published_at\": ")[1].Split("\"")[1];
                    return new(int.Parse(data.Split("-")[0]), int.Parse(data.Split("-")[1]), int.Parse(data.Split("-")[2].Split("T")[0]),
                    int.Parse(data.Split("T")[1].Split(":")[0]), int.Parse(data.Split("T")[1].Split(":")[1]), int.Parse(data.Split("T")[1].Split(":")[2].Split("Z")[0]));
                }
            }
        }

        public static Version Version {
            get {
                using(WebClient wc = new()) {
                    wc.Headers.Add("user-agent:Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36");
                    string response = wc.DownloadString(API);
                    string datalocation = response.Split("\"assets\": [")[1];
                    string data = datalocation.Split("\"browser_download_url\": ")[1].Split("\"")[1].Split("/")[7];
                    return new(data);
                }
            }
        }

        public static bool CheckForUpdates(string CurrentVersion) {
            return CurrentVersion != Version.ToString();
        } 

        public static void DownloadUpdate() {
            //try {
                using (WebClient wc = new()) {
                    wc.Headers.Add("user-agent:Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36");
                    string response = wc.DownloadString(API);
                    string datalocation = response.Split("\"assets\": [")[1];
                    string data = datalocation.Split("\"browser_download_url\": ")[1];
                    string file = data.Split("\"")[1];
                    Directory.CreateDirectory(Path.GetTempPath() + "Star Interactive");
                    wc.DownloadFile(file, Path.GetTempPath() + "Star Interactive\\Update.zip");
                }
                InstallUpdate(Path.GetTempPath() + "Star Interactive\\Update.zip");
            //} catch(IOException) {
                
            //    return;
            //}
        }

        public static void InstallUpdate(string ZipLocation) {
            ZipArchive Zip = ZipFile.OpenRead(ZipLocation);
            string FileLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Star Interactive\";
            Zip.ExtractToDirectory(FileLocation, true);

            UpdateVersion();
        }

        public static void UpdateVersion() {
            string[] file0 = File.ReadAllLines(SaveLocation);
            file0[2] = $"  \"CurrentVersion\": \"{Version}\",";
            File.WriteAllLines(SaveLocation,file0);
        }


        public static void ExtractToDirectory(this ZipArchive archive, string destinationDirectoryName, bool overwrite) {
            if (!overwrite) {
                archive.ExtractToDirectory(destinationDirectoryName);
                return;
            }

            DirectoryInfo di = Directory.CreateDirectory(destinationDirectoryName);
            string destinationDirectoryFullPath = di.FullName;

            foreach (ZipArchiveEntry file in archive.Entries) {
                string completeFileName = Path.GetFullPath(Path.Combine(destinationDirectoryFullPath, file.FullName));

                if (!completeFileName.StartsWith(destinationDirectoryFullPath, StringComparison.OrdinalIgnoreCase)) {
                    throw new IOException("Zip Slip Vulnerability detected {https://snyk.io/research/zip-slip-vulnerability}!\nPlease report this so that it can be fixed ASAP {https://github.com/The-Architect01/Dungeons-and-Dragons-Player-Maker/issues}!\nNow Aborting!");
                }

                if (file.Name == "") {// Assuming Empty for Directory
                    Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                    continue;
                }
                file.ExtractToFile(completeFileName, true);
            }
        }



    }
}
