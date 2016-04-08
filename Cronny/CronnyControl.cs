using System;
using Common.Logging;
using Common.Logging.Simple;
using Cronny.TestMessages;
using EasyNetQ;
using Quartz;
using Quartz.Impl;

namespace Cronny
{
    public static class CronnyControl
    {
        private static IScheduler Scheduler;

        static CronnyControl()
        {
            Bus = RabbitHutch.CreateBus();
        }

        public static IBus Bus { get; }

        public static void Run()
        {
            try
            {
                LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter {Level = LogLevel.Info};
                Scheduler = StdSchedulerFactory.GetDefaultScheduler();
                Scheduler.Start();

                //TODO: remove needless stuff
                //TODO: scan for JobMessages
                IJobDetail job = JobBuilder.Create<YoJob>()
                                           .WithIdentity("job1", "group1")
                                           .Build();
                ITrigger trigger = TriggerBuilder.Create()
                                                 .WithIdentity("trigger1", "group1")
                                                 .StartNow()
                    //TODO: grab actual schedule from attribute
                                                 .WithSimpleSchedule(x => x.WithIntervalInSeconds(1)
                                                                           .RepeatForever())
                                                 .Build();
                Scheduler.ScheduleJob(job, trigger);
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }

        public static void Stop()
        {
            Scheduler.Shutdown();
            Bus.Dispose();
        }
    }

    //TODO: job should be generic
    public class YoJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CronnyControl.Bus.Publish(new EachMinuteJobMessage());
        }
    }
}