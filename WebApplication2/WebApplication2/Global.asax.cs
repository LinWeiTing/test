using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Quartz;
using Quartz.Impl;

namespace WebApplication2
{
    public class Global : HttpApplication
    {

        private IScheduler schedular = null;

        void Application_Start(object sender, EventArgs e)
        {
            // 應用程式啟動時執行的程式碼
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
    
        
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler();

            var keepAliveJob = JobBuilder.Create<KeepAliveJob>().Build();
            var keepAliveTrigger = TriggerBuilder.Create()
                            .WithSimpleSchedule(x => x.WithIntervalInMinutes(15).RepeatForever())
                            .Build();

            scheduler.ScheduleJob(keepAliveJob, keepAliveTrigger);
            scheduler.Start();  
        }
    }
}