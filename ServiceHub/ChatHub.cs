﻿using Microsoft.AspNetCore.SignalR;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ServiceHub
{
    public class ChatHub : Hub
    {
        public static int TotalUsers { get; set; } = 0;

        public static List<User> Users = new List<User>();

        public override Task OnConnectedAsync()
        {
            TotalUsers++;
            return base.OnConnectedAsync();
        }

        public async Task UsersConnected()
        {
            await Clients.All.SendAsync("updateTotalUsers", TotalUsers);
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var userQ = Users.FirstOrDefault(x => x.connectionId == Context.ConnectionId);
            if (userQ != null)
            {
                Users.Remove(userQ);
            }
            TotalUsers--;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnDisconnectedAsync(exception);
        }

        public async Task UserNameAdd(string name)
        {
            var userQ = Users.FirstOrDefault(x => x.Name.Equals(name));
            if (userQ != null)
            {
                await Clients.Caller.SendAsync("AddUser", "Пользователь с именем " + $"\"{name}\"" + " уже существует");
            }
            else
            {
                User user = new User()
                {
                    Name = name,
                    connectionId = Context.ConnectionId,
                };
                Users.Add(user);
                await Clients.Caller.SendAsync("AddUser", $"\"{user.Name}\"" + " Сonnected");
            }
        }

        public void UserNameRemove(string name)
        {
            var userQ = Users.FirstOrDefault(x => x.Name.Equals(name));
            if (userQ != null)
            {
                Users.Remove(userQ);
            }
        }

        public async Task Send(string user, string message)
        {

            await Clients.All.SendAsync("Receive", user, message);
        }

        ObservableCollection<Message> collection = new ObservableCollection<Message>();
        
        public async Task PrivateSend(string sender, string recipient, string message)
        {
            
            Message message1 = new Message()
            {
                Sender = sender,
                Recipient = recipient,
                _Message = message
            };
            collection.Add(message1);


            var userQ = Users.FirstOrDefault(x => x.Name.Equals(recipient));
            var user2Q = Users.FirstOrDefault(x => x.Name.Equals(sender));
            if (userQ != null && user2Q != null)
            {
                await Clients.Clients(userQ.connectionId, user2Q.connectionId).SendAsync("Private", sender, recipient, message);
                collection.Remove(message1);
            }
            else if (user2Q == null)
            {
                await Clients.Caller.SendAsync("Private", sender, recipient, $"Сообщение не доставлено! Пользователь \"{recipient}\" покинул чат!");
            }
            else if (userQ == null)
            {
                await Clients.Caller.SendAsync("Private", sender, recipient, $"Сообщение не доставлено! Пользователь \"{recipient}\" покинул чат!");

            }
        }
    }
}
