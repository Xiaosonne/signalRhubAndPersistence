using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedSignalR.Connection
{
    public class TestConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            this.Connection.Send(connectionId, new { msg = "hello world" });
            return base.OnConnected(request, connectionId);  
        }
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
           return  Task.Run(() => {
                this.Connection.Send(connectionId,$"echo:{connectionId},{data}");
            });
        }
    }
}
