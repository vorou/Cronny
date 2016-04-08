using System;

namespace Cronny
{
    public class CronnyJob : Attribute
    {
        public string Cron { get; private set; }
        public bool FireOnStart { get; private set; }

        public CronnyJob(string cron, bool fireOnStart = false)
        {
            Cron = cron;
            FireOnStart = fireOnStart;
        }
    }
}