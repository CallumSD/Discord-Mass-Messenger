using Discord_Mass_Messenger.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Mass_Messenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Message: ");
            string Message = Console.ReadLine();
            Console.WriteLine("Your User Id: ");
            string UserId = Console.ReadLine();
            Console.WriteLine("Auth Token: ");
            string AuthToken = Console.ReadLine();
            List<Friend> friendsList = Discord.Client.FriendsList(AuthToken);
            foreach (Friend Person in friendsList)
            {
                Console.WriteLine("GETTING CHANNEL ID");
                string ChannelId = Discord.Client.GetChannel(UserId, Person.user.id, AuthToken);
                Console.WriteLine(ChannelId);
                Console.WriteLine("MESSAGING " + Person.user.username + ":" + Person.user.discriminator);
                Discord.Client.SendMessage(Message, ChannelId, AuthToken);
            }
            Console.ReadKey();
        }
    }
}
