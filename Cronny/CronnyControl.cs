using System;
using System.Linq;
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
                Scheduler = StdSchedulerFactory.GetDefaultScheduler();
                Scheduler.Start();

                var jobMessages = AppDomain.CurrentDomain.GetAssemblies()
                                           .SelectMany(s => s.GetTypes())
                                           .Where(p => p.Name.EndsWith("JobMessage"));

                foreach (var jobMessage in jobMessages)
                {
                    Console.Out.WriteLine(jobMessage);
                    var sendMessageJobType = typeof (SendMessageJob<>).MakeGenericType(jobMessage);
                    var job = JobBuilder.Create(sendMessageJobType).Build();
                    //TODO: propa trigger
                    //TODO: fire now logic
                    var trigger = TriggerBuilder.Create().StartAt(DateTimeOffset.UtcNow.AddSeconds(1)).Build();
                    Scheduler.ScheduleJob(job, trigger);
                }
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
}