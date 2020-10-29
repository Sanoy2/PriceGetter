﻿using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web.QuartzConfig
{
    public class Schedule : JobSchedule
    {
        public Schedule(Type jobType) : base(jobType)
        {
        }

        public override ITrigger CreateTrigger()
        {
            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder
                .Create()
                .WithIdentity("DEFAULT.PriceGetter.Quartz.Jobs.HelloWorld.trigger")
                .StartAt(DateTime.Now.AddSeconds(2))
                .Build();

            return trigger;
        }
    }
}
