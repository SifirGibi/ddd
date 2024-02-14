using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SifirGibiMakina
{
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public void SendMessage(string message)
        {
            Clients.All.SendMessage(message);
        }
    }
}