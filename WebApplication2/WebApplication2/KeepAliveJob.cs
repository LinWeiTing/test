using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using Quartz;
using System.Net;

namespace WebApplication2
{
    public class KeepAliveJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadString("http://linechart-1.apphb.com/twst.aspx");
            }
        }
    }
}