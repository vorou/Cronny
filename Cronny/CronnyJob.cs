using System;

namespace Cronny
{
    public class CronnyJob : Attribute
    {
        public string Cron { get; }
        public bool FireOnStart { get; }

        public CronnyJob(string cron, bool fireOnStart = false)
        {
            Cron = cron;
            FireOnStart = fireOnStart;
        }
    }
}