using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using SelfHostedSignalR.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedSignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR<TestConnection>("/test");
            app.Map("/rooms", map=> {
                map.UseCors(CorsOptions.AllowAll);
                map.RunSignalR(new HubConfiguration());
            });
        }
    }
}
