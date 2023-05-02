using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot
{

    internal class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commandService;
        private IServiceProvider _serviceProvider;
        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            var config = new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.All
            };
            _client = new DiscordSocketClient(config);
            _commandService = new CommandService();
           
            _serviceProvider = new ServiceCollection()
                
                .AddSingleton(_client)
                .AddSingleton(_commandService)
                .BuildServiceProvider();
             
           
           
            _client.Log += Log;

            var token = "MTEwMTQ1NzQ5NjYwMzg5NzkyOQ.GN0qX_.EP2NF2NpBWvqEUp57GTc4IAtw_NE7lJTzqJNws";

       
            await RegisterCommandAsync();
            
        await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await Task.Delay(-1);    
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            var nemt = Assembly.GetEntryAssembly();
            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(),_serviceProvider); 
        }

        private async Task HandleCommandAsync(SocketMessage args)
        {
          _=  Task.Run(async () =>
            {
                var message = args as SocketUserMessage;
                var context = new SocketCommandContext(_client, message);
                if (message.Author.IsBot) return;
                int argpos = 0;
                var ff = message.CleanContent;
            if (message.HasStringPrefix("!", ref argpos))
            {
                var result = await _commandService.ExecuteAsync(context, argpos, _serviceProvider);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }
           }
            );
        }


    }
}
