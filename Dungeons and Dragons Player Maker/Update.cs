using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace Dungeons_and_Dragons_Player_Maker {
    public class Update {

        public static string API { get; } = "https://api.github.com/repos/The-Architect01/Dungeons-and-Dragons-Player-Maker/releases";
        //public static string UpdateLocation { get; } = "";

        public static string Location { get; } = "https://raw.githubusercontent.com/The-Architect01/Dungeons-and-Dragons-Player-Maker/master/UpdateInformation.xml";

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



    }
}
