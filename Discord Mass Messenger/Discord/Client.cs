using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord_Mass_Messenger.Objects;
using Newtonsoft.Json;
using RestSharp;

namespace Discord_Mass_Messenger.Discord
{
    public class Client
    {
        public static void SendMessage(string Message, string ChannelId, string AuthToken)
        {
            RestClient Client = new RestClient("https://discordapp.com/api/v6/channels/"+ ChannelId + "/messages")
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/0.0.301 Chrome/56.0.2924.87 Discord/1.6.15 Safari/537.36",
                FollowRedirects = false
            };
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", AuthToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json; charset=utf-8", @"{""content"":"""+Message+ @""",""nonce"":""487892335116419072"",""tts"":false}", ParameterType.RequestBody);

            IRestResponse Execute = Client.Execute(request);
            string Response = Execute.Content;
        }
        public static string GetChannel(string UserId, string FriendId, string AuthToken)
        {
            RestClient Client = new RestClient("https://discordapp.com/api/v6/users/" + UserId + "/channels")
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/0.0.301 Chrome/56.0.2924.87 Discord/1.6.15 Safari/537.36",
                FollowRedirects = false
            };
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", AuthToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json; charset=utf-8", @"{""recipients"":["""+ FriendId + @"""]}", ParameterType.RequestBody);

            IRestResponse Execute = Client.Execute(request);
            string Response = Execute.Content;
            Channel Person = JsonConvert.DeserializeObject<Channel>(Response);
            return Person.id;
        }
        public static List<Friend> FriendsList(string AuthToken)
        {
            RestClient Client = new RestClient("https://discordapp.com/api/v6/users/@me/relationships")
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/0.0.301 Chrome/56.0.2924.87 Discord/1.6.15 Safari/537.36",
                FollowRedirects = false
            };
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", AuthToken);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse Execute = Client.Execute(request);
            string Response = Execute.Content;
            return JsonConvert.DeserializeObject<List<Friend>>(Response);

        }
    }
}
