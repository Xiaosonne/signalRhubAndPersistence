using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedSignalR.Hubs
{
    public class RoomHub : Hub
    {
        public void GroupMessage(string groupname, string msg)
        {
            Clients.Group(groupname).onMessage(msg);
        }
        public void JoinGroup(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
            Clients.All.reportGroupMember(groupName,Context.ConnectionId);
        }

    }
}
