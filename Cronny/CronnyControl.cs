using EasyNetQ;

namespace Cronny
{
    public static class CronnyControl
    {
        static CronnyControl()
        {
            Bus = RabbitHutch.CreateBus();
        }

        public static IBus Bus { get; private set; }

        public static void Run()
        {
        }
    }
}