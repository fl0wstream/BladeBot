using System;
using TwitchChatSharp;

namespace PhantomBot 
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TwitchConnection(
                cluster: ChatEdgeCluster.Aws,
                nick: "mybotsname",
                oauth: "592348324093290489802993482042", // do not include the oauth: prefix
                port: 6697,
                capRequests: new string[] { "twitch.tv/tags", "twitch.tv/commands" },
                ratelimit: 1500,
                secure: true
                );

            client.Connected += (object sender, IrcConnectedEventArgs e) =>
            {
                Console.WriteLine("Connected");
                client.JoinChannel("#mychannelname"); // include the #, in the same format you would for an IRC client
            };

            client.MessageReceived += (object sender, IrcMessageEventArgs e) =>
            {
                Console.WriteLine("Received: " + e.Message.ToString());
            };

            client.Reconnected += (object sender, EventArgs e) =>
            {
                Console.WriteLine("Reconnected");
            };

            client.Connect();
        }
    }
}
