using System;
using System.Threading;
using Shouldly;

namespace Cronny.Tests
{
    public class CronnyTests : IDisposable
    {
        public void Dispose()
        {
            CronnyControl.Stop();
        }

        public void Canary()
        {
            true.ShouldBe(true);
        }

        public void Canary_Rabbit()
        {
            var reset = new ManualResetEventSlim();
            CronnyControl.Bus.Subscribe<EachMinuteJobMessage>("yo", m => reset.Set());
            CronnyControl.Bus.Publish(new EachMinuteJobMessage());
            Should.CompleteIn(() => reset.Wait(), TimeSpan.FromSeconds(2));
        }

        public void Run_MessageShouldBeSentOnStart_ShouldReceiveIt()
        {
            var resetEvent = new ManualResetEventSlim();
            CronnyControl.Bus.Subscribe<EachMinuteJobMessage>("test", m => resetEvent.Set());
            CronnyControl.Run();
            Should.CompleteIn(() => resetEvent.Wait(), TimeSpan.FromSeconds(2));
        }
    }
}